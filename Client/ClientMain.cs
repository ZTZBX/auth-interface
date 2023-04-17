using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace auth_interface.Client
{
    public class ClientMain : BaseScript
    {
        public ClientMain()
        {

            EventHandlers["onResourceStart"] += new Action<string>(OnResourceStart);
            EventHandlers["loginAction"] += new Action<bool, string>(LoginAction);

        }

        private void OnResourceStart(string resourceName)
        {
            if (GetCurrentResourceName() != resourceName) return;
            ClientMain.AuthUi(true);
        }

        private void LoginAction(bool status, string info)
        {
            if (status == true) {ClientMain.AuthUi(false);}
        }

        static public void AuthUi(bool state)
        {
            string jsonString = "";
            if (state) { jsonString = "{\"showAuth\": true}"; SetNuiFocus(true, true);}
            if (!state) { jsonString = "{\"showAuth\": false}"; SetNuiFocus(false, false);}
            
            SendNuiMessage(jsonString);
        }
    }
}