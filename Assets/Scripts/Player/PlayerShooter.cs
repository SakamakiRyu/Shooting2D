using UnityEngine;

namespace DragonGames.Player
{
    using DragonGames.Bullet;

    public class PlayerShooter : MonoBehaviour
    {
        [SerializeField]
        private BulletPool _pool;

        [SerializeField]
        private Transform _muzzle;

        [SerializeField]
        private float _bulletSpeed;

        [SerializeField]
        private float _interval;

        // 発射可能か
        private bool _canFire = false;

        // タイマー
        private float _timer = 0f;

        private void Awake()
        {
            _canFire = true;

            if (_pool == null)
            {
                _pool = FindObjectOfType<BulletPool>();
            }
        }

        private void Update()
        {
            Check();
            Shoot();
        }

        private void Check()
        {
            if (_canFire) return;

            _timer += Time.deltaTime;
            if (_timer >= _interval)
            {
                _timer = 0f;
                _canFire = true;
            }
        }

        public void Shoot()
        {
            if (!_muzzle || !_canFire || !_pool) return;

            var bullet = _pool.Get();
            bullet.Shoot(_muzzle.position, Vector2.up, _bulletSpeed);
            _canFire = false;
        }

        public void ChengeInterval(float interval)
        {
            _interval = interval;
        }
    }
}