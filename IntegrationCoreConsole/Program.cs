
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using Infra.IoC;


namespace IntegrationCoreConsole
{
    class Program
    {
        static ServiceCollection serviceCollection;
        static void Main(string[] args)
        {
            serviceCollection = new ServiceCollection();
            // This method is responsible for setting the services up globally
            serviceCollection.AddConfigureServices();

            try
            {
               Console.WriteLine("Hello,your application is working fine");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            


        }
    }
}


