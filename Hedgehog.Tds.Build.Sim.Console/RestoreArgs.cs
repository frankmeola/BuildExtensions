using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hedgehog.Tds.Build.Sim.Console
{
    public class RestoreArgs : BaseArgsProcessor
    {
        public string InstanceName
        {
            get { return GetArg("InstanceName"); }
        }

        public string BackupName
        {
            get { return GetArg("BackupName"); }
        }

        public RestoreArgs(IEnumerable<string> args)
            : base(args)
        {
        }
    }
}
