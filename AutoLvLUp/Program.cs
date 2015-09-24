    using System.Linq;

namespace AutoSpellUp
{

    using System;
    using EloBuddy;
    using EloBuddy.SDK.Menu;
    using EloBuddy.SDK.Events;
    using EloBuddy.SDK.Menu.Values;


    internal class Program
        {

            public static int[] abilitySequence;
            public static int qOff = 0, wOff = 0, eOff = 0, rOff = 0;
            public static string tipo = "";
            private static SpellSlot Smite;
            private static SpellSlot Heal;
            public static Menu Menu;
            public static AIHeroClient _Player {get { return ObjectManager.Player; } }


        static void Main(string[] args)
            {
                Loading.OnLoadingComplete += Game_OnStart;
        }

            static void Game_OnStart(EventArgs args)
            {
                Menu = MainMenu.AddMenu("AutoLevelUp", "AutoLevelUp");

                Menu.AddGroupLabel("Dakota's AutoLevelUp");
                Menu.AddLabel(_Player.ChampionName+" loaded. Credits to AAc(L$$) and Miku for example script.");

                var Heal = Player.Spells.FirstOrDefault(o => o.SData.Name == "summonerHeal");
                var Smite = Player.Spells.FirstOrDefault(o => o.SData.Name == "summonerSmite");

            if (_Player.ChampionName == "Aatrox") abilitySequence = new int[] { 2, 1, 3, 2, 2, 4, 2, 3, 2, 3, 4, 3, 3, 1, 1, 4, 1, 1 };
                else if (_Player.ChampionName == "Ahri") abilitySequence = new int[] { 1, 3, 2, 1, 1, 4, 1, 2, 1, 2, 4, 2, 2, 3, 3, 4, 3, 3 };
                else if (_Player.ChampionName == "Akali") abilitySequence = new int[] { 1, 2, 3, 1, 1, 4, 1, 3, 1, 3, 4, 3, 3, 2, 2, 4, 2, 2 };
                else if (_Player.ChampionName == "Alistar") abilitySequence = new int[] { 3, 1, 2, 3, 3, 4, 3, 1, 3, 1, 4, 1, 1, 2, 2, 4, 2, 2 };
                else if (_Player.ChampionName == "Amumu") abilitySequence = new int[] { 3, 2, 1, 3, 3, 4, 3, 2, 3, 2, 4, 2, 2, 1, 1, 4, 1, 1 };
                else if (_Player.ChampionName == "Anivia") abilitySequence = new int[] { 1, 3, 2, 3, 3, 4, 3, 1, 3, 1, 4, 1, 1, 2, 2, 4, 2, 2 };
                else if (_Player.ChampionName == "Annie") abilitySequence = new int[] { 1, 2, 3, 1, 1, 4, 1, 2, 1, 2, 4, 2, 2, 3, 3, 4, 3, 3 };
                else if (_Player.ChampionName == "Ashe") abilitySequence = new int[] { 2, 1, 2, 3, 2, 4, 2, 1, 2, 1, 4, 1, 1, 3, 3, 4, 3, 3 };
                else if (_Player.ChampionName == "Azir") abilitySequence = new int[] { 2, 1, 3, 2, 2, 4, 1, 2, 2, 1, 4, 1, 3, 1, 3, 4, 3, 3 };
                else if (_Player.ChampionName == "Blitzcrank") abilitySequence = new int[] { 1, 3, 2, 1, 1, 4, 1, 3, 1, 3, 4, 3, 3, 2, 2, 4, 2, 2 };
                else if (_Player.ChampionName == "Brand") abilitySequence = new int[] { 2, 1, 3, 2, 2, 4, 2, 3, 2, 3, 4, 3, 3, 1, 1, 4, 1, 1 };
                else if (_Player.ChampionName == "Braum") abilitySequence = new int[] { 1, 3, 2, 1, 1, 4, 1, 3, 1, 3, 4, 3, 3, 2, 2, 4, 2, 2 };
                else if (_Player.ChampionName == "Caitlyn") abilitySequence = new int[] { 1, 2, 3, 1, 1, 4, 1, 3, 1, 3, 4, 3, 3, 2, 2, 4, 2, 2 };
                else if (_Player.ChampionName == "Cassiopeia") abilitySequence = new int[] { 1, 3, 3, 2, 3, 4, 3, 1, 3, 1, 4, 1, 1, 2, 2, 4, 2, 2 };
                else if (_Player.ChampionName == "Chogath") abilitySequence = new int[] { 1, 3, 2, 1, 1, 4, 1, 3, 1, 3, 4, 3, 3, 2, 2, 4, 2, 2 };
                else if (_Player.ChampionName == "Corki")
                {
                    if (_Player.PercentMagicDamageMod > _Player.PercentPhysicalDamageMod)
                    {
                        abilitySequence = new int[] { 1, 2, 3, 1, 1, 4, 1, 2, 1, 2, 4, 2, 2, 3, 3, 4, 3, 3 };
                        tipo = " AP";
                    }
                    else
                    {
                        abilitySequence = new int[] { 1, 2, 3, 1, 1, 4, 1, 3, 1, 3, 4, 3, 3, 2, 2, 4, 2, 2 };
                        tipo = " AD";
                    }
                }
                else if (_Player.ChampionName == "Darius") abilitySequence = new int[] { 1, 2, 3, 1, 1, 4, 1, 2, 1, 2, 4, 2, 2, 3, 3, 4, 3, 3 };
                else if (_Player.ChampionName == "Diana") abilitySequence = new int[] { 1, 2, 3, 1, 1, 4, 1, 2, 1, 2, 4, 2, 2, 3, 3, 4, 3, 3 };
                else if (_Player.ChampionName == "DrMundo") abilitySequence = new int[] { 1, 2, 3, 1, 1, 4, 1, 2, 1, 2, 4, 2, 2, 3, 3, 4, 3, 3 };
                else if (_Player.ChampionName == "Draven") abilitySequence = new int[] { 1, 2, 3, 1, 1, 4, 1, 2, 1, 2, 4, 2, 2, 3, 3, 4, 3, 3 };
                else if (_Player.ChampionName == "Elise")
                {
                    rOff = -1;
                    if (Smite != null && Smite.Slot !=  SpellSlot.Unknown)
                {
                    abilitySequence = new int[] { 2, 1, 3, 1, 1, 4, 1, 2, 1, 2, 4, 2, 2, 3, 3, 4, 3, 3 };
                    tipo = " Jungler";
                    }
                    else
                    {
                    abilitySequence = new int[] { 1, 2, 3, 1, 1, 4, 1, 2, 1, 2, 4, 2, 2, 3, 3, 4, 3, 3 };
                    tipo = " Lane";
                    }
                }
                else if (_Player.ChampionName == "Evelynn") abilitySequence = new int[] { 1, 3, 1, 2, 1, 4, 1, 3, 1, 3, 4, 3, 3, 2, 2, 4, 2, 2 };
                else if (_Player.ChampionName == "Ezreal")
                {
                    if (Heal != null && Heal.Slot != SpellSlot.Unknown)
                    {
                        abilitySequence = new int[] { 1, 3, 1, 2, 1, 4, 1, 3, 1, 3, 4, 3, 3, 2, 2, 4, 2, 2 };
                        tipo = " AD";
                    }
                    else
                    {
                        abilitySequence = new int[] { 1, 2, 3, 2, 2, 4, 2, 1, 2, 1, 4, 1, 1, 3, 3, 4, 3, 3 };
                        tipo = " AP";
                    }
                }
                else if (_Player.ChampionName == "Ekko") abilitySequence = new int[] { 1, 3, 2, 1, 1, 4, 1, 3, 1, 3, 4, 3, 3, 2, 2, 4, 2, 2 };
                else if (_Player.ChampionName == "FiddleSticks") abilitySequence = new int[] { 2, 3, 1, 2, 2, 4, 2, 1, 2, 1, 4, 1, 1, 3, 3, 4, 3, 3 };
                else if (_Player.ChampionName == "Fiora")
                {
                if (Smite != null && Smite.Slot != SpellSlot.Unknown)
                {
                    abilitySequence = new int[] { 3, 1, 2, 1, 1, 4, 1, 3, 1, 3, 4, 3, 3, 2, 2, 4, 2, 2 };
                    tipo = " Jungle";
                    }
                    else
                    {
                    abilitySequence = new int[] { 1, 2, 3, 1, 1, 4, 1, 3, 1, 3, 4, 3, 3, 2, 2, 4, 2, 2 };
                    tipo = " Lane";
                    }
                }
                else if (_Player.ChampionName == "Fizz") abilitySequence = new int[] { 1, 3, 2, 3, 3, 4, 3, 1, 3, 1, 4, 1, 1, 2, 2, 4, 2, 2 };
                else if (_Player.ChampionName == "Galio") abilitySequence = new int[] { 1, 3, 2, 1, 1, 4, 1, 3, 1, 3, 4, 3, 3, 2, 2, 4, 2, 2 };
                else if (_Player.ChampionName == "Gangplank") abilitySequence = new int[] { 1, 2, 3, 1, 1, 4, 1, 3, 1, 3, 4, 3, 3, 2, 2, 4, 2, 2 };
                else if (_Player.ChampionName == "Garen") abilitySequence = new int[] { 1, 3, 2, 3, 3, 4, 3, 1, 3, 1, 4, 1, 1, 2, 2, 4, 2, 2 };
                else if (_Player.ChampionName == "Gnar") abilitySequence = new int[] { 1, 2, 3, 1, 1, 4, 1, 2, 1, 2, 4, 2, 2, 3, 3, 4, 3, 3 };
                else if (_Player.ChampionName == "Gragas") abilitySequence = new int[] { 1, 3, 1, 2, 1, 4, 1, 2, 1, 2, 4, 2, 2, 3, 3, 4, 3, 3 };
                else if (_Player.ChampionName == "Graves") abilitySequence = new int[] { 1, 3, 2, 1, 1, 4, 1, 3, 1, 3, 4, 3, 3, 2, 2, 4, 2, 2 };
                else if (_Player.ChampionName == "Hecarim") abilitySequence = new int[] { 1, 2, 3, 1, 1, 4, 1, 2, 1, 2, 4, 2, 2, 3, 3, 4, 3, 3 };
                else if (_Player.ChampionName == "Heimerdinger") abilitySequence = new int[] { 1, 2, 3, 1, 1, 4, 1, 2, 1, 2, 4, 2, 2, 3, 3, 4, 3, 3 };
                else if (_Player.ChampionName == "Irelia") abilitySequence = new int[] { 3, 1, 2, 2, 2, 4, 2, 3, 2, 3, 4, 3, 3, 1, 1, 4, 1, 1 };
                else if (_Player.ChampionName == "Janna") abilitySequence = new int[] { 3, 1, 2, 3, 3, 4, 3, 1, 3, 1, 4, 1, 1, 3, 3, 4, 3, 3 };
                else if (_Player.ChampionName == "JarvanIV")
                {
                if (Smite != null && Smite.Slot != SpellSlot.Unknown)
                {
                    abilitySequence = new int[] { 3, 1, 2, 1, 1, 4, 1, 3, 1, 3, 4, 3, 3, 2, 2, 4, 2, 2 };
                    tipo = " Jungler";
                    }
                    else
                    {
                    abilitySequence = new int[] { 1, 3, 1, 2, 1, 4, 1, 3, 1, 3, 4, 3, 2, 3, 2, 4, 2, 2 };
                    tipo = " Lane";
                    }
                }
                else if (_Player.ChampionName == "Jax") abilitySequence = new int[] { 3, 1, 2, 2, 2, 4, 2, 3, 2, 3, 4, 3, 3, 1, 1, 4, 1, 1 };
                else if (_Player.ChampionName == "Jayce") { abilitySequence = new int[] { 1, 3, 2, 1, 1, 2, 1, 3, 1, 3, 1, 3, 3, 2, 2, 3, 2, 2 }; rOff = -1; }
                else if (_Player.ChampionName == "Jinx") abilitySequence = new int[] { 1, 2, 3, 1, 1, 4, 1, 2, 1, 2, 4, 2, 2, 3, 3, 4, 3, 3 };
                else if (_Player.ChampionName == "Karma") { abilitySequence = new int[] { 1, 3, 1, 2, 1, 4, 1, 2, 1, 2, 4, 2, 2, 3, 3, 4, 3, 3 }; rOff = -1; }
                else if (_Player.ChampionName == "Karthus") abilitySequence = new int[] { 1, 3, 2, 1, 1, 4, 1, 3, 1, 3, 4, 3, 3, 2, 2, 4, 2, 2 };
                else if (_Player.ChampionName == "Kassadin") abilitySequence = new int[] { 1, 2, 3, 1, 1, 4, 1, 3, 1, 3, 4, 3, 3, 2, 2, 4, 2, 2 };
                else if (_Player.ChampionName == "Katarina") abilitySequence = new int[] { 1, 3, 2, 1, 1, 4, 1, 2, 1, 2, 4, 2, 2, 3, 3, 4, 3, 3 };
                else if (_Player.ChampionName == "Kalista") abilitySequence = new int[] { 3, 1, 2, 3, 3, 4, 3, 1, 3, 1, 4, 1, 1, 2, 2, 4, 2, 2 };
                else if (_Player.ChampionName == "Kayle")
                {
                if (Smite != null && Smite.Slot != SpellSlot.Unknown)
                {
                    abilitySequence = new int[] { 3, 1, 2, 1, 1, 4, 1, 3, 1, 3, 4, 3, 3, 2, 2, 4, 2, 2 };
                    tipo = " Jungler";
                    }
                    else
                    {
                    abilitySequence = new int[] { 1, 3, 2, 1, 1, 4, 1, 3, 1, 3, 4, 3, 2, 3, 2, 4, 2, 2 };
                    tipo = " Lane";
                    }
                }
                else if (_Player.ChampionName == "Kennen") abilitySequence = new int[] { 2, 1, 3, 2, 2, 4, 2, 1, 2, 1, 4, 1, 1, 3, 3, 4, 3, 3 };
                else if (_Player.ChampionName == "Khazix") abilitySequence = new int[] { 1, 2, 3, 1, 1, 4, 1, 2, 1, 2, 4, 2, 2, 3, 3, 4, 3, 3 };
                else if (_Player.ChampionName == "KogMaw")
                {
                    if (Heal != null && Heal.Slot != SpellSlot.Unknown)
                    {
                        abilitySequence = new int[] { 2, 1, 3, 2, 2, 4, 2, 1, 2, 1, 4, 1, 1, 3, 3, 4, 3, 3 };
                        tipo = " AD";
                    }
                    else
                    {
                        abilitySequence = new int[] { 3, 2, 1, 3, 3, 4, 3, 1, 3, 1, 4, 1, 1, 2, 2, 4, 2, 2 };
                        tipo = " AP";
                    }
                }
                else if (_Player.ChampionName == "Leblanc") abilitySequence = new int[] { 1, 2, 3, 1, 1, 4, 1, 2, 1, 3, 4, 3, 3, 3, 2, 4, 2, 2 };
                else if (_Player.ChampionName == "LeeSin")
                {
                if (Smite != null && Smite.Slot != SpellSlot.Unknown)
                {
                    abilitySequence = new int[] { 1, 3, 2, 1, 1, 4, 1, 2, 1, 2, 4, 2, 2, 3, 3, 4, 3, 3 };
                    tipo = " Jungler";
                    }
                    else
                    {
                    abilitySequence = new int[] { 1, 2, 3, 1, 1, 4, 1, 3, 1, 3, 4, 3, 3, 2, 2, 4, 2, 2 };
                    tipo = " Lane";
                    }
                }
                else if (_Player.ChampionName == "Leona") abilitySequence = new int[] { 3, 1, 2, 2, 2, 4, 2, 3, 2, 3, 4, 3, 3, 1, 1, 4, 1, 1 };
                else if (_Player.ChampionName == "Lissandra") abilitySequence = new int[] { 1, 3, 2, 1, 1, 4, 1, 2, 1, 2, 4, 2, 2, 3, 3, 4, 3, 3 };
                else if (_Player.ChampionName == "Lucian") abilitySequence = new int[] { 1, 3, 2, 1, 1, 4, 1, 2, 1, 2, 4, 2, 2, 3, 3, 4, 3, 3 };
                else if (_Player.ChampionName == "Lulu") abilitySequence = new int[] { 1, 3, 2, 3, 3, 4, 3, 2, 3, 2, 4, 2, 2, 1, 1, 4, 1, 1 };
                else if (_Player.ChampionName == "Lux") abilitySequence = new int[] { 3, 1, 2, 3, 3, 4, 3, 1, 3, 1, 4, 1, 1, 2, 2, 4, 2, 2 };
                else if (_Player.ChampionName == "Malphite") abilitySequence = new int[] { 3, 1, 2, 3, 3, 4, 3, 2, 3, 2, 4, 2, 2, 1, 1, 4, 1, 1 };
                else if (_Player.ChampionName == "Malzahar") abilitySequence = new int[] { 1, 3, 2, 3, 3, 4, 3, 1, 3, 1, 4, 1, 1, 2, 2, 4, 2, 2 };
                else if (_Player.ChampionName == "Maokai")
                {
                if (Smite != null && Smite.Slot != SpellSlot.Unknown)
                {
                    abilitySequence = new int[] { 3, 2, 1, 1, 1, 4, 1, 2, 1, 2, 4, 2, 2, 3, 3, 4, 3, 3 };
                    tipo = " Jungler";
                    }
                    else
                    {
                    abilitySequence = new int[] { 3, 1, 2, 1, 1, 4, 1, 2, 1, 2, 4, 2, 2, 3, 3, 4, 3, 3 };
                    tipo = " Lane";
                    }
                }
                else if (_Player.ChampionName == "MasterYi") abilitySequence = new int[] { 1, 3, 2, 1, 1, 4, 1, 3, 1, 3, 4, 3, 3, 2, 2, 4, 2, 2 };
                else if (_Player.ChampionName == "MissFortune") abilitySequence = new int[] { 1, 2, 3, 2, 2, 4, 2, 1, 2, 1, 4, 1, 1, 3, 3, 4, 3, 3 };
                else if (_Player.ChampionName == "Mordekaiser") abilitySequence = new int[] { 3, 1, 2, 3, 3, 4, 3, 1, 3, 1, 4, 1, 1, 2, 2, 4, 2, 2 };
                else if (_Player.ChampionName == "Morgana") abilitySequence = new int[] { 1, 3, 2, 1, 1, 4, 1, 2, 1, 2, 4, 2, 2, 3, 3, 4, 3, 3 };
                else if (_Player.ChampionName == "Nami") abilitySequence = new int[] { 2, 1, 3, 1, 1, 4, 1, 3, 1, 3, 4, 3, 3, 2, 2, 4, 2, 2 };
                else if (_Player.ChampionName == "Nasus")
                {
                if (Smite != null && Smite.Slot != SpellSlot.Unknown)
                {
                    abilitySequence = new int[] { 3, 1, 2, 3, 3, 4, 3, 2, 3, 2, 4, 2, 1, 2, 1, 4, 1, 1 };
                    tipo = " Jungler";
                    }
                    else
                    {
                    abilitySequence = new int[] { 1, 2, 3, 1, 1, 4, 1, 2, 1, 2, 4, 2, 2, 3, 3, 4, 3, 3 };
                    tipo = " Lane";
                    }
                }
                else if (_Player.ChampionName == "Nautilus") abilitySequence = new int[] { 2, 3, 1, 3, 3, 4, 3, 2, 3, 2, 4, 2, 2, 1, 1, 4, 1, 1 };
                else if (_Player.ChampionName == "Nidalee") { abilitySequence = new int[] { 1, 3, 2, 1, 1, 4, 1, 3, 1, 3, 4, 3, 3, 2, 2, 4, 2, 2 }; rOff = -1; }
                else if (_Player.ChampionName == "Nocturne")
                {
                if (Smite != null && Smite.Slot != SpellSlot.Unknown)
                {
                    abilitySequence = new int[] { 1, 3, 2, 1, 1, 4, 1, 3, 1, 3, 4, 3, 2, 3, 2, 4, 2, 2 };
                    tipo = " Jungler";
                    }
                    else
                    {
                    abilitySequence = new int[] { 1, 3, 2, 1, 1, 4, 1, 3, 1, 3, 4, 3, 3, 2, 2, 4, 2, 2 };
                    tipo = " Lane";
                    }
                }
                else if (_Player.ChampionName == "Nunu")
                {
                if (Smite != null && Smite.Slot != SpellSlot.Unknown)
                {
                    abilitySequence = new int[] { 1, 3, 2, 3, 3, 4, 3, 2, 3, 2, 4, 2, 2, 1, 1, 4, 1, 1 };
                    tipo = " Jungler";
                    }
                    else
                    {
                    abilitySequence = new int[] { 3, 1, 2, 3, 3, 4, 3, 1, 3, 1, 4, 1, 1, 2, 2, 4, 2, 2 };
                    tipo = " Lane";
                    }
                }
                else if (_Player.ChampionName == "Olaf") abilitySequence = new int[] { 2, 1, 3, 3, 3, 4, 3, 1, 3, 1, 4, 1, 1, 2, 2, 4, 2, 2 };
                else if (_Player.ChampionName == "Orianna") abilitySequence = new int[] { 1, 2, 3, 1, 1, 4, 1, 2, 1, 2, 4, 2, 2, 3, 3, 4, 3, 3 };
                else if (_Player.ChampionName == "Pantheon") abilitySequence = new int[] { 1, 2, 3, 1, 1, 4, 1, 3, 1, 3, 4, 3, 3, 2, 2, 4, 2, 2 };
                else if (_Player.ChampionName == "Poppy") abilitySequence = new int[] { 2, 1, 3, 1, 1, 4, 1, 2, 1, 2, 4, 2, 2, 3, 3, 4, 3, 3 };
                else if (_Player.ChampionName == "Quinn") abilitySequence = new int[] { 1, 3, 2, 1, 1, 4, 1, 3, 1, 3, 4, 3, 3, 2, 2, 4, 2, 2 };
                else if (_Player.ChampionName == "Rammus") abilitySequence = new int[] { 2, 1, 3, 2, 3, 4, 2, 3, 3, 3, 4, 2, 2, 1, 1, 4, 1, 1 };
                else if (_Player.ChampionName == "Renekton") abilitySequence = new int[] { 2, 1, 3, 1, 1, 4, 1, 3, 1, 3, 4, 3, 3, 2, 2, 4, 2, 2 };
                else if (_Player.ChampionName == "Rengar")
                {
                if (Smite != null && Smite.Slot != SpellSlot.Unknown)
                {
                    abilitySequence = new int[] { 1, 2, 3, 1, 1, 4, 1, 3, 1, 3, 4, 3, 3, 2, 2, 4, 2, 2 };
                    tipo = " Jungler";
                    }
                    else
                    {
                    abilitySequence = new int[] { 1, 3, 2, 1, 1, 4, 1, 3, 1, 3, 4, 3, 3, 2, 2, 4, 2, 2 };
                    tipo = " Lane";
                    }
                }
                else if (_Player.ChampionName == "Riven")
                {
                if (Smite != null && Smite.Slot != SpellSlot.Unknown)
                {
                    abilitySequence = new int[] { 1, 2, 3, 1, 1, 4, 1, 3, 1, 3, 4, 3, 3, 2, 2, 4, 2, 2 };
                    tipo = " Jungler";
                    }
                    else
                    {
                    abilitySequence = new int[] { 1, 3, 2, 1, 1, 4, 1, 3, 1, 3, 4, 3, 3, 2, 2, 4, 2, 2 };
                    tipo = " Lane";
                    }
                }
                else if (_Player.ChampionName == "Rumble") abilitySequence = new int[] { 1, 3, 2, 1, 1, 4, 1, 3, 1, 3, 4, 3, 3, 2, 2, 4, 2, 2 };
                else if (_Player.ChampionName == "RekSai")
                {
                if (Smite != null && Smite.Slot != SpellSlot.Unknown)
                {
                    abilitySequence = new int[] { 1, 2, 3, 1, 1, 4, 1, 3, 1, 3, 4, 3, 3, 2, 2, 4, 2, 2 };
                    tipo = " Jungler";
                    }
                    else
                    {
                    abilitySequence = new int[] { 1, 2, 3, 1, 1, 4, 1, 3, 1, 3, 4, 3, 3, 2, 2, 4, 2, 2 };
                    tipo = " Lane";
                    }
                }
                else if (_Player.ChampionName == "Ryze") abilitySequence = new int[] { 1, 2, 3, 1, 1, 4, 1, 2, 1, 2, 4, 2, 2, 3, 3, 4, 3, 3 };
                else if (_Player.ChampionName == "Sejuani") abilitySequence = new int[] { 2, 3, 1, 2, 2, 4, 2, 1, 2, 3, 4, 3, 3, 3, 1, 4, 1, 1 };
                else if (_Player.ChampionName == "Shaco")
                {
                    if (_Player.PercentMagicDamageMod > _Player.PercentPhysicalDamageMod)
                    {
                        abilitySequence = new int[] { 2, 1, 3, 2, 2, 4, 2, 3, 2, 3, 4, 3, 3, 1, 1, 4, 1, 1 };
                        tipo = " AP";
                    }
                    else
                    {
                        abilitySequence = new int[] { 1, 3, 2, 1, 1, 4, 1, 3, 1, 3, 4, 3, 3, 2, 2, 4, 2, 2 };
                        tipo = " AD";
                    }
                }
                else if (_Player.ChampionName == "Shen") abilitySequence = new int[] { 1, 3, 2, 1, 1, 4, 1, 2, 1, 2, 4, 2, 2, 3, 3, 4, 3, 3 };
                else if (_Player.ChampionName == "Shyvana") abilitySequence = new int[] { 2, 1, 3, 2, 2, 4, 2, 3, 2, 3, 4, 3, 3, 1, 1, 4, 1, 1 };
                else if (_Player.ChampionName == "Singed") abilitySequence = new int[] { 1, 3, 2, 1, 1, 4, 1, 3, 1, 3, 4, 3, 3, 2, 2, 4, 2, 2 };
                else if (_Player.ChampionName == "Sion") abilitySequence = new int[] { 1, 2, 3, 1, 1, 4, 1, 2, 1, 2, 4, 2, 2, 3, 3, 4, 3, 3 };
                else if (_Player.ChampionName == "Sivir") abilitySequence = new int[] { 1, 2, 3, 1, 1, 4, 1, 2, 1, 2, 4, 2, 2, 3, 3, 4, 3, 3 };
                else if (_Player.ChampionName == "Skarner")
                {
                if (Smite != null && Smite.Slot != SpellSlot.Unknown)
                {
                    abilitySequence = new int[] { 1, 3, 2, 1, 1, 4, 1, 2, 1, 3, 4, 3, 2, 2, 3, 4, 3, 2 };
                    tipo = " Jungler";
                    }
                    else
                    {
                    abilitySequence = new int[] { 1, 2, 1, 2, 1, 4, 1, 2, 1, 2, 4, 2, 3, 3, 3, 4, 3, 3 };
                    tipo = " Lane";
                    }
                }
                else if (_Player.ChampionName == "Sona") abilitySequence = new int[] { 1, 2, 3, 1, 2, 4, 1, 2, 1, 2, 4, 1, 2, 3, 3, 4, 3, 3 };
                else if (_Player.ChampionName == "Soraka") abilitySequence = new int[] { 2, 1, 3, 2, 2, 4, 2, 1, 2, 1, 4, 1, 1, 3, 3, 4, 3, 3 };
                else if (_Player.ChampionName == "Swain") abilitySequence = new int[] { 1, 2, 3, 1, 1, 4, 1, 3, 1, 3, 4, 3, 3, 2, 2, 4, 2, 2 };
                else if (_Player.ChampionName == "Syndra") abilitySequence = new int[] { 1, 3, 2, 1, 1, 4, 1, 2, 1, 2, 4, 2, 2, 3, 3, 4, 3, 3 };
                else if (_Player.ChampionName == "Talon") abilitySequence = new int[] { 2, 3, 1, 2, 2, 4, 2, 1, 2, 1, 4, 1, 1, 3, 3, 4, 3, 3 };
                else if (_Player.ChampionName == "Taric") abilitySequence = new int[] { 3, 2, 1, 2, 2, 4, 2, 3, 2, 3, 4, 3, 3, 1, 1, 4, 1, 1 };
                else if (_Player.ChampionName == "TahmKench") abilitySequence = new int[] { 1, 2, 3, 1, 1, 4, 1, 2, 1, 2, 4, 2, 2, 3, 3, 4, 3, 3 };
                else if (_Player.ChampionName == "Teemo") abilitySequence = new int[] { 3, 1, 2, 3, 3, 4, 3, 1, 3, 1, 4, 1, 1, 2, 2, 4, 2, 2 };
                else if (_Player.ChampionName == "Thresh") abilitySequence = new int[] { 3, 1, 2, 3, 3, 4, 3, 1, 3, 1, 4, 1, 1, 2, 2, 4, 2, 2 };
                else if (_Player.ChampionName == "Tristana") abilitySequence = new int[] { 1, 3, 2, 1, 1, 4, 1, 3, 1, 3, 4, 3, 3, 2, 2, 4, 2, 2 };
                else if (_Player.ChampionName == "Trundle")
                {
                if (Smite != null && Smite.Slot != SpellSlot.Unknown)
                {
                    abilitySequence = new int[] { 1, 2, 3, 1, 1, 4, 1, 2, 1, 3, 4, 2, 2, 2, 3, 4, 3, 3 };
                    tipo = " Jungler";
                    }
                    else
                    {
                    abilitySequence = new int[] { 1, 2, 1, 3, 1, 4, 1, 2, 1, 2, 4, 2, 2, 3, 3, 4, 3, 3 };
                    tipo = " Lane";
                    }
                }
                else if (_Player.ChampionName == "Tryndamere") abilitySequence = new int[] { 3, 2, 1, 1, 1, 4, 1, 2, 1, 2, 4, 2, 2, 3, 3, 4, 3, 3 };
                else if (_Player.ChampionName == "TwistedFate")
                {
                if (Smite != null && Smite.Slot != SpellSlot.Unknown)
                {
                    abilitySequence = new int[] { 1, 2, 3, 1, 1, 4, 1, 2, 1, 2, 4, 2, 2, 3, 3, 4, 3, 3 };
                    
                    tipo = " AD";
                    }
                if (Heal != null && Heal.Slot != SpellSlot.Unknown)
                {
                    abilitySequence = new int[] { 1, 3, 1, 2, 1, 4, 1, 3, 1, 3, 4, 3, 3, 2, 2, 4, 2, 2 };
                    tipo = " AD";
                }
                else
                    {
                    abilitySequence = new int[] { 2, 3, 3, 2, 3, 4, 3, 2, 3, 2, 4, 2, 4, 4, 4, 4, 4, 4 };
                    tipo = " AP";
                    }
                }
                else if (_Player.ChampionName == "Twitch") abilitySequence = new int[] { 3, 2, 1, 3, 3, 4, 3, 1, 3, 1, 4, 1, 1, 2, 2, 4, 2, 2 };
                else if (_Player.ChampionName == "Udyr")
                {
                if (Smite != null && Smite.Slot != SpellSlot.Unknown)
                {
                    abilitySequence = new int[] { 4, 1, 3, 4, 4, 3, 4, 3, 4, 3, 3, 1, 1, 1, 1, 2, 2, 2 };
                    tipo = " Jungler";
                    }
                    else
                    {
                    abilitySequence = new int[] { 1, 2, 3, 1, 1, 3, 1, 2, 1, 2, 3, 2, 3, 3, 2, 4, 4, 4 };
                    tipo = " Lane";
                    }
                }
                else if (_Player.ChampionName == "Urgot") abilitySequence = new int[] { 3, 1, 2, 1, 1, 4, 1, 2, 1, 2, 4, 2, 2, 3, 3, 4, 3, 3 };
                else if (_Player.ChampionName == "Varus") abilitySequence = new int[] { 1, 2, 3, 1, 1, 4, 1, 2, 1, 2, 4, 2, 2, 3, 3, 4, 3, 3 };
                else if (_Player.ChampionName == "Vayne")
                {
                if (Smite != null && Smite.Slot != SpellSlot.Unknown)
                {
                    abilitySequence = new int[] { 2, 1, 3, 2, 2, 4, 2, 1, 2, 1, 4, 1, 1, 3, 3, 4, 3, 3 };
                    tipo = " Jungler";
                    }
                    else
                    {
                    abilitySequence = new int[] { 1, 3, 2, 2, 2, 4, 2, 1, 2, 1, 4, 1, 1, 3, 3, 4, 3, 3 };
                    tipo = " Lane";
                    }
                }
                else if (_Player.ChampionName == "Veigar") abilitySequence = new int[] { 1, 3, 2, 1, 1, 4, 1, 3, 1, 3, 4, 3, 3, 2, 2, 4, 2, 2 };
                else if (_Player.ChampionName == "Velkoz") abilitySequence = new int[] { 1, 2, 3, 1, 1, 4, 1, 2, 1, 2, 4, 2, 2, 3, 3, 4, 3, 3 };
                else if (_Player.ChampionName == "Vi")
                {
                if (Smite != null && Smite.Slot != SpellSlot.Unknown)
                {
                    abilitySequence = new int[] { 3, 1, 1, 2, 1, 4, 1, 2, 1, 2, 4, 2, 2, 3, 3, 4, 3, 3 };
                    tipo = " Jungler";
                    }
                    else
                    {
                    abilitySequence = new int[] { 3, 1, 1, 2, 1, 4, 1, 2, 1, 2, 4, 2, 2, 3, 3, 4, 3, 3 };
                    tipo = " Lane";
                    }
                }
                else if (_Player.ChampionName == "Viktor") abilitySequence = new int[] { 3, 1, 2, 3, 3, 4, 3, 1, 3, 1, 4, 1, 1, 2, 2, 4, 2, 2 };
                else if (_Player.ChampionName == "Vladimir") abilitySequence = new int[] { 1, 2, 3, 1, 1, 4, 1, 3, 1, 3, 4, 3, 3, 2, 2, 4, 2, 2 };
                else if (_Player.ChampionName == "Volibear") abilitySequence = new int[] { 2, 1, 3, 2, 2, 4, 2, 3, 2, 3, 4, 3, 3, 1, 1, 4, 1, 1 };
                else if (_Player.ChampionName == "Warwick") abilitySequence = new int[] { 1, 2, 3, 1, 1, 4, 1, 2, 1, 2, 4, 2, 2, 3, 3, 4, 3, 3 };
                else if (_Player.ChampionName == "MonkeyKing") abilitySequence = new int[] { 3, 1, 2, 1, 1, 4, 3, 1, 3, 1, 4, 3, 3, 2, 2, 4, 2, 2 };
                else if (_Player.ChampionName == "Xerath") abilitySequence = new int[] { 1, 3, 2, 1, 1, 4, 1, 2, 1, 2, 4, 2, 2, 3, 3, 4, 3, 3 };
                else if (_Player.ChampionName == "XinZhao")
                {
                if (Smite != null && Smite.Slot != SpellSlot.Unknown)
                {
                    abilitySequence = new int[] { 1, 2, 3, 1, 1, 4, 1, 3, 1, 2, 4, 2, 3, 2, 3, 4, 2, 3 };
                    tipo = " Jungler";
                    }
                    else
                    {
                    abilitySequence = new int[] { 1, 2, 3, 1, 1, 4, 1, 2, 1, 2, 4, 2, 2, 3, 3, 4, 3, 3 };
                    tipo = " Lane";
                    }
                }
                else if (_Player.ChampionName == "Yasuo") abilitySequence = new int[] { 1, 3, 2, 1, 1, 4, 1, 3, 1, 3, 4, 3, 3, 2, 2, 4, 2, 2 };
                else if (_Player.ChampionName == "Yorick") abilitySequence = new int[] { 2, 3, 1, 3, 3, 4, 3, 2, 3, 1, 4, 2, 1, 2, 1, 4, 2, 1 };
                else if (_Player.ChampionName == "Zac")
                {
                if (Smite != null && Smite.Slot != SpellSlot.Unknown)
                {
                    abilitySequence = new int[] { 2, 1, 3, 3, 1, 4, 3, 1, 3, 1, 4, 3, 1, 2, 2, 4, 2, 2 };
                    tipo = " Jungler";
                    }
                    else
                    {
                    abilitySequence = new int[] { 2, 3, 1, 2, 2, 4, 2, 3, 2, 3, 4, 3, 3, 1, 1, 4, 1, 1 };
                    tipo = " Lane";
                    }
                }
                else if (_Player.ChampionName == "Zed") abilitySequence = new int[] { 1, 2, 3, 1, 1, 4, 1, 3, 3, 1, 4, 3, 3, 2, 2, 4, 2, 2 };
                else if (_Player.ChampionName == "Ziggs") abilitySequence = new int[] { 1, 3, 2, 1, 1, 4, 1, 3, 1, 3, 4, 3, 3, 2, 2, 4, 2, 2 };
                else if (_Player.ChampionName == "Zilean") abilitySequence = new int[] { 1, 2, 3, 1, 1, 4, 1, 3, 1, 3, 4, 3, 3, 2, 2, 4, 2, 2 };
                else if (_Player.ChampionName == "Zyra") abilitySequence = new int[] { 3, 2, 1, 3, 1, 4, 3, 1, 3, 1, 4, 3, 1, 2, 2, 4, 2, 2 };

                Game.OnUpdate += Game_OnUpdate;
            }

            static void Game_OnUpdate(EventArgs args)
            { //AutoLevelup
                int qL = _Player.Spellbook.GetSpell(SpellSlot.Q).Level + qOff;
                int wL = _Player.Spellbook.GetSpell(SpellSlot.W).Level + wOff;
                int eL = _Player.Spellbook.GetSpell(SpellSlot.E).Level + eOff;
                int rL = _Player.Spellbook.GetSpell(SpellSlot.R).Level + rOff;
                if (qL + wL + eL + rL < ObjectManager.Player.Level)
                {
                    int[] level = new int[] { 0, 0, 0, 0 };
                    for (int i = 0; i < ObjectManager.Player.Level; i++)
                    {
                        level[abilitySequence[i] - 1] = level[abilitySequence[i] - 1] + 1;
                    }
                    if (qL < level[0]) ObjectManager.Player.Spellbook.LevelSpell(SpellSlot.Q);
                    if (wL < level[1]) ObjectManager.Player.Spellbook.LevelSpell(SpellSlot.W);
                    if (eL < level[2]) ObjectManager.Player.Spellbook.LevelSpell(SpellSlot.E);
                    if (rL < level[3]) ObjectManager.Player.Spellbook.LevelSpell(SpellSlot.R);

                }
            }
        }
    }
