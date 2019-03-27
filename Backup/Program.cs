using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup
{
    class Program
    {
        static void Main(string[] args)
        {
            FlashMem flashMemory = new FlashMem();
            DVD unilateralDiskDVD = new DVD("Односторонний", TypeDVD.unilateral);
            DVD bilateralDiskDVD = new DVD("Двухсторонний", TypeDVD.bilateral);
            HDD removableHDD = new HDD("Samsung", 3, 400);

            Console.WriteLine(flashMemory.DeviceInfo());
            Console.WriteLine(unilateralDiskDVD.DeviceInfo());
            Console.WriteLine(bilateralDiskDVD.DeviceInfo());
            Console.WriteLine(removableHDD.DeviceInfo());

            File firstFile = new File();
            File secondFile = new File(512);
            File thirdFile = new File(1024);
            File fourthFile = new File(10240);
            File fifthfFle = new File(10240000);

            Console.WriteLine();

            Console.WriteLine(flashMemory.CopyTime(firstFile));
            Console.WriteLine(flashMemory.CopyTime(secondFile));
            Console.WriteLine(flashMemory.CopyTime(thirdFile));
            Console.WriteLine(flashMemory.CopyTime(fourthFile));
            Console.WriteLine(flashMemory.CopyTime(fifthfFle));

            flashMemory.CopyData(firstFile);
            unilateralDiskDVD.CopyData(thirdFile);
            bilateralDiskDVD.CopyData(fourthFile);
            removableHDD.CopyData(fourthFile);
            removableHDD.CopyData(fifthfFle);

            Console.WriteLine();

            Console.WriteLine(flashMemory.DeviceInfo());
            Console.WriteLine(unilateralDiskDVD.DeviceInfo());
            Console.WriteLine(bilateralDiskDVD.DeviceInfo());
            Console.WriteLine(removableHDD.DeviceInfo());


            Console.ReadLine();
        }
    }
}
