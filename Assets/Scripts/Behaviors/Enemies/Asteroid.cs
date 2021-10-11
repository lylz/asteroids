using UnityEngine;

public class Asteroid : Enemy, IAsteroid
{
    public EnemyEvents EnemyEvents;
    public AsteroidConfig AsteroidConfig;
    public override int ScorePoints { get => _scorePoints; }

    [SerializeField]
    private int _scorePoints;
    private AsteroidController _asteroidController;

    public override IGameObjectController Controller => _asteroidController;

    protected override void Start()
    {
        base.Start();

        _asteroidController = new AsteroidController(
            EnemyEvents,
            this,
            _screenBounds,
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
}
