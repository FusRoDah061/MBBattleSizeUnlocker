using System;
using System.Collections.Generic;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BattleSizeUnlocker
{
    public class Main : MBSubModuleBase
    {

        private static ModSettings _settings;

        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();
            _settings = ModSettings.GetInstance();
        }

        protected override void OnSubModuleUnloaded()
        {
            base.OnSubModuleUnloaded();

            try
            {
                _settings.SaveSettings();
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public override void OnMissionBehaviourInitialize(Mission mission)
        {
            base.OnMissionBehaviourInitialize(mission);

            if(mission.IsFieldBattle == true)
                BannerlordConfig.BattleSize = _settings.CustomBattleSize;
        }

        protected override void OnGameStart(Game game, IGameStarter gameStarterObject)
        {
            base.OnGameStart(game, gameStarterObject);
            BannerlordConfig.BattleSize = _settings.CustomBattleSize;
        }

        //Depends on this mod to manage the options menu:
        //https://www.nexusmods.com/mountandblade2bannerlord/mods/504
        public static Dictionary<string, string> GetModSettingValue()
        {
            // write to get settings as Dictionary from anywhere you want
            //this method will be called when the player opens the settings screen to get your settings values 

            try
            {
                return _settings.toDict();
            }
            catch(NullReferenceException e)
            {
                Console.WriteLine(e.ToString());
            }

            return new Dictionary<string, string>();
		}

		public static void SaveModSettingValue(Dictionary<string, string> newSettings)
        {
            // write to save settings to anywhere you want
            //this method will be called when the player clicks on Done button in the settings screen
            try
            {
                _settings.fromDict(newSettings);
                _settings.SaveSettings();
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
