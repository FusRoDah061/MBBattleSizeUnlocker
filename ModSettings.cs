using System;
using System.Collections.Generic;
using System.IO;
using TaleWorlds.Engine;

namespace BattleSizeUnlocker
{
    class ModSettings
	{
		private const int KEY = 0;
		private const int VALUE = 1;

		private const string CUSTOM_BATTLE_SIZE_KEY = "CustomBattleSize";

		private string _configFile;

		private static ModSettings _instance = null;

		public int CustomBattleSize { get; set; } = 500;

		public static ModSettings GetInstance()
		{
			if (_instance == null)
				_instance = new ModSettings();

			return _instance;
		}

        private ModSettings()
        {
			_configFile = Utilities.GetConfigsPath() + "BannerlordModConfig.txt";
			LoadSettings();
		}

		public void LoadSettings()
		{
			Console.WriteLine("Loading BattleSizeUnlocker mod settings");

			if (_configFile == null)
			{
				Console.WriteLine("BattleSizeUnlocker mod settings file path is null!");
				return;
			}

			if (!File.Exists(_configFile))
				SaveSettings();

			StreamReader streamReader = new StreamReader(_configFile);
			string text = streamReader.ReadToEnd();
			streamReader.Close();

			if (String.IsNullOrEmpty(text))
				SaveSettings();

			Dictionary<string, string> settings = new Dictionary<string, string>();
			string[] lines = text.Split('\n');

			foreach (string line in lines)
			{
				string[] keyValuePair = line.Split('=');

				if (keyValuePair[KEY] != null)
				{
					settings.Add(keyValuePair[KEY], keyValuePair[VALUE]);
				}
			}

			if (settings.Count <= 0 && !settings.ContainsKey(CUSTOM_BATTLE_SIZE_KEY))
				SaveSettings();

			this.fromDict(settings);

			Console.WriteLine("Finished loading BattleSizeUnlocker mod settings");
		}

		public void SaveSettings()
		{
			Console.WriteLine("Saving BattleSizeUnlocker mod settings");

			try
			{
				string text = $"{CUSTOM_BATTLE_SIZE_KEY}={CustomBattleSize}";
				File.WriteAllText(_configFile, text);

				Console.WriteLine($"Written the following to {_configFile}:");
				Console.WriteLine(text);
			}
			catch
			{
				Console.WriteLine("Could not create BattleSizeUnlocker mod config file");
			}

			Console.WriteLine("Finished saving BattleSizeUnlocker mod settings");
		}

		public Dictionary<string, string> toDict()
        {
            return new Dictionary<string, string>
            {
                { CUSTOM_BATTLE_SIZE_KEY, CustomBattleSize.ToString() }
            };
        }

        public void fromDict(Dictionary<string, string> dict)
        {
            this.CustomBattleSize = Int32.Parse(dict[CUSTOM_BATTLE_SIZE_KEY]);
        }
    }
}
