using UnityEngine;

namespace Spawn.presentation.Spawner
{
    public interface ISpawnPositionNavigator
    {
        public Transform GetPointTransform(int pointId);
    }
}