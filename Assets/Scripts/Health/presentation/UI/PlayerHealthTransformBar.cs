using Health.domain;
using UniRx;
using UnityEngine;
using Utils;
using Zenject;

namespace Health.presentation.UI
{
    public class PlayerHealthTransformBar : MonoBehaviour
    {
        [Inject] private RelativeHealthUseCase relativeHealthUseCase;
        [SerializeField] private Transform target;

        private void Start()
        {
            Debug.Log("HealthProvider: try");
            if (!this.GetPlayerId(out var userId))
                return;
            
            Debug.Log("HealthProvider: " + userId);
            relativeHealthUseCase
                .GetRelativeHealthFlow(userId)
                .Subscribe(ApplyHealth)
                .AddTo(this);
        }
        private void ApplyHealth(float relativeHealth) => target.localScale = new Vector3(relativeHealth, 1, 1);
    }
}