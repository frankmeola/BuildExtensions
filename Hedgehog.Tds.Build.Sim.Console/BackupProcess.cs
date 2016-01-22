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
    public class BackupProcess
    {
        public bool Execute(BackupArgs args)
        {
            try
            {
                System.Console.WriteLine("SIM: Starting Backup");

                Instance instance = InstanceManager.GetInstance(args.InstanceName);

                if (Directory.Exists(Path.Combine(instance.BackupsFolder, args.BackupName)))
                {
                    throw new Exception(string.Format(
                        "SIM: Error! There is already a backup named {0} in the backups folder {1}. Stopping to prevent data loss.",
                        args.BackupName,
                        instance.BackupsFolder));
                }

                System.Console.WriteLine("backup files={0}", args.BackupFiles);
                System.Console.WriteLine("backup databases={0}", args.BackupDatabases);
                System.Console.WriteLine("backup client={0}", args.BackupClient);

                SIM.Pipelines.Backup.BackupArgs backupArgs = new SIM.Pipelines.Backup.BackupArgs(
                    instance,
                    args.BackupName,
                    args.BackupFiles,
                    args.BackupDatabases,
                    args.BackupClient);

                IPipelineController controller = new ConsoleController();

                PipelineManager.Initialize();
                PipelineManager.StartPipeline(
                    "backup",
                    backupArgs,
                    controller,
                    false);

                System.Console.WriteLine("SIM: Finished backup");

                return true;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Sitecore SIM backup failed {0}", ex);
                return false;
            }

        }
    }
}
