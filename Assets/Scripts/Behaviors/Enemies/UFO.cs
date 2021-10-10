using UnityEngine;

public class UFO : Enemy, IUFO
{
    public EnemyEvents EnemyEvents;
    public float Speed;
    public SpacecraftPositionTracker SpacecraftPositionTracker;

    private UFOController _ufoController;

    public override IGameObjectController Controller => _ufoController;

    protected override void Start()
    {
        base.Start();

        _ufoController = new UFOController(
            EnemyEvents,
            this,
            Speed,
            SpacecraftPositionTracker,
            _screenBounds,
            this
        );

        EnemyEvents.EnemyDestroyed += OnUFODestroyed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _ufoController.Hit(collision);
    }

    private void OnUFODestroyed(IEnemy enemy)
    {
        if (!(enemy is UFO))
        {
            return;
        }

        UFO ufo = enemy as UFO;

        if (GetInstanceID() == ufo.GetId())
        {
            Destroy(gameObject);
        }
    }

    public int GetId()
    {
        return GetInstanceID();
    }
}
