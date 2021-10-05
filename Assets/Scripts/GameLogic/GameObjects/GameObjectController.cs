using System.Collections.Generic;

public interface IGameObjectController
{
    public void FixedUpdate(float dt);
    public void LateUpdate();
}

public class GameObjectController : IGameObjectController
{
    protected List<IPostUpdateProcessor> _postUpdateProcessors;

    public GameObjectController(IPostUpdateProcessor[] postUpdateProcessors)
    {
        _postUpdateProcessors = new List<IPostUpdateProcessor>(postUpdateProcessors);
    }

    public virtual void FixedUpdate(float dt)
    {
    }

    public void LateUpdate()
    {
        foreach (var postUpdateProcessor in _postUpdateProcessors)
        {
            postUpdateProcessor.LateUpdate();
        }
    }
}
