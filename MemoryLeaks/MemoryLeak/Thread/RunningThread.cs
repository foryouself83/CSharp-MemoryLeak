using System;
using System.Threading;

namespace MemoryLeaks.MemoryLeak.Thread
{
    internal class RunningThread
    {
        System.Threading.Thread _thread;

        public RunningThread()
        {
            _thread = new(RunThread);
            _thread.Start();
        }
        public void RunThread()
        {
            System.Threading.Thread.Sleep(1000);
            _thread.Join();
        }

        /// <summary>
        /// 별도의 쓰레드에서 실행되는 경우 해당하는 인스턴스는 GC에 수집되지 않음.
        /// </summary>
        public void RunTimer()
        {
            Timer timer = new Timer(RunTick);
            timer.Change(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1));
        }

        private void RunTick(object? state)
        {
        }
    }
}
