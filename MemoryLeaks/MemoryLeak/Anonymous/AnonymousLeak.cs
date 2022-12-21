using System;

namespace MemoryLeaks.MemoryLeak.Anonymous
{
    internal class AnonymousEventLeak
    {
        private readonly AnonymousAction _actionHandler;

        private int _id;
        public AnonymousEventLeak(AnonymousAction actionHandler)
        {
            _actionHandler = actionHandler;

            // Anonymous method Leak
            AddAnonymousEvent();
        }
        ~AnonymousEventLeak()
        {
            Console.WriteLine($"Released {nameof(AnonymousEventLeak)}");
        }
        private void AddAnonymousEvent()
        {
            //int id = _id;
            _actionHandler.RunAction = new(() =>
            {
                // 이벤트가 구독 취소되지 않는 한 참조된 변수를 갖고 있는 인스턴스도 참조하므로 수집되지 않음.
                Console.WriteLine($"my ID: {_id}");
                //Console.WriteLine($"my ID: {id}");

            });
        }
    }
}
