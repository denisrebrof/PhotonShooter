using Respawn.domain.model;
using Respawn.domain.repositories;
using UnityEngine;
using Zenject;

namespace Respawn.presentation
{
    public class SimpleSpawnPoints : MonoBehaviour, ISpawnPositionNavigator
    {
        [Inject] private ISpawnPointRepository spawnPointRepository;
        [SerializeField] private Transform[] spawnPoints;
        [SerializeField] private int defaultSpawnCooldown = 10;

        private void Awake()
        {
            for (var i = 0; i < spawnPoints.Length - 1; i++)
            {
                var point = new SpawnPoint(i, defaultSpawnCooldown);
                spawnPointRepository.AddSpawnPoint(point);
            }
        }

        public Transform GetPointTransform(int pointId) => spawnPoints[pointId];
    }
}