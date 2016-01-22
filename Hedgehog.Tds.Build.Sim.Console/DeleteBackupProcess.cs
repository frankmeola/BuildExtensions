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
    public class DeleteBackupProcess
    {
        public bool Execute(DeleteBackupArgs args)
        {
            try
            {
                System.Console.WriteLine("SIM: Starting Delete Backup");

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

                new DirectoryInfo(backupInstance.FolderPath).Delete(true);

                System.Console.WriteLine("SIM: Finished Delete backup");

                return true;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Sitecore SIM Delete backup failed {0}", ex);
                return false;
            }

        }
    }
}
