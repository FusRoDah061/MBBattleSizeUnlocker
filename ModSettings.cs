using ModLib.Definitions;
using ModLib.Definitions.Attributes;
using System.Xml.Serialization;

namespace BattleSizeUnlocker
{
    public class ModSettings : SettingsBase
	{

		[XmlElement]
		public override string ID { get; set; } = Main.ModuleId;
		public override string ModuleFolderName => Main.ModuleId;
		public override string ModName => Main.ModuleId;

		[XmlElement]
		[SettingProperty("Battle size", 2, 2048, 2, 2048, "This setting will override the actual battle size setting for the game.")]
		public int CustomBattleSize { get; set; } = 500;

		public static ModSettings Instance
		{
			get
			{
				return (ModSettings)SettingsDatabase.GetSettings<ModSettings>();
			}
		}

	}
}
