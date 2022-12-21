using System;
using System.Collections.Generic;

namespace MemoryLeaks.MemoryLeak.Cache
{
    public class FactoryNode
    {
        // 캐싱 메모리 문제
        // 사용하지 않는 캐싱 메모리 삭제
        // 캐싱 크기 제한
        // WeakReference 사용
        private Dictionary<int, ProcessNode> _factories = new Dictionary<int, ProcessNode>();

        ~FactoryNode()
        {
            Console.WriteLine($"Released {nameof(FactoryNode)}");
        }
        public INode CreateNode(int key)
        {
            if (!_factories.ContainsKey(key))
            {
                _factories.Add(key, new ProcessNode());
            }

            return _factories[key];
        }
    }

    // WeakReference 사용 예제
    // https://learn.microsoft.com/ko-kr/dotnet/api/system.weakreference-1.-ctor?view=net-7.0
    public class Cache
    {
        // Dictionary to contain the cache.
        static Dictionary<int, WeakReference>? _cache;

        // Track the number of times an object is regenerated.
        int regenCount = 0;

        public Cache(int count)
        {
            _cache = new Dictionary<int, WeakReference>();

            // Add objects with a short weak reference to the cache.
            for (int i = 0; i < count; i++)
            {
                _cache.Add(i, new WeakReference(new ProcessNode(i), false));
            }
        }
    }
    public interface INode
    {
        public INode SetUid(string uId);
        public string GetUid();
    }
    public class ProcessNode : INode
    {
        private string _uid = string.Empty;

        public string UId => _uid;

        public ProcessNode()
        {

        }
        public ProcessNode(int id)
        {
            _uid = id.ToString();
        }

        public INode SetUid(string uId)
        {
            _uid = uId;

            return this;
        }

        public string GetUid() => _uid;
    }

}
