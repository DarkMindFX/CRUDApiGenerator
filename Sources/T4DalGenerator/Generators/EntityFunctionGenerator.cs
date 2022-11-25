using CRUDAPI.DataModel;
using CRUDAPI.Generators;
using CRUDAPI.Template.NET.Functions;
using System.Collections.Generic;
using System.IO;

namespace CRUDAPI.Generators
{
    public class EntityFunctionGenerator : GeneratorBase
    {
        public EntityFunctionGenerator(GeneratorParams genParams) : base(genParams)
        {
        }

        public override IList<string> Generate()
        {
            IList<string> files = new List<string>();

            var modelHelper = new ModelHelper();

            string rootFolder = GetOutputFolder();

            files.Add(GenerateFunctionProjFile(rootFolder, modelHelper));
            files.Add(GenerateHostJsonFile(rootFolder, modelHelper));
            files.Add(GenerateLocalSettingsJsonFile(rootFolder, modelHelper));
            files.Add(GenerateStartup(rootFolder, modelHelper));
            files.Add(GenerateResourcesResx(rootFolder, modelHelper));
            files.Add(GenerateResourcesDesigner(rootFolder, modelHelper));
            files.Add(GenerateLaunchSettings(rootFolder, modelHelper));
            files.Add(GenerateServiceDependencies(rootFolder, modelHelper));
            files.Add(GenerateServiceDependenciesLocal(rootFolder, modelHelper));

            files.Add(GenerateDelete(rootFolder, modelHelper));
            files.Add(GenerateGetAll(rootFolder, modelHelper));
            files.Add(GenerateGetDetails(rootFolder, modelHelper));
            files.Add(GenerateInsert(rootFolder, modelHelper));
            files.Add(GenerateUpdate(rootFolder, modelHelper));
            if(_genParams.Settings.IsSoftDelete && _genParams.Table.HasColumn(_genParams.Settings.SoftDeleteField))
            {
                files.Add(GenerateErase(rootFolder, modelHelper));
            }

            return files;
        }


        private string GenerateFunctionProjFile(string rootFolder, ModelHelper modelHelper)
        {
            string fileName = $"{string.Format(_genParams.Settings.FunctionProjectNameTemplate, _genParams.Table.Name)}.csproj";
            string fileOut = Path.Combine(rootFolder, fileName);

            var template = new FunctionCsprojTemplate();
            template.Session = new Dictionary<string, object>();

            template.Session["RootNamespace"] = _genParams.Settings.RootNamespace;
            template.Session["table"] = _genParams.Table;
            template.Session["modelHelper"] = modelHelper;
            template.Initialize();

            string content = template.TransformText();

            File.WriteAllText(fileOut, content);

            return fileOut;
        }

        private string GenerateHostJsonFile(string rootFolder, ModelHelper modelHelper)
        {
            string fileName = $"host.json";
            string fileOut = Path.Combine(rootFolder, fileName);

            var template = new HostJosnTemplate();
            template.Session = new Dictionary<string, object>();

            template.Session["RootNamespace"] = _genParams.Settings.RootNamespace;
            template.Session["table"] = _genParams.Table;
            template.Session["modelHelper"] = modelHelper;
            template.Initialize();

            string content = template.TransformText();

            File.WriteAllText(fileOut, content);

            return fileOut;
        }

        private string GenerateLocalSettingsJsonFile(string rootFolder, ModelHelper modelHelper)
        {
            string fileName = $"local.settings.json";
            string fileOut = Path.Combine(rootFolder, fileName);

            var template = new LocalSettingsJsonTemplate();
            template.Session = new Dictionary<string, object>();

            template.Session["RootNamespace"] = _genParams.Settings.RootNamespace;
            template.Session["table"] = _genParams.Table;
            template.Session["modelHelper"] = modelHelper;
            template.Initialize();

            string content = template.TransformText();

            File.WriteAllText(fileOut, content);

            return fileOut;
        }

        private string GenerateStartup(string rootFolder, ModelHelper modelHelper)
        {
            string fileName = $"Startup.cs";
            string fileOut = Path.Combine(rootFolder, fileName);

            var template = new StartupTemplate();
            template.Session = new Dictionary<string, object>();

            template.Session["RootNamespace"] = _genParams.Settings.RootNamespace;
            template.Session["table"] = _genParams.Table;
            template.Session["modelHelper"] = modelHelper;
            template.Initialize();

            string content = template.TransformText();

            File.WriteAllText(fileOut, content);

            return fileOut;
        }

