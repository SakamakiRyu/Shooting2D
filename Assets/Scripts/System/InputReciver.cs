using UniRx;
using UnityEngine;

public class InputReciver : Singleton<InputReciver>
{
    public IReadOnlyReactiveProperty<Vector2> Direction => _direction;
    private ReactiveProperty<Vector2> _direction;

    public IReadOnlyReactiveProperty<float> Horizontal => _horizontal;
    private ReactiveProperty<float> _horizontal;

    public IReadOnlyReactiveProperty<float> Vertical => _vertical;
    private ReactiveProperty<float> _vertical;

    protected override void Awake()
    {
        base.Awake();
        _direction = new ReactiveProperty<Vector2>();
        _horizontal = new ReactiveProperty<float>();
        _vertical = new ReactiveProperty<float>();
    }

    private void Update()
    {
        CheckInput();
    }

    private void OnDestroy()
    {
        _direction = null;
        _horizontal = null;
        _vertical = null;
    }

    /// <summary>
    /// “ü—Í‚ÌŠm”F
    /// </summary>
    private void CheckInput()
    {
        var h = Input.GetAxisRaw("Horizontal");
        var v = Input.GetAxisRaw("Vertical");
        var dir = Vector2.right * h + Vector2.up * v;

        _horizontal.Value = h;
        _vertical.Value = v;
        _direction.Value = dir.normalized;
    }
}