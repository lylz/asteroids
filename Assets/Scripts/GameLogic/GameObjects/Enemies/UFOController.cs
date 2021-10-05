using UnityEngine;

public class UFOController : GameObjectController 
{
    private IUFOEvents _ufoEvents;
    private IUFO _ufo;
    private float _speed;
    private ISpacecraftPositionTracker _spacecraftPosition;
    private ITransformAdapter _transformAdapter;

    // TODO: screen bounds can be moved to the scriptable object?!
    public UFOController(
        IUFOEvents ufoEvents,
        IUFO ufo,
        float speed,
        ISpacecraftPositionTracker spacecraftPosition,
        Vector2 screenBounds,
        ITransformAdapter transformAdapter
    )
        : base(new IPostUpdateProcessor[] { new PortalPostUpdateProcessor(screenBounds, transformAdapter) })
    {
        _ufoEvents = ufoEvents;
        _ufo = ufo;
        _speed = speed;
        _spacecraftPosition = spacecraftPosition;
        _transformAdapter = transformAdapter;

        GameController.GetInstance().UFOs.Add(_ufo);
    }

    public override void FixedUpdate(float dt)
    {
        base.FixedUpdate(dt);

        // TODO: bug with multiple UFOs. multiple UFOs while trying to follow the player end up merging in to one single UFO. happens because the movement end up the same after some of the player moves
        // TODO: need to adjust the movement behavior, probably shouldn't be just as straight as it is right now
        // TODO: implement idle state, when the player is dead and there is nobody to follow
        Vector3 moveDirection = _spacecraftPosition.Position - _transformAdapter.position;
        _transformAdapter.position += moveDirection.normalized * _speed * dt;
    }

    public void Hit(Collider2D collision)
    {
        Die();
    }

    private void Die()
    {
        GameController.GetInstance().UFOs.Remove(_ufo);
        _ufoEvents.InvokeUFODestroyed(_ufo);
    }
}
