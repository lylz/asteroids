using UnityEngine;

public interface ITransformAdapter
{
    Vector3 position { get; set; }
    Quaternion rotation { get; set; }
    Vector3 lookDirection { get; }
}
