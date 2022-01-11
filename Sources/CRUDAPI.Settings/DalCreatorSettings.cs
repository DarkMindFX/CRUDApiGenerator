﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDAPI.Settings
{
    public class DalCreatorSettings
    {
        public string ProjectName { get; set; }
        public string ConnectionString { get; set; }

        public string OutputRoot { get; set; }

        public string SolutionTemplate { get; set; }

        public string RootNamespace { get; set; }

        public bool IsSoftDelete { get; set; }

        public string SoftDeleteField { get; set; }

        public string APIVersion { get; set; } 

        public Dictionary<string, string> OutputFolders { get; set; }

        public string FunctionProjectNameTemplate { get; set; }
    }
}
