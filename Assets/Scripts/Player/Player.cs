using UnityEngine;

namespace DragonGames.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private PlayerMover _mover;

        [SerializeField]
        private PlayerShooter _shooter;

        [SerializeField]
        private PlayerView _view;

        private void Awake()
        {
            if (_mover == null)
            {
                if (!TryGetComponent(out _mover))
                {
                    _mover = gameObject.AddComponent<PlayerMover>();
                }
            }

            if (_shooter == null)
            {
                if (!TryGetComponent(out _shooter))
                {
                    _shooter = gameObject.AddComponent<PlayerShooter>();
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {

        }
    }
}