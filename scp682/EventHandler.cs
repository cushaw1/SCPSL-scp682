using System;
using Smod2;
using Smod2.EventHandlers;
using Smod2.Events;
using Smod2.API;
using System.Collections.Generic;

namespace scp_682
{
    class EventHandler : IEventHandlerPlayerDie, IEventHandlerPlayerHurt, IEventHandlerUpdate, IEventHandlerDoorAccess, IEventHandlerSpawn, IEventHandlerRoundStart, IEventHandlerRoundEnd
    {
        private Plugin plugin;
        private Server server;
        private int time = 1;
        private bool enabled = true;
        private bool door = true;
        private int hp = 3000;
        private int attack = 300;
        private int eat = 100;
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
            if (enabled == true && door == true && scp682.Contains(ev.Player.SteamId) && ev.Player.TeamRole.Role == Role.SCP_939_89)
            {
                ev.Destroy = true;
            }
        }

        public void OnPlayerDie(PlayerDeathEvent ev)
        {
            if (enabled == true && ev.Player.TeamRole.Role == Role.SCP_939_89 && scp682.Contains(ev.Player.SteamId))
            {
               ev.Player.SetRank("white", " ");
               scp682.Remove(ev.Player.SteamId);
            }
        }

        public void OnPlayerHurt(PlayerHurtEvent ev)
        {
            if (enabled == true && scp682.Contains(ev.Player.SteamId) && ev.Attacker.TeamRole.Role == Role.SCP_939_89)
            {
                ev.Player.Damage(attack, DamageType.SCP_939);
                ev.Attacker.SetHealth(ev.Attacker.GetHealth() + eat, DamageType.SCP_939);
            }
        }

        public void OnSpawn(PlayerSpawnEvent ev)
        {
            if (enabled == true && ev.Player.TeamRole.Role == Role.SCP_939_89)
            {
              int s = new Random().Next(0, 100);
              if (s <= random)
              {
                ev.Player.SetHealth(hp, DamageType.SCP_939);
                ev.Player.SetRank("red", "SCP-682");
                scp682.Add(ev.Player.SteamId);
                }
            }
        }
        DateTime updateTimer = DateTime.Now;
        public void OnUpdate(UpdateEvent ev)
        {
            if (enabled == true && updateTimer < DateTime.Now)
            {
                updateTimer = DateTime.Now.AddSeconds(time);
                if (server.GetPlayers().Count > 0)
                {
                    server.GetPlayers().ForEach(a =>
                    {
                        if ((a.TeamRole.Team != Team.SCP && a.TeamRole.Team != Team.SPECTATOR) && scp682.Contains(a.SteamId))
                        {
                          if (hp < a.GetHealth())
                          a.SetHealth(a.GetHealth() + heal, DamageType.SCP_939);
                        }
                    });
                }
            }
        }

        public void OnRoundStart(RoundStartEvent ev)
        {
            scp682.Clear();
            enabled = plugin.GetConfigBool("scp682_enable");
            door = plugin.GetConfigBool("scp682_door");
            time = plugin.GetConfigInt("scp682_healtime");
            hp = plugin.GetConfigInt("scp682_hp");
            random = plugin.GetConfigInt("scp682_spawn");
            eat = plugin.GetConfigInt("scp682_eat");
            attack = plugin.GetConfigInt("scp682_attack") - 60;
        }

        public void OnRoundEnd(RoundEndEvent ev)
        {
            scp682.Clear();
        }
    }
}