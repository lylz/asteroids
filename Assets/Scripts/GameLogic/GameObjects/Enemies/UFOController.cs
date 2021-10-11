using UnityEngine;

public class UFOController : GameObjectController 
{
    private IPlayerEvents _playerEvents;
    private IEnemyEvents _enemyEvents;
    private IUFO _ufo;
    private float _speed;
    private ISpacecraftPositionTracker _spacecraftPosition;
    private ITransformAdapter _transformAdapter;
    private Vector3 _moveDirection;
    private bool _idle;
    private bool _destroyed;

    public UFOController(
        IPlayerEvents playerEvents,
        IEnemyEvents enemyEvents,
        IUFO ufo,
        float speed,
        ISpacecraftPositionTracker spacecraftPosition,
        IScreenBounds screenBounds,
        ITransformAdapter transformAdapter
    )
        : base(new IPostUpdateProcessor[] { new PortalPostUpdateProcessor(screenBounds, transformAdapter) })
    {
        _playerEvents = playerEvents;
        _enemyEvents = enemyEvents;
        _ufo = ufo;
        _speed = speed;
        _spacecraftPosition = spacecraftPosition;
        _transformAdapter = transformAdapter;
        _moveDirection = Vector3.zero;

        _playerEvents.PlayerDied += OnPlayerDied;
    }

    ~UFOController()
    {
        _playerEvents.PlayerDied -= OnPlayerDied;
    }

    public override void FixedUpdate(float dt)
    {
        base.FixedUpdate(dt);

        if (!_idle)
        {
            _moveDirection = _spacecraftPosition.Position - _transformAdapter.position;
        }

        _transformAdapter.position += _moveDirection.normalized * _speed * dt;
    }

    private void OnPlayerDied()
    {
        _idle = true;
    }

    public void Hit(Collider2D collision)
    {
        Die();
    }

    private void Die()
    {
        if (_destroyed)
        {
            return;
        }

        _destroyed = true;
        _enemyEvents.InvokeEnemyDestroyed(_ufo);
    }
}