        private string GenerateResourcesResx(string rootFolder, ModelHelper modelHelper)
        {
            string fileName = $"Resources.resx";
            rootFolder = Path.Combine(rootFolder, "Properties");
            if(!Directory.Exists(rootFolder))
            {
                Directory.CreateDirectory(rootFolder);
            }
            string fileOut = Path.Combine(rootFolder, fileName);

            var template = new ResourcesResxTemplate();
            template.Session = new Dictionary<string, object>();

            template.Session["RootNamespace"] = _genParams.Settings.RootNamespace;
            template.Session["table"] = _genParams.Table;
            template.Session["modelHelper"] = modelHelper;
            template.Initialize();

            string content = template.TransformText();

            File.WriteAllText(fileOut, content);

            return fileOut;
        }

        private string GenerateResourcesDesigner(string rootFolder, ModelHelper modelHelper)
        {
            string fileName = $"Resources.Designer.cs";
            rootFolder = Path.Combine(rootFolder, "Properties");
            if (!Directory.Exists(rootFolder))
            {
                Directory.CreateDirectory(rootFolder);
            }
            string fileOut = Path.Combine(rootFolder, fileName);

            var template = new ResourcesDesignerTemplate();
            template.Session = new Dictionary<string, object>();

            template.Session["RootNamespace"] = _genParams.Settings.RootNamespace;
            template.Session["table"] = _genParams.Table;
            template.Session["modelHelper"] = modelHelper;
            template.Initialize();

            string content = template.TransformText();

            File.WriteAllText(fileOut, content);

            return fileOut;
        }

        private string GenerateLaunchSettings(string rootFolder, ModelHelper modelHelper)
        {
            string fileName = $"launchSettings.json";
            rootFolder = Path.Combine(rootFolder, "Properties");
            if (!Directory.Exists(rootFolder))
            {
                Directory.CreateDirectory(rootFolder);
            }
            string fileOut = Path.Combine(rootFolder, fileName);

            var template = new LaunchSettingsTemplate();
            template.Session = new Dictionary<string, object>();

            template.Session["RootNamespace"] = _genParams.Settings.RootNamespace;
            template.Session["table"] = _genParams.Table;
            template.Session["modelHelper"] = modelHelper;
            template.Initialize();

            string content = template.TransformText();

            File.WriteAllText(fileOut, content);

            return fileOut;
        }

        private string GenerateServiceDependencies(string rootFolder, ModelHelper modelHelper)
        {
            string fileName = $"serviceDependencies.json";
            rootFolder = Path.Combine(rootFolder, "Properties");
            if (!Directory.Exists(rootFolder))
            {
                Directory.CreateDirectory(rootFolder);
            }
            string fileOut = Path.Combine(rootFolder, fileName);

            var template = new ServiceDependenciesJsonTemplate();
            template.Session = new Dictionary<string, object>();

            template.Session["RootNamespace"] = _genParams.Settings.RootNamespace;
            template.Session["table"] = _genParams.Table;
            template.Session["modelHelper"] = modelHelper;
            template.Initialize();

            string content = template.TransformText();

            File.WriteAllText(fileOut, content);

            return fileOut;
        }

        private string GenerateServiceDependenciesLocal(string rootFolder, ModelHelper modelHelper)
        {
            string fileName = $"serviceDependencies.local.json";
            rootFolder = Path.Combine(rootFolder, "Properties");
            if (!Directory.Exists(rootFolder))
            {
                Directory.CreateDirectory(rootFolder);
            }
            string fileOut = Path.Combine(rootFolder, fileName);

            var template = new ServiceDependenciesLocalJsonTemplate();
            template.Session = new Dictionary<string, object>();

            template.Session["RootNamespace"] = _genParams.Settings.RootNamespace;
            template.Session["table"] = _genParams.Table;
            template.Session["modelHelper"] = modelHelper;
            template.Initialize();

            string content = template.TransformText();

            File.WriteAllText(fileOut, content);

            return fileOut;
        }

        private string GenerateDelete(string rootFolder, ModelHelper modelHelper)
        {
            string fileName = $"Delete.cs";
            rootFolder = Path.Combine(rootFolder, _genParams.Settings.APIVersion);
            if (!Directory.Exists(rootFolder))
            {
                Directory.CreateDirectory(rootFolder);
            }
            string fileOut = Path.Combine(rootFolder, fileName);

            var template = new DeleteFunctionTemplate();
            template.Session = new Dictionary<string, object>();

            template.Session["RootNamespace"] = _genParams.Settings.RootNamespace;
            template.Session["table"] = _genParams.Table;
            template.Session["modelHelper"] = modelHelper;
            template.Initialize();

            string content = template.TransformText();

            File.WriteAllText(fileOut, content);

            return fileOut;
        }

