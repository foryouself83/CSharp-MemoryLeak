using System;
using System.Runtime.InteropServices;

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
            Console.WriteLine($"Released {nameof(AllocMemory)}");
        }
    }
}
