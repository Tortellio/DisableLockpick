using System;
using Rocket.Core.Plugins;
using Rocket.Unturned.Player;
using SDG.Unturned;
using UnityEngine;
using Logger = Rocket.Core.Logging.Logger;
using System.Linq;
using Rocket.API;
using Rocket.Unturned.Chat;

namespace Tortellio.DisableLockpick
{
    public class DisableLockpick : RocketPlugin<Config>
    {
        public static DisableLockpick Instance;
        public static string PluginName = "DisableLockpick";
        public static string PluginVersion = " 1.0.0";
        public bool loaded = false;
        protected override void Load()
        {
            Instance = this;
            Logger.Log("DisableLockpick has been loaded!", ConsoleColor.Yellow);
            Logger.Log(PluginName + PluginVersion, ConsoleColor.Yellow);
            Logger.Log("Made by Tortellio", ConsoleColor.Yellow);

            if (!Instance.Configuration.Instance.EnablePlugin)
            {
                Logger.Log("DisableLockpick is disabled in configuration.. unloading!");
                Unload();
                return;
            }
            VehicleManager.onVehicleLockpicked += OnLockpicked;
        }
        protected override void Unload()
        {
            Instance = null;
            Logger.Log("DisableLockpick has been unloaded!");
            Logger.Log("Visit Tortellio Discord for more! https://discord.gg/pzQwsew", ConsoleColor.Yellow);

            VehicleManager.onVehicleLockpicked -= OnLockpicked;
        }

        public void OnLockpicked(InteractableVehicle vehicle, Player player, ref bool allow)
        {
            if (!Configuration.Instance.EnablePlugin) { return; }
            UnturnedPlayer stealer = UnturnedPlayer.FromPlayer(player);
            if (stealer.HasPermission(Configuration.Instance.BypassPermission)) { allow = true; return; }
            UnturnedChat.Say(UnturnedPlayer.FromPlayer(player), "Lockpick is disabled", Color.red, "https://i.imgur.com/FeIvao9.png");
            allow = false;
        }
    }
}
