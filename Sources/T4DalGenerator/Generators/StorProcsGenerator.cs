﻿using CRUDAPI.DataModel;
using CRUDAPI.Template.SQL.SQL;
using System;
using System.Collections.Generic;
using System.IO;

namespace CRUDAPI.Generators
{
    public class StorProcsGenerator : GeneratorBase
    {

        public StorProcsGenerator(GeneratorParams genParams) : base(genParams)
        {
        }

        public override IList<string> Generate()
        {
            IList<string> files = new List<string>();

            var modelHelper = new ModelHelper();

            if (_genParams.Settings.IsSoftDelete && _genParams.Table.HasColumn(_genParams.Settings.SoftDeleteField))
            {
                files.Add(GenerateErase(modelHelper));
            }
            files.Add(GenerateDelete(modelHelper));
            files.Add(GenerateGetAll(modelHelper));
            files.Add(GenerateGetDetails(modelHelper));
            files.Add(GenerateUpdate(modelHelper));
            files.Add(GenerateInsert(modelHelper));
            foreach (var c in _genParams.Table.Columns)
            {
                if (c.FKRefTable != null)
                {
                    files.Add(GenerateGetDetailsByField(modelHelper, c));
                }
            }

            return files;
        }

        protected string GenerateErase(ModelHelper modelHelper)
        {
            string fileName = $"p_{_genParams.Table.Name}_Erase.sql";
            string fileOut = Path.Combine(GetOutputFolder(), fileName);
            
            var template = new StorProcEntityErase();
            template.Session = new Dictionary<string, object>();

            template.Session["RootNamespace"] = _genParams.Settings.RootNamespace;
            template.Session["table"] = _genParams.Table;
            template.Session["modelHelper"] = modelHelper;
            template.Initialize();

            string content = template.TransformText();

            File.WriteAllText(fileOut, content);
            
            return fileOut;
        }

        protected string GenerateDelete(ModelHelper modelHelper)
        {
            string fileName = $"p_{_genParams.Table.Name}_Delete.sql";
            string fileOut = Path.Combine(GetOutputFolder(), fileName);

            var template = new StorProcEntityDelete();
            template.Session = new Dictionary<string, object>();
            
            template.Session["table"] = _genParams.Table;
            template.Session["modelHelper"] = modelHelper;
            template.Session["IsSoftDelete"] = _genParams.Settings.IsSoftDelete;
            template.Session["SoftDeleteField"] = _genParams.Settings.SoftDeleteField;
            template.Initialize();

            string content = template.TransformText();

            File.WriteAllText(fileOut, content);

            return fileOut;
        }

        protected string GenerateGetAll(ModelHelper modelHelper)
        {
            string fileName = $"p_{_genParams.Table.Name}_GetAll.sql";
            string fileOut = Path.Combine(GetOutputFolder(), fileName);

            var template = new StorProcEntityGetAll();
            template.Session = new Dictionary<string, object>();
            
            template.Session["table"] = _genParams.Table;
            template.Session["modelHelper"] = modelHelper;
            template.Initialize();

            string content = template.TransformText();

            File.WriteAllText(fileOut, content);

            return fileOut;
        }

        protected string GenerateGetDetails(ModelHelper modelHelper)
        {
            string fileName = $"p_{_genParams.Table.Name}_GetDetails.sql";
            string fileOut = Path.Combine(GetOutputFolder(), fileName);

            var template = new StorProcEntityGetDetails();
            template.Session = new Dictionary<string, object>();
            
            template.Session["table"] = _genParams.Table;
            template.Session["modelHelper"] = modelHelper;
            template.Initialize();

            string content = template.TransformText();

            File.WriteAllText(fileOut, content);

            return fileOut;
        }

        protected string GenerateGetDetailsByField(ModelHelper modelHelper, DataModel.DataColumn column)
        {
            string fileName = $"p_{_genParams.Table.Name}_GetBy{column.Name}.sql";
            string fileOut = Path.Combine(GetOutputFolder(), fileName);

            var template = new StorProcEntityGetByField();
            template.Session = new Dictionary<string, object>();
            
            template.Session["table"] = _genParams.Table;
            template.Session["column"] = column;
            template.Session["modelHelper"] = modelHelper;
            template.Initialize();

            string content = template.TransformText();

            File.WriteAllText(fileOut, content);

            return fileOut;
        }

        protected string GenerateUpdate(ModelHelper modelHelper)
        {
            string fileName = $"p_{_genParams.Table.Name}_Update.sql";
            string fileOut = Path.Combine(GetOutputFolder(), fileName);

            var template = new StorProcEntityUpdate();
            template.Session = new Dictionary<string, object>();
            
            template.Session["table"] = _genParams.Table;
            template.Session["modelHelper"] = modelHelper;
            template.Initialize();

            string content = template.TransformText();

            File.WriteAllText(fileOut, content);

            return fileOut;
        }

        protected string GenerateInsert(ModelHelper modelHelper)
        {
            string fileName = $"p_{_genParams.Table.Name}_Insert.sql";
            string fileOut = Path.Combine(GetOutputFolder(), fileName);

            var template = new StorProcEntityInsert();
            template.Session = new Dictionary<string, object>();
            
            template.Session["table"] = _genParams.Table;
            template.Session["modelHelper"] = modelHelper;
            template.Initialize();

            string content = template.TransformText();

            File.WriteAllText(fileOut, content);

            return fileOut;
        }

        protected string GetOutputFolder()
        {
            string outFolder = Path.Combine(_genParams.Settings.OutputRoot, _genParams.Timestamp.ToString("yyyy-MM-dd HH-mm-ss"), _genParams.Settings.OutputFolders["StorProces"], _genParams.Table.Name);
            outFolder = base.CreateDirectory(outFolder);

            return outFolder;
        }
    }
}
