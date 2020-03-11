using Rocket.API;

namespace Tortellio.DisableLockpick
{
    public class Config : IRocketPluginConfiguration
    {
        public bool EnablePlugin;
        public string BypassPermission;
        public void LoadDefaults()
        {
            EnablePlugin = true;
            BypassPermission = "disablelockpick.bypass";
        }
    }
}
