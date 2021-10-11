using UnityEngine;

public abstract class ControllableBehavior : MonoBehaviour, ITransformAdapter
{
    public abstract IGameObjectController Controller { get; }

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
