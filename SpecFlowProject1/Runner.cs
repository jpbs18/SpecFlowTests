using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1
{
    [Binding]
    public class Runner
    {
        public static IConfigurationRoot? configurationRoot;


        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            string path = "C:\\Users\\João\\Desktop\\Programação\\ASP-MVS\\SpecFlowProject1\\SpecFlowProject1\\jsconfig.json";
            ConfigurationBuilder configBuilder = new ConfigurationBuilder();
            configurationRoot = configBuilder.AddJsonFile(path).Build();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            Console.WriteLine("After Test Run");
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext context)
        {
            Console.WriteLine("After feauture");
            Console.WriteLine(context.FeatureInfo.Title);
        }

        [AfterFeature]
        public static void AfterFeature(FeatureContext context)
        {
            Console.WriteLine("After feauture");
        }
    }
}
