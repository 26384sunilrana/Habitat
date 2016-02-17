﻿using Sitecore.Foundation.Common.Specflow.Infrastructure;

namespace Sitecore.Feature.Accounts.Specflow.Steps
{
  using OpenQA.Selenium;
  using Sitecore.Foundation.Common.Specflow.Extensions;
  using TechTalk.SpecFlow;

  public class SiteNavigation : AccountStepsBase
  {
    [Given(@"Habitat website is opened on Main Page")]
    public void GivenHabitatWebsiteIsOpenedOnMainPage()
    {
      Driver.Navigate().GoToUrl(BaseSettings.BaseUrl);
    }

    [Given(@"Actor moves cursor over the User icon")]
    [When(@"Actor moves cursor over the User icon")]
    public void WhenActorMovesCursorOverTheUserIcon()
    {
      SiteBase.UserIcon.MoveToElement();

#warning hack for selenium hover behavoiur
      var dropdown = SiteBase.UserIcon.FindElement(By.XPath("../../ul"));
      var js = Driver as IJavaScriptExecutor;
      js?.ExecuteScript("arguments[0].style.display='block'", dropdown);
    }

    [When(@"Actor opens Habitat website on Login page")]
    [Given(@"Habitat website is opened on Login page")]
    [When(@"Actor navigates to Login page")]
    public void WhenActorNavigatesToLoginPage()
    {
      Driver.Navigate().GoToUrl(BaseSettings.LoginPageUrl);
    }

    [Given(@"Habitat website is opened on Forgot Password page")]
    public void GivenHabitatWebsiteIsOpenedOnForgotPasswordPage()
    {
      Driver.Navigate().GoToUrl(BaseSettings.ForgotPasswordPageUrl);
    }

    [When(@"Actor moves on siteswitcher combo-box")]
    public void WhenActorMovesOnSiteswitcherCombo_Box()
    {
      SiteBase.SiteSwitcherIcon.MoveToElement();

#warning hack for selenium hover behavoiur
      var dropdown = SiteBase.SiteSwitcherIcon.FindElement(By.XPath("../../ul"));
      var js = Driver as IJavaScriptExecutor;
      js?.ExecuteScript("arguments[0].style.display='block'", dropdown);
    }


  }
}