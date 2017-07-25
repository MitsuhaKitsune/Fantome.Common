using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fantome.Common
{
    public class PackageInfo
    {
        public string Name { get; private set; }
        public string Author { get; private set; }
        public string Version { get; private set; }
        public string Description { get; private set; }

        public PackageInfo(string name, string author, string version, string description)
        {
            this.Name = name;
            this.Author = author;
            this.Version = version;
            this.Description = description;
        }
    }
}
