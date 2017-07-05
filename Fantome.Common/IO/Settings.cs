using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Fantome.Common.IO
{
    public class Settings
    {
        public readonly List<ModuleSettings> Entries;

        public Settings()
        {
            this.Entries = new List<ModuleSettings>();
        }

        public Settings(String location)
        {
            this.Entries = JsonConvert.DeserializeObject<List<ModuleSettings>>(File.ReadAllText(location));
        }

        public void Save(String location)
        {
            File.WriteAllText(location, JsonConvert.SerializeObject(this.Entries, Formatting.Indented));
        }

        public void AddModuleSettings(string moduleName)
        {
            if (this.GetModuleSettings(moduleName) != null)
            {
                throw new ModuleSettingsAlreadyExistingException(moduleName);
            }
            this.Entries.Add(new ModuleSettings(this, moduleName));
        }

        public ModuleSettings GetModuleSettings(string moduleName)
        {
            return this.Entries.Find(x => String.Equals(moduleName, x.ModuleName, StringComparison.InvariantCultureIgnoreCase));
        }

        public class ModuleSettings
        {
            public readonly Settings ParentSettings;
            public readonly string ModuleName;
            public readonly Dictionary<String, object> Entries = new Dictionary<String, object>();

            public ModuleSettings(Settings parentSettings, string moduleName)
            {
                this.ParentSettings = parentSettings;
                this.ModuleName = moduleName;
            }
        }

        public class ModuleSettingsAlreadyExistingException : Exception
        {
            public ModuleSettingsAlreadyExistingException(string moduleName) : base(moduleName + " already has settings") { }
        }
    }
}
