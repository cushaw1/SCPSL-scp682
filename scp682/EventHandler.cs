using System;
using Smod2;
using Smod2.EventHandlers;
using Smod2.Events;
using Smod2.API;
using System.Collections.Generic;

namespace scp_682
{
    class EventHandler : IEventHandlerPlayerDie, IEventHandlerPlayerHurt, IEventHandlerUpdate, IEventHandlerDoorAccess, IEventHandlerSpawn, IEventHandlerRoundEnd
    {
        private Plugin plugin;
        private Server server;
        private int time = 1;
        private bool enabled = true;
        private bool door = true;
        private bool kill = true;
        private int eat = 100;
        private int max = 2200;
        private int heal = 5;
        private int random = 30;
        public static List<string> scp682 = new List<string>();

        public EventHandler(Plugin plugin)
        {
            this.plugin = plugin;
            this.server = plugin.pluginManager.Server;
        }

        public void OnDoorAccess(PlayerDoorAccessEvent ev)
        {
            door = plugin.GetConfigBool("scp682_door");
            if (door == true && scp682.Contains(ev.Player.SteamId))
            {
                ev.Destroy = true;
            }
        }

        public void OnPlayerDie(PlayerDeathEvent ev)
        {
            if (enabled == true && ev.Player.TeamRole.Role == Role.SCP_939_89 )
            {
                if (scp682.Contains(ev.Player.SteamId))
                {
                    scp682.Remove(ev.Player.SteamId);
                    ev.Player.SetRank("white", " ");
                    plugin.Info("scp682 " +ev.Player.Name + " dead");
                }
            }
        }

        public void OnPlayerHurt(PlayerHurtEvent ev)
        {
            eat = plugin.GetConfigInt("scp682_eat_hp");
            kill = plugin.GetConfigBool("scp682_kill");
            max = plugin.GetConfigInt("scp682_heal_maxhp");
            if (scp682.Contains(ev.Attacker.SteamId) && ev.Player.TeamRole.Role != Role.SCP_939_89 && ev.DamageType != DamageType.NUKE)
            {
                if (kill == true)
                {
                    ev.Player.Kill(DamageType.SCP_939);
                }
                if (ev.Attacker.GetHealth() < max)
                {
                    ev.Attacker.AddHealth(eat);
                    plugin.Info("scp682 eat "+ ev.Player.Name);
                }
            }
        }

        public void OnSpawn(PlayerSpawnEvent ev)
        {
            enabled = plugin.GetConfigBool("scp682_enable");
            random = plugin.GetConfigInt("scp682_spawn");
            if (enabled == true && ev.Player.TeamRole.Role == Role.SCP_939_89)
            {
              int s = new Random().Next(0, 100);
              if (s <= random)
              {
                ev.Player.SetRank("red", "SCP-682");
                scp682.Add(ev.Player.SteamId);
                plugin.Info(ev.Player.Name + " became scp682");
               }
            }
        }
        DateTime updateTimer = DateTime.Now;
        public void OnUpdate(UpdateEvent ev)
        {
            enabled = plugin.GetConfigBool("scp682_enable");
            time = plugin.GetConfigInt("scp682_heal_time");
            heal = plugin.GetConfigInt("scp682_heal_hp");
            max = plugin.GetConfigInt("scp682_heal_maxhp");
            if (enabled == true && updateTimer < DateTime.Now)
            {
                updateTimer = DateTime.Now.AddSeconds(time);
                if (server.GetPlayers().Count > 0)
                {
                    server.GetPlayers().ForEach(a =>
                    {
                        if (scp682.Contains(a.SteamId) && a.GetHealth() < max)
                        {
                              a.AddHealth(heal);
                        }
                    });
                }
            }
        }
        public void OnRoundEnd(RoundEndEvent ev)
        {
            scp682.Clear();
        }
    }
}
