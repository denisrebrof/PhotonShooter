using System;
using MatchState.domain.model;
using MatchState.domain.repositories;
using MatchTimer.domain.repositories;
using UniRx;
using Zenject;

namespace MatchState.domain
{
    public class StartMatchStateUseCase
    {
        [Inject] private IMatchStateDurationRepository matchStateDurationRepository;
        [Inject] private IMatchStateRepository matchStateRepository;
        [Inject] private IMatchTimerRepository matchTimerRepository;

        public void StartMatchState(MatchStates state, int timeLeft = 0)
        {
            matchStateRepository.SetMatchState(state);
            matchTimerRepository.StopTimer();

            timeLeft = Math.Max(0, timeLeft);
            if (!matchStateDurationRepository.GetStateDuration(state, out var duration)) return;
            matchTimerRepository.StartTimer(duration - timeLeft);
        }
    }
}