# CSharp-MemoryLeak

# Contents
* [Subcribe Event](<https://github.com/foryouself83/CSharp-MemoryLeak/tree/master#subcribe-event>)
* [Anonymous Method](<https://github.com/foryouself83/CSharp-MemoryLeak/tree/master#anonymous-method>)
* [Root Object](<https://github.com/foryouself83/CSharp-MemoryLeak/tree/master#root-object>)
* [WPF Binding](<https://github.com/foryouself83/CSharp-MemoryLeak/tree/master#wpf-binding>)
* [Running Thread](<https://github.com/foryouself83/CSharp-MemoryLeak/tree/master#running-thread>)
* [UnManaged Memory](<https://github.com/foryouself83/CSharp-MemoryLeak/tree/master#unmanaged-memory>)
* [Cashing Function](<https://github.com/foryouself83/CSharp-MemoryLeak/tree/master#cashing-function>)
* [Dispose](<https://github.com/foryouself83/CSharp-MemoryLeak/tree/master#dispose>)


# Development Environment
* .NET 7.0  
* Visual Studio 2022   

# Subcribe Event
- **Cause of occurrence**   

If you do not unsubscribe after subscribing to the event.   
- **Solutions**   

Unsubscribe on 'Unloaded event' or 'Dispose'.
Use ‘WeakEventManager’ to collect and release from GC (note performance degradation)   

# Anonymous Method
- **Cause of occurrence**   

When a member variable or static variable is referenced by an anonymous method, the instance is not collected by the GC.   
- **Solutions**   

Convert to local variable before referencing and processing.

# Root Object
- **Cause of occurrence**   

The following items corresponding to root objects are not collected by GC:
> live stack of threads   
> Static variable   
> Objects registered in CPU registers, GC handles, Finalize queues.   
> Reference counting when using COM Interop (ex. using another C++ library)   
- **Solutions**   

Be careful when referencing static variables and IntPtr etc.
- [Reference](<https://learn.microsoft.com/ko-kr/dotnet/standard/garbage-collection/fundamentals>)   

# WPF Binding
- **Cause of occurrence**   

Occurs when binding is set in xaml but 'INotifyPropertyChanged' is not implemented in ViewModel.   
- **Solutions**   

When setting binding in Xaml, implement it in ViewModel and do not use meaningless Binding.
- [Reference](<https://stackoverflow.com/questions/18542940/can-bindings-create-memory-leaks-in-wpf/18543350#18543350>)

# Running Thread
- **Cause of occurrence**   

Occurs when an instance is destroyed without terminating the thread.   
- **Solutions**   

Dispose by using Dispose Pattern, etc.   

# UnManaged Memory
- **Cause of occurrence**   

Occurs when allocated memory is not freed, such as AllocHGlobal.   
- **Solutions**   

Dispose by using Dispose Pattern, etc.   

# Cashing Function
- **Cause of occurrence**   

Occurs when memory increases infinitely when caching using FlyWeight pattern, etc.
- **Solutions**    

Use '[WeakReference](https://learn.microsoft.com/ko-kr/dotnet/api/system.weakreference-1.-ctor?view=net-7.0>)'   
Caching memory limit.    
Clean cached memory.   

# Dispose
- **Cause of occurrence**   

When an object inheriting from IDispoable is not released.
- **Solutions**   

Use '[WeakReference](https://learn.microsoft.com/ko-kr/dotnet/api/system.weakreference-1.-ctor?view=net-7.0>)'.   
Release resources using using or Dispose.     
They are eventually collected and released when GC.Collect runs, but remain leaked until then.
