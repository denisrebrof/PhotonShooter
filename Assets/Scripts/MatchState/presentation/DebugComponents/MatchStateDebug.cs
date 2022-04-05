using MatchState.domain.repositories;
using UniRx;
using UnityEngine;
using Zenject;

namespace MatchState.presentation.DebugComponents
{
    public class MatchStateDebug : MonoBehaviour
    {
        [SerializeField] private bool logState = true;
        [SerializeField] private bool logTimer = true;
        [Inject] private IMatchTimerRepository matchTimerRepository;
        [Inject] private IMatchStateRepository matchStateRepository;

        private void Awake()
        {
            matchTimerRepository
                .GetMatchTimeSecondsFlow()
                .Where(_ => logTimer)
                .Subscribe(time =>
                    Debug.Log(time.ToString())
                ).AddTo(this);
            matchStateRepository
                .GetMatchStateFlow()
                .Where(_ => logState)
                .Subscribe(state =>
                    Debug.Log($"New Match State: {state}")
                ).AddTo(this);
        }
    }
}