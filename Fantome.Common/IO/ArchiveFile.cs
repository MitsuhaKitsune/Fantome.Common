using Ionic.Zip;
using Newtonsoft.Json;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace Fantome.Common.IO
{
    public class ArchiveFile
    {
        public ZipFile Archive { get; private set; }
        public ArchiveFile(string fileLocation)
        {
            this.Archive = new ZipFile(fileLocation);
        }

        public PackageInfo GetPackageInfo()
        {
            if(this.Archive.EntryFileNames.Contains("_meta/info.json"))
            {
                return JsonConvert.DeserializeObject<PackageInfo>(new StreamReader(this.Archive.Entries.First(x => x.FileName == "_meta/info.json").InputStream).ReadToEnd());
            }
            else
            {
                return new PackageInfo("NULL", "", "", "");
            }
        }

        public Image GetPackageImage()
        {
            if (this.Archive.EntryFileNames.Contains("_meta/iamge.png"))
            {
                return Image.FromStream(this.Archive.Entries.First(x => x.FileName == "_meta/image.png").InputStream);
            }
            else
            {
                return null;
            }
        }

        public static void CreateArchive(string directory, string location, PackageInfo packageInfo)
        {
            string packageInfoJson = JsonConvert.SerializeObject(packageInfo, Formatting.Indented);

            ZipFile zip = new ZipFile();
            zip.AddDirectory(directory);
            zip.AddEntry("_meta/info.json", Encoding.ASCII.GetBytes(packageInfoJson));
            zip.Save(location);
        }

        public static void CreateArchive(string directory, string location, PackageInfo packageInfo, string imageLocation)
        {
            string packageInfoJson = JsonConvert.SerializeObject(packageInfo, Formatting.Indented);

            ZipFile zip = new ZipFile();
            zip.AddDirectory(directory);
            zip.AddEntry("_meta/info.json", Encoding.ASCII.GetBytes(packageInfoJson));
            zip.AddFile(imageLocation, "_meta");
            zip.Save(location);
        }
    }
}
