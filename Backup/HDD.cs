using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup
{
    public class HDD : Storage
    {
        public int QuantitySections { get; set; }
        public int SectionsSize { get; set; }
        public int AllMemory { get; set; }
        public double Speed { get; set; }
        public int FilledMemory { get; set; }

        public HDD() :base("Съемный HDD","\"ПУСТО\"")
        {
            Speed = 50;
            QuantitySections = 1;
            SectionsSize = 1000 * MbInGb;
            AllMemory = QuantitySections * SectionsSize;
            FilledMemory = 0;
        }

        public HDD(string model,int quantitySections,int sectionSize) :base("Съемный HDD",model)
        {
            Speed = 50;
            QuantitySections = quantitySections;
            SectionsSize = sectionSize * MbInGb;
            AllMemory = QuantitySections * SectionsSize;
            FilledMemory = 0;
        }

        public override string DeviceInfo()
        {
            return $"{Name} {Model} объемом {AllMemory} МБ и скоростью {Speed} Мбайт/с заполнен на {FilledMemory} МБ";
        }

        public override int FreeMemory()
        {
            int freeMemory = AllMemory - FilledMemory;

            return freeMemory;
        }

        public override void CopyData(File file)
        {
            if (FilledMemory + file.Size <= AllMemory)
            {
                FilledMemory += file.Size;
            }
        }

        public override int CopyTime(File file)
        {
            return (int)(file.Size / Speed);
        }
    }
}
