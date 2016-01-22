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
    public class RestoreProcess
    {
        public bool Execute(RestoreArgs args)
        {
            try
            {
                System.Console.WriteLine("SIM: Starting Restore");

                Instance instance = InstanceManager.GetInstance(args.InstanceName);
                InstanceBackup backupInstance = instance.Backups
                                                .FirstOrDefault(backup => new DirectoryInfo(backup.FolderPath).Name == args.BackupName);

                if (backupInstance == null)
                {
                    throw new Exception(string.Format(
                        "SIM: Error! The backup {0} was not found in the backups folder {1}.",
                        args.BackupName, 
                        instance.BackupsFolder));
                }

                System.Console.WriteLine("Found backup {0} created on {1}", backupInstance.FolderPath, backupInstance.DateString);

                System.Console.WriteLine("Stopping instance...");

                instance.Stop(true);

                System.Console.WriteLine("Restoring...");

                SIM.Pipelines.Restore.RestoreArgs restoreArgs = new SIM.Pipelines.Restore.RestoreArgs(
                    instance,
                    backupInstance);

                IPipelineController controller = new ConsoleController();

                PipelineManager.Initialize();
                PipelineManager.StartPipeline(
                    "restore",
                    restoreArgs,
                    controller,
                    false);

                System.Console.WriteLine("SIM: Finished Restore");

                System.Console.WriteLine("Starting instance...");
                instance.Start();

                return true;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Sitecore SIM Restore failed {0}", ex);
                return false;
            }
        }
    }
}
