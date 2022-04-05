using System.Collections.Generic;
using Respawn.domain.model;
using UnityEngine;

namespace Respawn.presentation.Spawner
{
    public interface ISpawnPositionNavigator
    {
        public Transform GetPointTransform(int pointId);
    }
}