using UnityEngine;

public class UFO : Enemy, IUFO
{
    public UFOEvents UFOEvents;
    public float Speed;
    public SpacecraftPositionTracker SpacecraftPositionTracker;

    private UFOController _ufoController;

    public override IGameObjectController Controller => _ufoController;

    protected override void Start()
    {
        base.Start();

        _ufoController = new UFOController(
            GameManager.Instance.GameController,
            UFOEvents,
            this,
            Speed,
            SpacecraftPositionTracker,
            _screenBounds,
            this
        );

        UFOEvents.UFODestroyed += OnUFODestroyed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _ufoController.Hit(collision);
    }

    private void OnUFODestroyed(IUFO ufo)
    {
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
