using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using PPT.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PPT.Functions.Common
{
    public class FunctionStartupBase : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            this.PrepareComposition();
        }

        public CompositionContainer Container
        {
            get;
            set;
        }

        public TDal InitDal<TDal>() where TDal : IInitializable
        {
            var funHelper = new FunctionHelper();

            var dal = Container.GetExportedValue<TDal>(funHelper.GetEnvironmentVariable<string>(Constants.ENV_DAL_TYPE));
            var dalInitParams = dal.CreateInitParams();

            dalInitParams.Parameters["ConnectionString"] = funHelper.GetEnvironmentVariable<string>(Constants.ENV_SQL_CONNECTION_STRING);

            dalInitParams.Parameters = dalInitParams.Parameters;
            dal.Init(dalInitParams);

            return dal;
        }

        #region Support methods

        private void PrepareComposition()
        {
            AggregateCatalog catalog = new AggregateCatalog();
            DirectoryCatalog directoryCatalog = new DirectoryCatalog(AssemblyDirectory);
            catalog.Catalogs.Add(directoryCatalog);
            Container = new CompositionContainer(catalog);
            Container.ComposeParts(this);
        }

        private string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().Location;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        #endregion
    }
}
