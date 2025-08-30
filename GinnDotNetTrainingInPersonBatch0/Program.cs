using System;
using GinnDotNetTrainingInPersonBatch0.ConsoleApp;

namespace GinnDotNetTrainingInPersonBatch0.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // AdoDotNetService ရဲ့ instance ကိုဆောက်ပါမယ်
            AdoDotNetService adoService = new AdoDotNetService();

            // Read method ကိုခေါ်ပါမယ်
            Console.WriteLine("ဒေတာဖတ်နေပါတယ်...");
            adoService.Read();

            // Create method ကိုခေါ်ပါမယ်
            Console.WriteLine("အချက်အလက်အသစ်ထည့်နေပါတယ်...");
            adoService.Create();

            // Update method ကိုခေါ်ပါမယ်
            Console.WriteLine("အချက်အလက်ပြင်ဆင်နေပါတယ်...");
            adoService.Update();

            // Delete method ကိုခေါ်ပါမယ်
            Console.WriteLine("အချက်အလက်ဖျက်နေပါတယ်...");
            adoService.Delete();

            Console.ReadLine();
        }
    }
}