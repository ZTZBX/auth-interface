using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace auth_interface.Client
{
    public class LoginNui : BaseScript
    {
        public LoginNui()
        {
            RegisterNuiCallbackType("login_nui");
            EventHandlers["__cfx_nui:login_nui"] += new Action<IDictionary<string, object>, CallbackDelegate>(LoginNuiCall);
            
        }

        private void LoginNuiCall(IDictionary<string, object> data, CallbackDelegate cb)
        {

            int source = PlayerId();
            
            object username;
            object password;

            if (!data.TryGetValue("username", out username)) { return; }
            if (!data.TryGetValue("password", out password)) { return; }

            string current_username = username.ToString();
            string current_password = password.ToString();

            if (current_username.ToString().Length <= 0)
            {
                cb(new
                {
                    error = Exports["language"].no_username()
                });
                return;
            }
            if (current_password.Length <= 0)
            {
                cb(new
                {
                    error = Exports["language"].no_password()
                });
                return;
            }

            TriggerServerEvent("login", current_username, current_password);
        }

    }
}