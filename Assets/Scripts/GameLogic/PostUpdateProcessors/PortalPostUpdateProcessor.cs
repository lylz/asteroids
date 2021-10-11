using UnityEngine;

public class PortalPostUpdateProcessor : IPostUpdateProcessor
{
    private ITransformAdapter _transformAdapter;
    private Bounds _screenBounds;

    public PortalPostUpdateProcessor(IScreenBounds screenBounds, ITransformAdapter transformAdapter)
    {
        _screenBounds = new Bounds(new Vector3(), screenBounds.Bounds);
        _transformAdapter = transformAdapter;
    }

    public void LateUpdate()
    {
        if (!_screenBounds.Contains(_transformAdapter.position))
        {
            Vector3 intersectionPoint = _screenBounds.ClosestPoint(_transformAdapter.position);

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
