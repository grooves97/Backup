using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup
{
    public abstract class Storage
    {
        protected const int MbInGb = 1024;
        public string Name { get; set; }
        public string Model { get; set; }

        public Storage(string name,string model)
        {
            Name = name;
            Model = model;
        }

        public abstract void CopyData(File file);
        public abstract int FreeMemory();
        public abstract string DeviceInfo();
        public abstract int CopyTime(File file);

    }
}
