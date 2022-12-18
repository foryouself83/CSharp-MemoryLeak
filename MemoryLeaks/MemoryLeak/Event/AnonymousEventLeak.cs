using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryLeaks.MemoryLeak.Event
{
    internal class AnonymousEventLeak
    {
        private readonly EventLeakHandler _eventHandler;

        private int _id;
        public AnonymousEventLeak(EventLeakHandler eventHandler)
        {
            _eventHandler = eventHandler;

            // Anonymous method Leak
            AddAnonymousEvent();
        }
        private void AddAnonymousEvent()
        {
            //int id = _id;
            _eventHandler.LeakEventHandler += (s, e) =>
            {
                // 이벤트가 구독 취소되지 않는 한 참조된 변수를 갖고 있는 인스턴스도 참조하므로 수집되지 않음.
                Console.WriteLine($"my ID: {_id}");
                //Console.WriteLine($"my ID: {id}");
            };
        }
    }
}
