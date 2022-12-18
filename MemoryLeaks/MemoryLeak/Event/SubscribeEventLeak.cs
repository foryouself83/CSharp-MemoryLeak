using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MemoryLeaks.MemoryLeak.Event
{
    public class SubscribeEventLeak : IDisposable
    {
        private readonly EventLeakHandler _eventHandler;

        private int _id;

        public SubscribeEventLeak(EventLeakHandler eventHandler)
        {
            _eventHandler = eventHandler;

            // Event 구독
            AddSubscribeEvent();
        }
        ~SubscribeEventLeak()
        {
        }
        private void AddSubscribeEvent()
        {
            //_eventHandler.LeakEventHandler += OnLeakEvent;

            // 약한 이벤트 패턴 사용시 구독 해제를 해주지 않아도 가능하나 퍼포먼스 하락이 있을 수 있음
            // https://learn.microsoft.com/en-us/dotnet/desktop/wpf/events/weak-event-patterns?view=netdesktop-6.0
            WeakEventManager<EventLeakHandler, RoutedEventArgs>.AddHandler(_eventHandler, "LeakEventHandler", OnLeakEvent);
        }
        public void Dispose()
        {
            // Evnet 구독 해제
            //_eventHandler.LeakEventHandler -= OnLeakEvent;
        }

        private void OnLeakEvent(object? sender, RoutedEventArgs e)
        {            
        }
    }
}
