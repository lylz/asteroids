public class SpacecraftPositionPostUpdateProcessor : IPostUpdateProcessor
{
    private ISpacecraftPositionTracker _spacecraftPosition;
    private ITransformAdapter _transformAdapter;

    public SpacecraftPositionPostUpdateProcessor(ISpacecraftPositionTracker spacecraftPosition, ITransformAdapter transformAdapter)
    {
        _spacecraftPosition = spacecraftPosition;
        _transformAdapter = transformAdapter;
    }

    public void LateUpdate()
    {
        _spacecraftPosition.Position = _transformAdapter.position;
        _spacecraftPosition.Rotation = _transformAdapter.rotation;
    }
}
