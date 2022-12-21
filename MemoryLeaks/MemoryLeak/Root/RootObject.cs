using System;
using System.Collections.Generic;

namespace MemoryLeaks.MemoryLeak.Root
{
    internal class RootObject
    {
        /// <summary>
        /// GC는 Root object의 경우 검토 및 수집하지 않음.
        /// Root Object 종류
        /// - 실행 중인 스레드의 지역 변수
        /// - 정적 변수
        /// - CPU 레지스터에 등록된 오브젝트, GC 핸들, Finalize 큐.
        /// - COM Interop(ex. 다른 C++ 라이브러리 사용)을 사용 시 참조 횟수
        /// https://learn.microsoft.com/ko-kr/dotnet/standard/garbage-collection/fundamentals
        /// </summary>
        static List<RootObject> _instances = new List<RootObject>();
        public RootObject()
        {
        }
        ~RootObject()
        {
            Console.WriteLine($"Released {nameof(RootObject)}");
        }
        public void AddObject()
        {
            _instances.Add(this);
            _instances.Add(this);
            _instances.Add(this);
        }
    }
}
