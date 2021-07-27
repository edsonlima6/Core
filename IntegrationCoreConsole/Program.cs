using Dapper;
using Dapper.Contrib.Extensions;
using Domain.Context;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using InfraCoreDapper;
using InfraCoreEF.Db;
using Microsoft.Extensions.Configuration;
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
            

            try
            {
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            


        }
    }
}


