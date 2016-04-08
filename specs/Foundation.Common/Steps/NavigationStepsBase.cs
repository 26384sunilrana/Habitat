﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Sitecore.Foundation.Common.Specflow.Extensions;
using Sitecore.Foundation.Common.Specflow.Infrastructure;
using TechTalk.SpecFlow;

namespace Sitecore.Foundation.Common.Specflow.Steps
{
  [Binding]
  public class NavigationStepsBase:StepsBase
  {


    [Given(@"Habitat website is opened on Main Page")]
    public void GivenHabitatWebsiteIsOpenedOnMainPage()
    {
      CommonLocators.NavigateToPage(BaseSettings.BaseUrl);
    }

    [When(@"Actor selects (.*) slidebar")]
    public void WhenActorSelectsSlidebar(string button)
    {
      CommonLocators.OpenXDBSlidebar.First(el => el.GetAttribute("title").Contains(button)).Click();
    }

    [Given(@"Habitat website is opened on Forms page")]
    public void GivenHabitatWebsiteIsOpenedOnFormsPage()
    {
      CommonLocators.NavigateToPage(BaseSettings.FormsPageUrl);
    }
  }
}
