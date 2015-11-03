﻿namespace Habitat.Accounts.Repositories
{
  using Habitat.Accounts.Models;

  public interface IAccountRepository
  {
    void RegisterUser(RegistrationInfo registrationInfo);
    bool Exists(string userName);
  }
}
