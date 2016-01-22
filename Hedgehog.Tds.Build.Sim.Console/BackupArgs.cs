using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hedgehog.Tds.Build.Sim.Console
{
    public class BackupArgs : BaseArgsProcessor
    {
        public string InstanceName
        {
            get { return GetArg("InstanceName"); }
        }

        public string BackupName
        {
            get { return GetArg("BackupName"); }
        }

        public bool BackupFiles
        {
            get { return Convert.ToBoolean(GetArg("BackupFiles")); }
        }

        public bool BackupDatabases
        {
            get { return Convert.ToBoolean(GetArg("BackupDatabases")); }
            
        }

        public bool BackupClient
        {
            get { return Convert.ToBoolean(GetArg("BackupClient")); }
        }

        public BackupArgs(IEnumerable<string> args)
            : base(args)
        {
        }
    }
}
