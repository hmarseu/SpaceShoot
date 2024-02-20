using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ShotPattern : ScriptableObject, ISerializationCallbackReceiver
{
    [SerializeField] List<Vector3> _positions;
    [SerializeField] List<Vector3> _directions;
    
    [field: SerializeField] public int MissileCount { get; private set; }

    public List<(Vector3 position, Vector3 direction)> Missiles { get; } = new List<(Vector3 position, Vector3 direction)>();

    public void OnBeforeSerialize() { }

    public void OnAfterDeserialize()
    {
        if (_positions.Count != _directions.Count)
            return;

        for (var i = 0; i < _positions.Count; i++)
        {
            var position = _positions[i];
            var direction = _directions[i];
            
            Missiles.Add((position, direction));
        }
    }
}