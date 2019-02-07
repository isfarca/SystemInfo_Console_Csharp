using System;
using System.Management;

namespace SystemInfo
{
    public class GraphicsAdapterInfo
    {
        #region Properties

        public string Name { get; private set; }        
        public uint HorizontalResolution { get; private set; }
        public uint VerticalResolution { get; private set; }
        public uint BitsPerPixel { get; private set; }
        public uint RefreshRate { get; private set; }
        public string DriverVersion { get; private set; }        

        #endregion

        #region Constructor

        public GraphicsAdapterInfo()
        {
            Refresh();
        }

        #endregion

        #region Public Methods

        public void Refresh()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_VideoController");
            ManagementObjectCollection collection = searcher.Get();
            ManagementObjectCollection.ManagementObjectEnumerator enumerator = collection.GetEnumerator();

            if (!enumerator.MoveNext())
                return;

            ManagementBaseObject graphicsAdapter = enumerator.Current;

            this.Name = (string)graphicsAdapter["Name"];
            this.RefreshRate = (uint)graphicsAdapter["CurrentRefreshRate"];
            this.HorizontalResolution = (uint)graphicsAdapter["CurrentHorizontalResolution"];
            this.VerticalResolution = (uint)graphicsAdapter["CurrentVerticalResolution"];
            this.BitsPerPixel = (uint)graphicsAdapter["CurrentBitsPerPixel"];
            this.DriverVersion = (string)graphicsAdapter["DriverVersion"];
        }

        #endregion
    }

    public class ProcessorInfo
    {
        #region Enums

        public enum ProcessorArchitecture
        {
            x86 = 0,
            MIPS = 1,
            Alpha = 2,
            PowerPC = 3,
            Itanium = 6,
            x64 = 9
        }

        #endregion

        #region Properties

        public string Name { get; private set; }
        public string Manufacturer { get; private set; }
        public ProcessorArchitecture Architecture { get; private set; }        
        public uint Cores { get; private set; }
        public uint ClockSpeed { get; private set; }        
        public uint L2CacheSize { get; private set; }
        public uint L3CacheSize { get; private set; }
        public string Version { get; private set; }

        #endregion

        #region Constructor

        public ProcessorInfo()
        {
            Refresh();
        }

        #endregion

        #region Public Methods

        public void Refresh()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");
            ManagementObjectCollection collection = searcher.Get();
            ManagementObjectCollection.ManagementObjectEnumerator enumerator = collection.GetEnumerator();

            if (!enumerator.MoveNext())
                return;

            ManagementBaseObject processor = enumerator.Current;

            this.Name = (string)processor["Name"];
            this.Manufacturer = (string)processor["Manufacturer"];
            this.Architecture = (ProcessorArchitecture)Enum.Parse(typeof(ProcessorArchitecture), processor["Architecture"].ToString());
            this.Version = (string)processor["Version"];
            this.Cores = (uint)processor["NumberOfCores"];
            this.ClockSpeed = (uint)processor["CurrentClockSpeed"];            
            this.L2CacheSize = (uint)processor["L2CacheSize"];
            this.L3CacheSize = (uint)processor["L3CacheSize"];
        }

        #endregion
    }
}

    
