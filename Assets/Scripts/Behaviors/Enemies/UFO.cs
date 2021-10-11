using UnityEngine;

public class UFO : Enemy, IUFO
{
    public ScreenBounds ScreenBounds;
    public PlayerEvents PlayerEvents;
    public EnemyEvents EnemyEvents;
    public float Speed;
    public SpacecraftPositionTracker SpacecraftPositionTracker;
    public override int ScorePoints { get => _scorePoints; }

    [SerializeField]
    private int _scorePoints;
    private UFOController _ufoController;

    public override IGameObjectController Controller => _ufoController;

    protected override void Start()
    {
        base.Start();

        _ufoController = new UFOController(
            PlayerEvents,
            EnemyEvents,
            this,
            Speed,
            SpacecraftPositionTracker,
            ScreenBounds,
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

    private void OnDestroy()
    {
        EnemyEvents.EnemyDestroyed -= OnUFODestroyed;
    }
}
