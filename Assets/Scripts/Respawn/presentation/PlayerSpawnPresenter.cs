using Respawn.domain.repositories;
using UniRx;
using UnityEngine;
using Zenject;

namespace Respawn.presentation
{
    public class PlayerSpawnPresenter : MonoBehaviour
    {
        [Inject] private ICurrentPlayerSpawnEventRepository spawnEventRepository;
        [Inject] private ISpawnPositionNavigator spawnPositionNavigator;

        private Transform player;

        private void Awake()
        {
            player = transform;
            spawnEventRepository
                .GetSpawnEventFlow()
                .Select(spawnEvent => spawnEvent.PointId)
                .Select(spawnPositionNavigator.GetPointTransform)
                .Subscribe(Spawn)
                .AddTo(this);
        }

        private void Spawn(Transform point)
        {
            player.position = point.position;
            player.rotation = point.rotation;
        }
    }
}