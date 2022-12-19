using System;
using System.Windows;
using MemoryLeaks.MemoryLeak.Anonymous;
using MemoryLeaks.MemoryLeak.Event;
using MemoryLeaks.MemoryLeak.Root;
using MemoryLeaks.MemoryLeak.Thread;
using MemoryLeaks.MemoryLeak.UnManagement;

namespace MemoryLeaks
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly EventLeakHandler _eventLeakHandler;
        public MainWindow()
        {
            InitializeComponent();
            _eventLeakHandler = new EventLeakHandler();
        }
        private void OnChangedLabelButton(object sender, RoutedEventArgs e)
        {
            LeakLabel.Content = "Occr Leak";
        }
        private void CreateSubscribeEventLeak()
        {
            var leak = new SubscribeEventLeak(_eventLeakHandler);
            // Dispose Pattern 을 활용한 이벤트 구독 해제
            leak.Dispose();
            leak = null;
        }
        private void OnSubscribeEventLeakButton(object sender, RoutedEventArgs e)
        {
            TriggerGC();

            CreateSubscribeEventLeak();

            TriggerGC();
        }
        private void CreateAnonymousEventLeak()
        {
            var leak = new AnonymousEventLeak(new AnonymousAction());
            leak = null;
        }

        private void OnAnonymousEventLeakButton(object sender, RoutedEventArgs e)
        {
            TriggerGC();

            CreateAnonymousEventLeak();

            TriggerGC();
        }
        private void CreateStaticRootObject()
        {
            var root = new RootObject();
            root.AddObject();
            root = null;
        }
        private void OnStaticLeak(object sender, RoutedEventArgs e)
        {
            TriggerGC();

            CreateStaticRootObject();

            TriggerGC();
        }
        private void CreateThreadRootObject()
        {
            var thread = new RunningThread();
            //thread.RunTimer();
            thread = null;
        }
        private void OnThreadLeak(object sender, RoutedEventArgs e)
        {
            TriggerGC();

            CreateThreadRootObject();

            TriggerGC();
        }
        private void CreateAllocMemory()
        {
            var alloc = new AllocMemory();
            alloc = null;
        }
        private void OnUnManagementLeak(object sender, RoutedEventArgs e)
        {
            TriggerGC();

            CreateAllocMemory();

            TriggerGC();
        }

        public void TriggerGC()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

    }
}
