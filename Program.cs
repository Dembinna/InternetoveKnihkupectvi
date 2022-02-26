using System;

namespace InternetoveKnihkupectvi
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            var store = ModelStore.LoadFrom(Console.In);
            var controller = new Controller(store, new View());
            if (store == null)
            {
                Console.WriteLine("Data error.");

            }
            else
            {

                while ((line = Console.ReadLine()) != null)
                {
                    controller.HandleEx(line);  
                }
            }
        }
    }
}
