using Cysharp.Threading.Tasks;
using DragonGames.Addressables;
using DragonGames.Pool;
using UnityEngine;

namespace DragonGames.Bullet
{
    public class BulletPool : ObjectPool<Bullet>
    {
        [SerializeField]
        private int _defaultCapacity;

        [SerializeField]
        private int _maxCapacity;

        private Bullet _bullet;

        private async void Awake()
        {
            await LoadBullet();
            CreatePool(_bullet, _defaultCapacity, _maxCapacity);
        }

        private async UniTask LoadBullet()
        {
            _bullet = await UnityEngine.AddressableAssets.Addressables.LoadAssetAsync<Bullet>(AddressablesPath.BulletPath).Task;
        }
    }
}