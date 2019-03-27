using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup
{
    public class FlashMem : Storage
    {
        public int AllMemory { get; set; }
        public int Speed { get; set; }
        public int FilledMemory { get; set; }

        public FlashMem() :base("Флешка","\"ПУСТО\"")
        {
            Speed = 480;
            AllMemory = 32 * MbInGb;
        }
        public FlashMem(string model, int allMemory) :base("Флешка",model)
        {
            Speed = 480;
            AllMemory = allMemory * MbInGb;
        }

        public override string DeviceInfo()
        {
            return $"{Name} {Model} объемом {AllMemory} МБ и скоростью {Speed} Мбайт/с заполнена на {FilledMemory} МБ";
        }

        public override int FreeMemory()
        {
            int freeMemory = AllMemory - FilledMemory;

            return freeMemory;
        }

        public override void CopyData(File file)
        {
            if(FilledMemory + file.Size <= AllMemory)
            {
                FilledMemory += file.Size;
            }
        }

        public override int CopyTime(File file)
        {
            return file.Size / Speed;
        }
    }
}
