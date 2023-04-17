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
            else {ClientMain.AuthUi(true, info);}
        }

        static public void AuthUi(bool state, string error = "NOE")
        {
            string jsonString = "";
            
            if (error != "NOE")
            {
                if (state) { jsonString = "{\"showAuth\": true, \"error\": \""+error+"\" }"; SetNuiFocus(true, true);}
            }
            else 
            {
                if (!state) { jsonString = "{\"showAuth\": false, \"error\": \"NOE\" }"; SetNuiFocus(false, false);}
                if (state) { jsonString = "{\"showAuth\": true, \"error\": \"NOE\" }"; SetNuiFocus(true, true);}
            }

            SendNuiMessage(jsonString);
        }
    }
}