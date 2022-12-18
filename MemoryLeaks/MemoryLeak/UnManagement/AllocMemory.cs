using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MemoryLeaks.MemoryLeak.UnManagement
{
    internal class AllocMemory
    {
        private IntPtr _buffer;

        public AllocMemory()
        {
            _buffer = Marshal.AllocHGlobal(1000);
        }
        ~AllocMemory()
        {

        }
    }
}
