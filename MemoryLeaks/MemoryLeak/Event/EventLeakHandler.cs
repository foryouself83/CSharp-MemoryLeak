using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MemoryLeaks.MemoryLeak.Event
{
    public class EventLeakHandler
    {
        public event EventHandler<RoutedEventArgs>? LeakEventHandler;
    }
}
