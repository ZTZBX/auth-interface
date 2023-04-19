using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using System.Collections.Generic;


namespace auth_interface.Server
{
    public class LanguageModule : BaseScript
    {
        public LanguageModule()
        {

            EventHandlers["updateLanguage"] += new Action<Player, string>(UpdateLanguage);

        }

        private void UpdateLanguage([FromSource] Player user, string info)
        {
            TriggerClientEvent(user, "changeAllLanguageData",
             Exports["language"].no_username(),
             Exports["language"].no_password(),
             Exports["language"].no_email()
             );
        }

    }
}