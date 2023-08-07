using UnityEngine;

namespace DragonGames.Pool
{
    public interface IPooledObject<T> where T : MonoBehaviour
    {
        public UnityEngine.Pool.ObjectPool<T> Pool { get; set; }

        void SetPool(UnityEngine.Pool.ObjectPool<T> pool)
        {
            Pool = pool;
        }  
    }
}