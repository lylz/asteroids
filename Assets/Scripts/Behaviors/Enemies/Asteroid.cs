using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Asteroid : Enemy, IAsteroid
{
    [Header("Asteroid Config")]
    public AsteroidConfig AsteroidConfig;
    [SerializeField]
    private int _scorePoints;

    [Header("Dependencies")]
    public ScreenBounds ScreenBounds;
    public EnemyEvents EnemyEvents;
    
    private AsteroidController _asteroidController;

    public override IGameObjectController Controller => _asteroidController;
    public override int ScorePoints { get => _scorePoints; }

    protected override void Start()
    {
        base.Start();

        _asteroidController = new AsteroidController(
            EnemyEvents,
            this,
            ScreenBounds,
            this
        );
        
        EnemyEvents.EnemyDestroyed += OnAsteroidDestroyed;
        Scale();
    }

    private void Scale()
    {
        float scale = AsteroidConfig.Scale;

        transform.localScale = new Vector2(scale, scale);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _asteroidController.Hit(collision);
    }

    private void OnAsteroidDestroyed(IEnemy enemy)
    {
        if (!(enemy is Asteroid))
        {
            return;
        }

        Asteroid asteroid = enemy as Asteroid;

        if (GetInstanceID() != asteroid.GetId())
        {
            return;
        }

        Destroy(gameObject);
    }
    public int GetId()
    {
        return GetInstanceID();
    }

    public IAsteroidConfig GetAsteroidConfig()
    {
        return AsteroidConfig;
    }

    private void OnDestroy()
    {
        EnemyEvents.EnemyDestroyed -= OnAsteroidDestroyed;
    }
}
