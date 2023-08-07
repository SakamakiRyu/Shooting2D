using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletMover : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rb;

    private Transform _transform;

    private void Awake()
    {
        if (_rb == null)
        {
            if (!TryGetComponent(out _rb))
            {
                _rb = gameObject.AddComponent<Rigidbody2D>();
            }
        }

        _transform = transform;
    }

    public void Shoot(Vector2 pos, Vector2 dir, float speed)
    {
        if (!_rb) return;

        _transform.position = pos;
        _rb.velocity = dir * speed;
    }
}
