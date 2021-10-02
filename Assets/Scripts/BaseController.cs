using UnityEngine;

public class BaseController
{
    protected ITransformAdapter _transformAdapter;
    protected Bounds _screenBounds; // won't be supporting dynamic screen size

    public BaseController(ITransformAdapter transformAdapter, Vector2 screenBounds)
    {
        _transformAdapter = transformAdapter;
        _screenBounds = new Bounds(new Vector3(0, 0, 0), screenBounds * 2);
    }

    public virtual void FixedUpdate(float dt)
    {

    }

    public virtual void LateUpdate()
    {
        Vector3 position = _transformAdapter.position;

        if (!_screenBounds.Contains(position))
        {
            Vector3 intersectionPoint = _screenBounds.ClosestPoint(position);

            if (Mathf.Abs(intersectionPoint.x) == Mathf.Abs(_screenBounds.extents.x))
            {
                intersectionPoint.x *= -1;
            }

            if (Mathf.Abs(intersectionPoint.y) == Mathf.Abs(_screenBounds.extents.y))
            {
                intersectionPoint.y *= -1;
            }

            _transformAdapter.position = intersectionPoint;
        }
    }
}
