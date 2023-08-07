using UnityEngine;

namespace DragonGames.Pool
{
    public abstract class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
    {
        public UnityEngine.Pool.ObjectPool<T> Pool { get; protected set; }

        public virtual T Get()
        {
            return Pool.Get();
        }

        // プールの作成
        public virtual void CreatePool(T createObject, int defaultCapacity = 30, int maxCapacity = 100)
        {
            Pool = new UnityEngine.Pool.ObjectPool<T>(() =>
            {
                var obj = Instantiate(createObject);
                var iPooledObject = obj as IPooledObject<T>;
                iPooledObject?.SetPool(Pool);
                return obj;
            },
            target =>
            {
                target.gameObject.SetActive(true);
            },
            target =>
            {
                target.gameObject.SetActive(false);
            },
            target =>
            {
                Destroy(target);
            },
            defaultCapacity: defaultCapacity, maxSize: maxCapacity);
        }
    }
}