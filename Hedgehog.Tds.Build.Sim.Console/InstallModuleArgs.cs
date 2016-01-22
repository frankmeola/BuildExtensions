using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hedgehog.Tds.Build.Sim.Console
{
    public class InstallModuleArgs : BaseArgsProcessor
    {
        public string InstanceName
        {
            get { return GetArg("InstanceName"); }
        }

        public string ModulePath
        {
            get { return GetArg("ModulePath"); }
        }

        public string ConnectionString
        {
            get { return GetArg("ConnectionString"); }
        }
        
        public InstallModuleArgs(IEnumerable<string> args)
            : base(args)
        {
        }
    }
}
