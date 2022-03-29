using Health.domain.repositories;
using Photon.Pun;
using UniRx;
using UnityEngine;
using UnityEngine.Events;
using Utils;
using Zenject;

namespace Health.presentation
{
    public class ScenePlayerHealthProvider : MonoBehaviour
    {
        [Inject] private IHealthHandlersRepository healthHandlersRepository;
        [SerializeField] private UnityEvent<int> onHealthChanged;

        private void Start()
        {
            Debug.Log("HealthProvider: try");
            if (!this.GetPlayerId(out var userId))
                return;
            
            Debug.Log("HealthProvider: " + userId);
            healthHandlersRepository
                .GetHealthFlow(userId)
                .Subscribe(onHealthChanged.Invoke)
                .AddTo(this);
        }
    }
}