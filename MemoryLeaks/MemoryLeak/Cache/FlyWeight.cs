using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryLeaks.MemoryLeak.Cache
{
    public class FactoryNode
    {
        // 캐싱 메모리 문제
        // 사용하지 않는 캐싱 메모리 삭제
        // 캐싱 크기 제한
        // WeakReference 사용
        private Dictionary<Type, INode> _factories = new Dictionary<Type, INode>();

        public INode CreateNode(Type type)
        {
            if (!_factories.ContainsKey(type))
            {                
                if (Activator.CreateInstance(type) is INode node)
                    _factories.Add(type, node);
                else
                    throw new ArgumentException(nameof(type));
            }

            return _factories[type];
        }
        public T CreateNode<T>() where T : INode
        {
            return (T)CreateNode(typeof(T));
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