        private string GenerateErase(string rootFolder, ModelHelper modelHelper)
        {
            string fileName = $"Erase.cs";
            rootFolder = Path.Combine(rootFolder, _genParams.Settings.APIVersion);
            if (!Directory.Exists(rootFolder))
            {
                Directory.CreateDirectory(rootFolder);
            }
            string fileOut = Path.Combine(rootFolder, fileName);

            var template = new EraseFunctionTemplate();
            template.Session = new Dictionary<string, object>();

            template.Session["RootNamespace"] = _genParams.Settings.RootNamespace;
            template.Session["table"] = _genParams.Table;
            template.Session["modelHelper"] = modelHelper;
            template.Initialize();

            string content = template.TransformText();

            File.WriteAllText(fileOut, content);

            return fileOut;
        }

        private string GenerateGetAll(string rootFolder, ModelHelper modelHelper)
        {
            string fileName = $"GetAll.cs";
            rootFolder = Path.Combine(rootFolder, _genParams.Settings.APIVersion);
            if (!Directory.Exists(rootFolder))
            {
                Directory.CreateDirectory(rootFolder);
            }
            string fileOut = Path.Combine(rootFolder, fileName);

            var template = new GetAllFunctionTemplate();
            template.Session = new Dictionary<string, object>();

            template.Session["RootNamespace"] = _genParams.Settings.RootNamespace;
            template.Session["table"] = _genParams.Table;
            template.Session["modelHelper"] = modelHelper;
            template.Initialize();

            string content = template.TransformText();

            File.WriteAllText(fileOut, content);

            return fileOut;
        }

        private string GenerateGetDetails(string rootFolder, ModelHelper modelHelper)
        {
            string fileName = $"GetDetails.cs";
            rootFolder = Path.Combine(rootFolder, _genParams.Settings.APIVersion);
            if (!Directory.Exists(rootFolder))
            {
                Directory.CreateDirectory(rootFolder);
            }
            string fileOut = Path.Combine(rootFolder, fileName);

            var template = new GetDetailsFunctionTemplate();
            template.Session = new Dictionary<string, object>();

            template.Session["RootNamespace"] = _genParams.Settings.RootNamespace;
            template.Session["table"] = _genParams.Table;
            template.Session["modelHelper"] = modelHelper;
            template.Initialize();

            string content = template.TransformText();

            File.WriteAllText(fileOut, content);

            return fileOut;
        }

        private string GenerateInsert(string rootFolder, ModelHelper modelHelper)
        {
            string fileName = $"Insert.cs";
            rootFolder = Path.Combine(rootFolder, _genParams.Settings.APIVersion);
            if (!Directory.Exists(rootFolder))
            {
                Directory.CreateDirectory(rootFolder);
            }
            string fileOut = Path.Combine(rootFolder, fileName);

            var template = new InsertFuncrtionTemplate();
            template.Session = new Dictionary<string, object>();

            template.Session["RootNamespace"] = _genParams.Settings.RootNamespace;
            template.Session["table"] = _genParams.Table;
            template.Session["modelHelper"] = modelHelper;
            template.Initialize();

            string content = template.TransformText();

            File.WriteAllText(fileOut, content);

            return fileOut;
        }

        private string GenerateUpdate(string rootFolder, ModelHelper modelHelper)
        {
            string fileName = $"Update.cs";
            rootFolder = Path.Combine(rootFolder, _genParams.Settings.APIVersion);
            if (!Directory.Exists(rootFolder))
            {
                Directory.CreateDirectory(rootFolder);
            }
            string fileOut = Path.Combine(rootFolder, fileName);

            var template = new UpdateFunctionTemplate();
            template.Session = new Dictionary<string, object>();

            template.Session["RootNamespace"] = _genParams.Settings.RootNamespace;
            template.Session["table"] = _genParams.Table;
            template.Session["modelHelper"] = modelHelper;
            template.Initialize();

            string content = template.TransformText();

            File.WriteAllText(fileOut, content);

            return fileOut;
        }

        protected string GetOutputFolder()
        {
            string outFolder = Path.Combine(_genParams.Settings.OutputRoot,
                                            _genParams.Timestamp.ToString("yyyy-MM-dd HH-mm-ss"),
                                            _genParams.Settings.OutputFolders["Functions"],
                                            string.Format(_genParams.Settings.FunctionProjectNameTemplate, _genParams.Table.Name));
            outFolder = base.CreateDirectory(outFolder);

            return outFolder;
        }
    }
}
