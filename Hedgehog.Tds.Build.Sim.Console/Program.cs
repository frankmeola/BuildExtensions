using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hedgehog.Tds.Build.Sim.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            switch (args[0])
            {
                case "install":
                    InstallArgs installArgs = new InstallArgs(args);
                    InstallProcess installProcess = new InstallProcess();
                    installProcess.Execute(installArgs);
                    break;
                case "delete":
                    DeleteArgs deleteArgs = new DeleteArgs(args);
                    DeleteProcess deleteProcess = new DeleteProcess();
                    deleteProcess.Execute(deleteArgs);
                    break;
                case "backup":
                    BackupArgs backupArgs = new BackupArgs(args);
                    BackupProcess backupProcess = new BackupProcess();
                    backupProcess.Execute(backupArgs);
                    break;
                case "restore":
                    RestoreArgs restoreArgs = new RestoreArgs(args);
                    RestoreProcess restoreProcess = new RestoreProcess();
                    restoreProcess.Execute(restoreArgs);
                    break;
                case "delete-backup":
                    DeleteBackupArgs deleteBackupArgs = new DeleteBackupArgs(args);
                    DeleteBackupProcess deleteBackupProcess = new DeleteBackupProcess();
                    deleteBackupProcess.Execute(deleteBackupArgs);
                    break;
                case "install-module":
                    InstallModuleArgs installModuleArgs = new InstallModuleArgs(args);
                    InstallModuleProcess installModuleProcess = new InstallModuleProcess();
                    installModuleProcess.Execute(installModuleArgs);
                    break;
            }


        }
    }
}
