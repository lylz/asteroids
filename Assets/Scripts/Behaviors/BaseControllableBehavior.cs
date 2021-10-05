using UnityEngine;

public abstract class BaseControllableBehavior<TController> : MonoBehaviour, ITransformAdapter where TController : IGameObjectController
{
    public abstract TController Controller { get; }

    // TODO: move it somewhere
    protected Vector2 _screenBounds;

    public Vector3 position
    {
        get { return transform.position; }
        set { transform.position = value; }
    }

    public Quaternion rotation
    {
        get { return transform.rotation; }
        set { transform.rotation = value; }
    }

    public Vector3 lookDirection
    {
        get { return transform.up; }
    }

    protected virtual void Awake()
    {
        // TODO: move it somewhere. put it in a singleton, so that it can be calculated once and updated once
        _screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    protected virtual void Start()
    {
    }

    protected virtual void FixedUpdate()
    {
        if (Controller != null)
        {
            Controller.FixedUpdate(Time.fixedDeltaTime);
        }
        else
        {
            Debug.Log("Controller is not initialized in a Controlled MonoBehavior!");
        }
    }

    protected virtual void LateUpdate()
    {
        if (Controller != null)
        {
            Controller.LateUpdate();
        }
        else
        {
            Debug.Log("Controller is not initialized in a Controlled MonoBehavior!");
        }
    }

}
