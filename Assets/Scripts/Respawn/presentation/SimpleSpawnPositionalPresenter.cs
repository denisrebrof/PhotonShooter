using Respawn.domain.model;
using Respawn.domain.repositories;
using UniRx;
using UnityEngine;
using Zenject;

namespace Respawn.presentation
{
    public class SimpleSpawnPositionalPresenter : MonoBehaviour
    {
        [Inject] private ISpawnPointRepository spawnPointRepository;
        [Inject] private ICurrentPlayerSpawnEventRepository spawnEventRepository;
        [SerializeField] private Transform[] spawnPoints;
        [SerializeField] private int defaultSpawnCooldown = 10;

        private void Awake()
        {
            for (var i = 0; i < spawnPoints.Length - 1; i++)
            {
                var point = new SpawnPoint(i, defaultSpawnCooldown);
                spawnPointRepository.AddSpawnPoint(point);
            }

            spawnEventRepository
                .GetSpawnEventFlow()
                .Select(spawnEvent => spawnPoints[spawnEvent.PointId].position)
                .Subscribe(position => GameObject.FindWithTag("Player").transform.position = position)
                .AddTo(this);
        }
    }
}