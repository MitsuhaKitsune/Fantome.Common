using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Fantome.Common
{
    public abstract class Module
    {
        public readonly Settings.ModuleSettings Settings;

        public Module(Settings.ModuleSettings settings)
        {
            this.Settings = settings;
        }
        
        public abstract UserControl GetView();
    }

    //Example
    public class ModificationInstaller : Module
    {

        public ModificationInstaller(Settings.ModuleSettings settings) : base(settings)
        {
            //Do some stuff here
        }

        public override UserControl GetView()
        {
            // Create user control here..
            return null;
        }
    }
}
