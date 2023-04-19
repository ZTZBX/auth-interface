using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace auth_interface.Client
{
    public class RegisterNui : BaseScript
    {
        public RegisterNui()
        {
            RegisterNuiCallbackType("register_nui");
            EventHandlers["__cfx_nui:register_nui"] += new Action<IDictionary<string, object>, CallbackDelegate>(RegisterNuiCall);
            
        }

        private void  RegisterNuiCall(IDictionary<string, object> data, CallbackDelegate cb)
        {

            int source = PlayerId();
            
            object username;
            object password;
            object email;


            if (!data.TryGetValue("username", out username)) { return; }
            if (!data.TryGetValue("password", out password)) { return; }
            if (!data.TryGetValue("email", out email)) { return; }

            string current_username = username.ToString();
            string current_email = email.ToString();
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

            if (current_email.Length <= 0)
            {
                cb(new
                {
                    error = Exports["language"].no_email()
                });
                return;
            }

            TriggerServerEvent("register", current_username, current_password, current_email);
        }

    }
}