using System;

namespace Utils
{
    public abstract class LazySingleton<T> where T : new()
    {
        private static readonly Lazy<T> instance = new Lazy<T>(() => new T());
        public static T Instance { get { return instance.Value; } }

    }
}