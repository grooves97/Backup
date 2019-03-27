using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup
{
    public enum TypeDVD
    {
        unilateral = 4812,
        bilateral = 9216
    }

    public class DVD : Storage
    {
        public TypeDVD TypeDVD { get; set; }
        public int AllMemory { get; set; }
        public double Speed { get; set; }
        public int FilledMemory { get; set; }

        public DVD() :base("DVD диск","\"ПУСТО\"")
        {
            TypeDVD = TypeDVD.unilateral;
            Speed = 1.32; // Mбайт/с
            AllMemory = (int)TypeDVD.unilateral;
            FilledMemory = 0;
        }

        public DVD(string model, TypeDVD typeDVD) : base("DVD диск", model)
        {
            TypeDVD = typeDVD;
            Speed = 1.32;
            AllMemory = (int)TypeDVD;
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
