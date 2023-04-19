using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace auth_interface.Client
{
    public class LanguageModule : BaseScript
    {
        public LanguageModule()
        {
            EventHandlers["changeAllLanguageData"] += new Action<string, string, string>(ChangeAllLanguageData);
        }

        private void ChangeAllLanguageData(string no_username, string no_password, string no_email)
        {
            LanguageData.no_username = no_username;
            LanguageData.no_password = no_password;
            LanguageData.no_email = no_email;
        }

    }
}