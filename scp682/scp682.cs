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
    version = "1.4",
    SmodMajor = 3,
    SmodMinor = 1,
    SmodRevision = 19
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
            this.AddConfig(new Smod2.Config.ConfigSetting("scp682_enable", true, Smod2.Config.SettingType.BOOL, true, "682 plugin enable/disable"));
            this.AddConfig(new Smod2.Config.ConfigSetting("scp682_door", true, Smod2.Config.SettingType.BOOL, true, "682 destroy door enable/disable"));
            this.AddConfig(new Smod2.Config.ConfigSetting("scp682_kill", true, Smod2.Config.SettingType.BOOL, true, "682 kill human by one attack enable/disable"));
            this.AddConfig(new Smod2.Config.ConfigSetting("scp682_door_eat", true, Smod2.Config.SettingType.BOOL, true, "682 destroy door when 682 eat hunman enable/disable"));
            this.AddConfig(new Smod2.Config.ConfigSetting("scp682_spawn", 30, Smod2.Config.SettingType.NUMERIC, true, "	682 spawn probability(%)"));
            this.AddConfig(new Smod2.Config.ConfigSetting("scp682_door_chance", 100, Smod2.Config.SettingType.NUMERIC, true, "	682 destroy door probability(%)"));
            this.AddConfig(new Smod2.Config.ConfigSetting("scp682_heal_hp",5, Smod2.Config.SettingType.NUMERIC, true, "682 automatic heal hp"));
            this.AddConfig(new Smod2.Config.ConfigSetting("scp682_heal_time", 1, Smod2.Config.SettingType.NUMERIC, true, "682 automatic heal time(s)"));
            this.AddConfig(new Smod2.Config.ConfigSetting("scp682_heal_maxhp", 2200, Smod2.Config.SettingType.NUMERIC, true, "682 heal max HP"));
            this.AddConfig(new Smod2.Config.ConfigSetting("scp682_eat_hp", 100, Smod2.Config.SettingType.NUMERIC, true, "682 heal HP with eat human"));
        }
    }
}
