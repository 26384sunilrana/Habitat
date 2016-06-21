﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Sitecore.Foundation.Common.Specflow.Extensions;
using TechTalk.SpecFlow;

namespace Sitecore.Foundation.Common.Specflow.Infrastructure
{
  public class CommonLocators
  {
    public static IWebDriver Driver => FeatureContext.Current.Get<IWebDriver>();

    public IWebElement SiteSwitcherIcon
      => Driver.FindElement(By.CssSelector(".fa.fa-home"));

    public static IEnumerable<IWebElement> SiteSwitcherIconDropDownChildElements
      => Driver.WaitUntilElementsPresent(By.CssSelector(".dropdown-menu li a, .active a"));

    public static IEnumerable<IWebElement> DropDownActiveValues
      => Driver.FindElements(By.CssSelector(".dropdown-menu li.active"));


    public IEnumerable<IWebElement> SiteSwitcherelements
      => Driver.FindElements(By.CssSelector(".dropdown-menu>li>a"));


    public IWebElement DemoSiteLogo
      => Driver.FindElement(By.CssSelector("#hplogo"));

    public IEnumerable<IWebElement> OnsideBehaviorData
      = Driver.FindElements(By.CssSelector(".list-unstyled li div"));

    public void NavigateToPage(string url)
    {
      Driver.Navigate().GoToUrl(url);
    }

    public void ExperianceEditor(string url)
    {
      Driver.Navigate().GoToUrl(url);
    }

    public IWebElement SubmitButton => Driver.FindElement(By.CssSelector("input[type=submit]"));

    public static IEnumerable<IWebElement> RegisterPageFields
      =>
        Driver.FindElements(By.CssSelector("#registerEmail, #registerPassword, #registerConfirmPassword"));

    public IWebElement UserIcon => Driver.FindElement(By.CssSelector(".fa-user"));

    public static IEnumerable<IWebElement> UserIconButtons
      =>
        Driver.FindElements(By.CssSelector(".btn.btn-block.btn-primary, .btn.btn-block.btn-default"));
    public static IEnumerable<IWebElement> UserIconDropDownButtonLinks
  => Driver.FindElements(By.CssSelector(".btn.btn-block.btn-primary"));

    public static IEnumerable<IWebElement> LoginPageLinks
      => Driver.WaitUntilElementsPresent(By.CssSelector(".btn.btn-link, .btn.btn-default.btn-lg.btn-block")).Where(el => el.Displayed).ToList();

    public static IEnumerable<IWebElement> LoginPageButtons
      => Driver.FindElements(By.CssSelector(".btn.btn-primary.btn-lg.btn-block")).Where(el => el.Displayed).ToList();

    public static IEnumerable<IWebElement> OpenXdbSlidebar
      => Driver.WaitUntilElementsPresent(By.CssSelector(".btn.btn-info.sidebar-closed"));

    public static IEnumerable<IWebElement> XdBpanelHeader
      => Driver.WaitUntilElementsPresent(By.CssSelector(".panel-title.collapsed"));

    public static IEnumerable<IWebElement> UserIconOnPersonalInformation
      => Driver.FindElements(By.CssSelector(".panel-body div div .fa.fa-user"));

    public static IEnumerable<IWebElement> MediaTitleOnPersonalInformation
      => Driver.FindElements(By.CssSelector(".panel-body div div .media-title"));

    public static IEnumerable<IWebElement> IdentificationUknownStatusIcon
      => Driver.FindElements(By.CssSelector(".panel-body div div .fa.fa-user-secret.icon-lg"));

    public static IEnumerable<IWebElement> IdentificationKnownStatusIcon
      => Driver.FindElements(By.CssSelector(".fa.fa-user-plus.icon-lg"));

    public static IEnumerable<IWebElement> XdBpanelMediaBody
      => Driver.FindElements(By.CssSelector(".media-body"));

    public static IEnumerable<IWebElement> ManageXdBpanelButtons
      => Driver.FindElements(By.CssSelector(".hover-only"));

    public static IWebElement GlobeIcon => Driver.FindElement(By.CssSelector(".navbar-right"));

    public static bool GlobeIconExists() => Driver.FindElements(By.CssSelector(".navbar-right")).Any();

    public static IEnumerable<IWebElement> GlobeIconList
          => Driver.WaitUntilElementsPresent(By.CssSelector(".navbar-right .dropdown.open .dropdown-menu a"));
    public static IEnumerable<IWebElement> MetakeywordTag => Driver.FindElements(By.CssSelector("meta[name=keywords]"));

    public static IEnumerable<IWebElement> DatasourceCommand => Driver.WaitUntilElementsPresent(By.CssSelector(".scChromeToolbar.undefined a.scChromeCommand[title='Associate a content item with this component.']"));

    public static IEnumerable<IWebElement> SitecoreLoginFields => Driver.WaitUntilElementsPresent(By.CssSelector("#UserName, #Password"));

    public static IEnumerable<IWebElement> TwitterPlaceholder => Driver.FindElements(By.CssSelector(".well.bg-dark.scEnabledChrome"));

    public static IEnumerable<IWebElement> TwitterTreeContent
      => Driver.FindElements(By.CssSelector(".scContentTreeNodeTitle"));



    public static void WaitRibbonPreLoadingIndicatorInvisible()
    {
      Driver.WaitUntilElementsInvisible(By.CssSelector("#ribbonPreLoadingIndicator"));
    }

    public static void NavigateToExperienceEditorDialogWindow()
    {
      Driver.SwitchTo().Frame(Driver.FindElement(By.Id("jqueryModalDialogsFrame")));
      Driver.SwitchTo().Frame(Driver.FindElement(By.Id("scContentIframeId0")));
    }

    public static void NavigateFromExperienceEditorDialogWindow()
    {
      Driver.SwitchTo().DefaultContent();
    }
    
  }
}
