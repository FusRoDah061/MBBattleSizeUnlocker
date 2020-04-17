using ModLib;
using System;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BattleSizeUnlocker
{
    public class Main : MBSubModuleBase
    {

        public const string ModuleId = "BattleSizeUnlocker";

        private static ModSettings _settings;

        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();

            try
            {
                FileDatabase.Initialise(ModuleId);

                _settings = FileDatabase.Get<ModSettings>(ModuleId);
                
                if (_settings == null) _settings = new ModSettings();

                SettingsDatabase.RegisterSettings(_settings);
                SettingsDatabase.SaveSettings(_settings);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        protected override void OnSubModuleUnloaded()
        {
            base.OnSubModuleUnloaded();

            try
            {
                SettingsDatabase.SaveSettings(_settings);
            }
            catch (Exception e)
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

    }
}
