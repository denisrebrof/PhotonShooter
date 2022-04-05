using Respawn.domain.model;
using Respawn.domain.repositories;
using UnityEngine;
using Zenject;

namespace Respawn.presentation.Spawner
{
    public class SimpleSpawnPoints : MonoBehaviour, ISpawnPositionNavigator
    {
        [Inject] private ISpawnPointRepository spawnPointRepository;
        [SerializeField] private SpawnPointView[] spawnPoints;
        [SerializeField] private int defaultSpawnCooldown = 10;

        private void Awake()
        {
            for (var i = 0; i < spawnPoints.Length; i++)
            {
                var point = new SpawnPoint(i, defaultSpawnCooldown);
                spawnPointRepository.AddSpawnPoint(point);
                spawnPoints[i].Setup(i);
            }
        }

        public Transform GetPointTransform(int pointId) => spawnPoints[pointId].transform;
    }
}