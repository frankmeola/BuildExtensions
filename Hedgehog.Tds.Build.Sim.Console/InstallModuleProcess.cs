using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIM.Instances;
using SIM.Pipelines;
using SIM.Products;

namespace Hedgehog.Tds.Build.Sim.Console
{
    public class InstallModuleProcess
    {
        public bool Execute(InstallModuleArgs args)
        {
            try
            {
                System.Console.WriteLine("SIM: Starting module install");

                Instance instance = InstanceManager.GetInstance(args.InstanceName);

                var p = Product.GetFilePackageProduct(args.ModulePath);
                IEnumerable<Product> modules = new List<Product>{p};

                System.Console.WriteLine("Modules found {0}", modules.Count());
                foreach (var product in modules)
                {
                    System.Console.WriteLine("Module {0} from path {1}", product.DisplayName, product.PackagePath);
                }
                var connectionString = new SqlConnectionStringBuilder(args.ConnectionString);

                SIM.Pipelines.InstallModules.InstallModulesArgs installModulesArgs = new SIM.Pipelines.InstallModules.InstallModulesArgs(
                    instance,
                    modules);

                IPipelineController controller = new ConsoleController();

                PipelineManager.Initialize();
                PipelineManager.StartPipeline(
                    "installmodules",
                    installModulesArgs,
                    controller,
                    false);

                System.Console.WriteLine("SIM: Finished module install");

                return true;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Sitecore SIM module install failed {0}", ex);
                return false;
            }

        }
    }
}
