using UnityEngine;

public class BaseBehavior : MonoBehaviour, ITransformAdapter
{
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
        // TODO: check Camera.main
        _screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

}
