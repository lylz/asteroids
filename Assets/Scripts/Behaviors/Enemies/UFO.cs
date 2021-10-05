using UnityEngine;

public class UFO : BaseControllableBehavior<UFOController>, IUFO
{
    public UFOEvents UFOEvents;

    [SerializeField]
    private float _speed;

    [SerializeField]
    private SpacecraftPositionTracker _spacecraftPosition;

    private UFOController _ufoController;

    public override UFOController Controller => _ufoController;

    protected override void Awake()
    {
        base.Awake();

        _ufoController = new UFOController(
            UFOEvents,
            this,
            _speed,
            _spacecraftPosition,
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
