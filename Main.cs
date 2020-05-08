using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BattleSizeUnlocker
{
    public class Main : MBSubModuleBase
    {

        public const string ModuleId = "BattleSizeUnlocker";

        private static ModSettings _settings;

        protected override void OnBeforeInitialModuleScreenSetAsRoot()
        {
            base.OnBeforeInitialModuleScreenSetAsRoot();
            _settings = ModSettings.Instance;

            if(_settings != null)
                BannerlordConfig.BattleSize = _settings.CustomBattleSize;
        }

        public override void OnMissionBehaviourInitialize(Mission mission)
        {
            base.OnMissionBehaviourInitialize(mission);

            if(mission.IsFieldBattle == true && _settings != null)
                BannerlordConfig.BattleSize = _settings.CustomBattleSize;
        }

        protected override void OnGameStart(Game game, IGameStarter gameStarterObject)
        {
            base.OnGameStart(game, gameStarterObject);
           
            if (_settings != null)
                BannerlordConfig.BattleSize = _settings.CustomBattleSize;
        }

    }
}
