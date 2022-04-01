using UnityEngine;

namespace Respawn.presentation
{
    public interface ISpawnPositionNavigator
    {
        public Transform GetPointTransform(int pointId);
    }
}