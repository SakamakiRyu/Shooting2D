using DragonGames.Pool;
using UnityEngine;

namespace DragonGames.Bullet
{
    public class Bullet : MonoBehaviour, IPooledObject<Bullet>
    {
        [SerializeField]
        private BulletMover _mover;

        public UnityEngine.Pool.ObjectPool<Bullet> Pool { get; set; }

        private void Awake()
        {
            if (_mover == null)
            {
                if (!TryGetComponent(out _mover))
                {
                    _mover = gameObject.AddComponent<BulletMover>();
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            Pool.Release(this);
        }

        public void Shoot(Vector2 pos, Vector2 dir, float speed)
        {
            if (!_mover) return;

            _mover.Shoot(pos, dir, speed);
        }
    }
}