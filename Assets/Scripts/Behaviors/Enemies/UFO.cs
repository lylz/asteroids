using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class UFO : Enemy, IUFO
{
    [Header("UFO Config")]
    public float Speed;
    [SerializeField]
    private int _scorePoints;

    [Header("Dependencies")]
    public ScreenBounds ScreenBounds;
    public PlayerEvents PlayerEvents;
    public EnemyEvents EnemyEvents;
    public SpacecraftPositionTracker SpacecraftPositionTracker;

    private UFOController _ufoController;

    public override IGameObjectController Controller => _ufoController;
    public override int ScorePoints { get => _scorePoints; }

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
