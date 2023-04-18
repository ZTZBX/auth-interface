using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using System.Collections.Generic;


namespace auth_interface.Server
{
    public class ServerMain : BaseScript
    {
        public ServerMain()
        {
            EventHandlers["login"] += new Action<Player, string, string>(Login);
            EventHandlers["register"] += new Action<Player, string, string, string>(Register);

        }

        private void Login([FromSource] Player user, string username, string password)
        {
            List<string> user_pass = new List<string> { };
            user_pass.Add(username);
            user_pass.Add(password);

            int player_id = int.Parse(user.Handle);

            string result = Exports["core-ztzbx"].login(player_id, user_pass);

            if (result == "OK")
            {
                TriggerClientEvent(user, "loginAction", true, result);
            }
            else
            {
                TriggerClientEvent(user, "loginAction", false, result);
            }
        }

        private void Register([FromSource] Player user, string username, string password, string email)
        {
            List<string> user_pass = new List<string> { };
            user_pass.Add(username);
            user_pass.Add(password);
            user_pass.Add(email);

            int player_id = int.Parse(user.Handle);

            string result = Exports["core-ztzbx"].register(player_id, user_pass);

            if (result == "OK")
            {
                TriggerClientEvent(user, "loginAction", true, result);
            }
            else
            {
                TriggerClientEvent(user, "loginAction", false, result);
            }
        }

    }
}