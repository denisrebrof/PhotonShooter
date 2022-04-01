using MatchState.domain;
using MatchState.domain.repositories;
using UniRx;
using UnityEngine;
using Zenject;

namespace MatchState.presentation.DebugComponents
{
    public class MatchStateDebug: MonoBehaviour
    {
        [Inject] private IMatchTimerRepository matchTimerRepository;
        [Inject] private IMatchStateRepository matchStateRepository;
        
        private void Start()
        {
            matchTimerRepository.GetMatchTimeSecondsFlow().Subscribe(time => Debug.Log(time.ToString())).AddTo(this);
            matchStateRepository.GetMatchStateFlow().Subscribe(state => Debug.Log($"New Match State: {state}")).AddTo(this);
        }
    }
}