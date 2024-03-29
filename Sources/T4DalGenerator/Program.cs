﻿using CRUDAPI.DataModel;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using CRUDAPI.Generators;
using CRUDAPI.Settings;
using CRUDAPI.Generator;
using CRUDAPI.Interfaces;

namespace T4DalGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Reading config...");

                var config = PrepareConfig(args[0]);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("DONE");

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Reading data model...");

                ModelExtractorParams initParams = new ModelExtractorParams();
                var settings = config.GetSection("DalCreatorSettings").Get<DalCreatorSettings>();
                initParams.ConnectionString = settings.ConnectionString;

                ModelExtractor extractor = new ModelExtractor();
                extractor.Init(initParams);
                var tables = extractor.GetModel().Tables;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("DONE");

                var timestamp = DateTime.Now;

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Preparing output folder...");

                PrepareSolutionsFolder(settings, timestamp);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Preparing output folder...DONE");

                Generate<StorProcsGenerator>(tables, settings, timestamp);
                Generate<DalsGeneratorBase>(tables, settings, timestamp);
                Generate<EntitiesGenerator>(tables, settings, timestamp);
                Generate<SQLDalGenerator>(tables, settings, timestamp);
                Generate<SQLDalTestGenerator>(tables, settings, timestamp);

                Generate<EFModelGenerator>(tables, settings, timestamp);
                Generate<EFDalGenerator>(tables, settings, timestamp);
                Generate<EFEntityConvertorGenerator>(tables, settings, timestamp);
                GenerateSingle<EFContextGenerator>(tables, settings, timestamp);

                Generate<DtosGenerator>(tables, settings, timestamp);
                Generate<ServiceDalsGeneratorBase>(tables, settings, timestamp);
                Generate<ServiceDalsImplGenerator>(tables, settings, timestamp);
                Generate<ConvertorsGenerator>(tables, settings, timestamp);
                Generate<EntityControllerGenerator>(tables, settings, timestamp);
                GenerateSingle<StartupGenerator>(tables, settings, timestamp);
                GenerateSingle<SlnFileGenerator>(tables, settings, timestamp);
                Generate<ControllerTestGenerator>(tables, settings, timestamp);

                Generate<EntityFunctionGenerator>(tables, settings, timestamp);
                Generate<FunctionsTestsGenerator>(tables, settings, timestamp);

                Generate<JsDtosGenerator>(tables, settings, timestamp);
                Generate<JsClientDalGenerator>(tables, settings, timestamp);
                Generate<JsEntitiesListsUIGenerator>(tables, settings, timestamp);
                Generate<JsEntityUIGenerator>(tables, settings, timestamp);
                GenerateSingle<JsDtosIndexGenerator>(tables, settings, timestamp);
                GenerateSingle<PostmanCollectionGenerator>(tables, settings, timestamp);
                GenerateSingle<JsAppGenerator>(tables, settings, timestamp);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("SUCCESS! ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Result: 'Output\\{timestamp.ToString("yyyy-MM-dd HH-mm-ss")}' - Press Enter to close");
            }
            catch(Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Exception: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
            }
            Console.ReadLine();

        }

        private static IList<string> Generate<TGenerator>(  IList<CRUDAPI.DataModel.DataTable> tables, 
                                                            DalCreatorSettings settings, 
                                                            DateTime timestamp) where TGenerator : IGenerator
        {

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"Running {typeof(TGenerator).ToString()} ...");

            List<string> result = new List<string>();
            var genParams = new CRUDAPI.Generators.GeneratorParams()
            {
                Settings = settings,
                Timestamp = timestamp,
                Tables = tables
            };

            var generator = (TGenerator)Activator.CreateInstance(typeof(TGenerator), new object[] { genParams });

            foreach (var t in tables)
            {
                if (t.Name.IndexOf("sys") != 0)
                {
                    genParams.Table = t;
                    var files = generator.Generate();
                    result.AddRange(files);
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("DONE");

            return result;
        }

        private static IList<string> GenerateSingle<TGenerator>(IList<CRUDAPI.DataModel.DataTable> tables, DalCreatorSettings settings, DateTime timestamp) where TGenerator : IGenerator
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"Running {typeof(TGenerator).ToString()} ...");

            List<string> result = new List<string>();
            var genParams = new CRUDAPI.Generators.GeneratorParams()
            {
                Settings = settings,
                Timestamp = timestamp,
                Tables = tables
            };

            var generator = (TGenerator)Activator.CreateInstance(typeof(TGenerator), new object[] { genParams });

            var files = generator.Generate();
            result.AddRange(files);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("DONE");

            return result;
        }

        private static IConfigurationRoot PrepareConfig(string cfgFile)
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var builder = new ConfigurationBuilder()
                .AddJsonFile($"{cfgFile}", true, true)
                .AddJsonFile($"appsettings.{env}.json", true, true)
                .AddEnvironmentVariables();

            var config = builder.Build();

            return config;
        }

        private static void PrepareSolutionsFolder(DalCreatorSettings settings, DateTime timestamp)
        {
            string srcFolder = settings.SolutionTemplate;
            string destFolder = Path.Combine(settings.OutputRoot, timestamp.ToString("yyyy-MM-dd HH-mm-ss"));

            CopyFilesRecursively(srcFolder, destFolder, settings);
        }

        private static void CopyFilesRecursively(string sourcePath, string targetPath, DalCreatorSettings settings)
        {
            //Now Create all of the directories
            foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"Copy folder: {dirPath} ...");

                string destDir = dirPath.Replace(sourcePath, targetPath);
                destDir = destDir.Replace(settings.TemplateNamespace, settings.RootNamespace);

                Directory.CreateDirectory(destDir);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("DONE");
            }

            //Copy all the files & Replaces any files with the same name
            foreach (string srcPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"Copy file: {srcPath} ...");

                string newPath = srcPath.Replace(sourcePath, targetPath).Replace(settings.TemplateNamespace, settings.RootNamespace);

                string fileContent = File.ReadAllText(srcPath);
                fileContent = fileContent.Replace(settings.TemplateNamespace, settings.RootNamespace);

                File.WriteAllText(newPath, fileContent, System.Text.Encoding.UTF8);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("DONE");
            }
        }
    }
}
