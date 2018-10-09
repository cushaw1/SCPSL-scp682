using Smod2;
using Smod2.Attributes;
using scp_682;

namespace scp682
{
    [PluginDetails(
    author = "cushaw",
    name = "scp682",
    description = "939-89 maybe become 682",
    id = "cushaw.scp682",
    version = "1.0",
    SmodMajor = 3,
    SmodMinor = 1,
    SmodRevision = 18
    )]
    class scp682 : Plugin
    {
        public override void OnDisable()
        {
            this.Info("scp682 not load");
        }

        public override void OnEnable()
        {
            this.Info("scp682 load successfully");
        }

        public override void Register()
        {
            this.AddEventHandlers(new EventHandler(this));
            this.AddConfig(new Smod2.Config.ConfigSetting("scp682_enable", true, Smod2.Config.SettingType.BOOL, true, ""));
            this.AddConfig(new Smod2.Config.ConfigSetting("scp682_door", true, Smod2.Config.SettingType.BOOL, true, ""));
            this.AddConfig(new Smod2.Config.ConfigSetting("scp682_hp", new int { }, Smod2.Config.SettingType.NUMERIC, true, ""));
            this.AddConfig(new Smod2.Config.ConfigSetting("scp682_attack", new int { }, Smod2.Config.SettingType.NUMERIC, true, ""));
            this.AddConfig(new Smod2.Config.ConfigSetting("scp682_spawn", new int { }, Smod2.Config.SettingType.NUMERIC, true, ""));
            this.AddConfig(new Smod2.Config.ConfigSetting("scp682_heal", new int { }, Smod2.Config.SettingType.NUMERIC, true, ""));
            this.AddConfig(new Smod2.Config.ConfigSetting("scp682_healtime", new int { }, Smod2.Config.SettingType.NUMERIC, true, ""));
            this.AddConfig(new Smod2.Config.ConfigSetting("scp682_eat", new int { }, Smod2.Config.SettingType.NUMERIC, true, ""));
        }
    }
}
