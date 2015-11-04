﻿namespace Habitat.Accounts.Controllers
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Net;
  using System.Net.Http;
  using System.Net.Http.Headers;
  using System.Text;
  using System.Web.Http;
  using System.Web.Http.Results;
  using Habitat.Accounts.Models;
  using Habitat.Accounts.Repositories;
  using Sitecore.Globalization;

  public class AccountsController : ApiController
  {
    private readonly IAccountsRepository _accountsRepository;

    public AccountsController():this(new AccountRepository())
    {
    }

    public AccountsController(IAccountsRepository accountsRepository)
    {
      this._accountsRepository = accountsRepository;
    }


    [HttpPost]
    public LoginResult Login([FromBody]LoginCredentials credentials)
    {
      var loginResult = this._accountsRepository.Login(credentials.UserName, credentials.Password);

      var result = new LoginResult {IsAuthenticated = loginResult, ValidationMessage = Translate.Text("Username or password is not valid.")};

      return result;
    }
  }
}
