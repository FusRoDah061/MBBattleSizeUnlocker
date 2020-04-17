using ModLib;
using ModLib.Attributes;
using System.Xml.Serialization;

namespace BattleSizeUnlocker
{
    public class ModSettings : SettingsBase
	{
		private static ModSettings _instance;

		[XmlElement]
		public override string ID { get; set; } = Main.ModuleId;
		public override string ModuleFolderName => Main.ModuleId;
		public override string ModName => Main.ModuleId;

		[XmlElement]
		[SettingProperty("Battle size", 2, 2048, 2, 2048, "This setting will override the actual battle size setting for the game.")]
		public int CustomBattleSize { get; set; } = 500;

		public static ModSettings GetInstance()
		{
			if(_instance == null)
				_instance = (ModSettings) SettingsDatabase.GetSettings(Main.ModuleId);

			return _instance;
		}

	}
}
