using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hedgehog.Tds.Build.Sim.Console
{
    public class DeleteBackupArgs : BaseArgsProcessor
    {
        public string InstanceName
        {
            get { return GetArg("InstanceName"); }
        }

        public string BackupName
        {
            get { return GetArg("BackupName"); }
        }

        public DeleteBackupArgs(IEnumerable<string> args)
            : base(args)
        {
        }
    }
}
