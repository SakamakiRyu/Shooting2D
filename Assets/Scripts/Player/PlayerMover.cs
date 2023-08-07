using UniRx;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField]
    private float _speed = default;

    private Rigidbody2D _rb;

    private void Awake()
    {
        if (!TryGetComponent(out _rb))
        {
            _rb = gameObject.AddComponent<Rigidbody2D>();
        }

        if (InputReciver.Instance)
        {
            InputReciver.Instance.Direction.Subscribe(dir =>
            {
                var velo = dir * _speed;
                Move(velo);
            }).AddTo(this);
        }
    }

    private void Move(Vector2 velocity)
    {
        _rb.velocity = velocity;
    }
}