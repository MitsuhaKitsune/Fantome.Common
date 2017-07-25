using Fantome.Common.IO;
using System;
using System.Windows.Controls;

namespace Fantome.Common
{
    public abstract class Module : IDisposable
    {
        public abstract string Name { get; }

        public readonly Settings.ModuleSettings Settings;

        public Module(Settings.ModuleSettings settings)
        {
            this.Settings = settings;
        }

        public abstract void Dispose();

        public abstract UserControl GetView();
    }
}
