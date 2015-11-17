﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habitat.Accounts.Specflow.Steps
{
    static class Settings
    {
        public static String BaseUrl => ConfigurationManager.AppSettings["baseUrl"];
        public static String RegisterPageUrl => ConfigurationManager.AppSettings["registerUrl"];

        public static String LoginPageUrl => ConfigurationManager.AppSettings["loginPageUrl"];

        public static String EditUserProfileUrl => ConfigurationManager.AppSettings["editUserProfileUrl"];

        public static String ContactUsPageUrl => ConfigurationManager.AppSettings["contactUsPageUrl"];
    }
}
