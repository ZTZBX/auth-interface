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
            EventHandlers["loginAction"] += new Action<bool, string>(LoginAction);
            EventHandlers["onClientResourceStart"] += new Action<string>(OnClientResourceStart);


        }

        private void OnClientResourceStart(string resourceName)
        {
            // LOGIC HANGLE
            if (GetCurrentResourceName() != resourceName) return;

            FreezeEntityPosition(PlayerPedId(), true);
            gamenui.gameNui(true, false, false, "login");
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