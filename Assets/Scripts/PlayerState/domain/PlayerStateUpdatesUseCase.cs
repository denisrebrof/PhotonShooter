using System;
using System.Linq;
using MatchState.domain.model;
using MatchState.domain.repositories;
using PlayerState.domain.model;
using PlayerState.domain.repositories;
using UniRx;
using Zenject;

namespace PlayerState.domain
{
    internal class PlayerStateUpdatesUseCase
    {
        [Inject] private IMatchStateRepository matchStateRepository;
        [Inject] private IPlayerLifecycleEventRepository lifecycleEventRepository;

        private MatchStates[] idleStates = { MatchStates.Preparing, MatchStates.Finished };

        public IObservable<PlayerStates> GetPlayerStateUpdatesFlow() => matchStateRepository
            .GetMatchStateFlow()
            .Select(GetPlayerStateUpdatesFlow)
            .Switch();

        private IObservable<PlayerStates> GetPlayerStateUpdatesFlow(MatchStates matchState)
        {
            if (idleStates.Contains(matchState)) return Observable.Return(PlayerStates.Idle);
            if (matchState != MatchStates.Playing) return Observable.Return(PlayerStates.None);
            var gameplayPlayerStatesFlow = lifecycleEventRepository.GetLifecycleEvents().Select(GetNewPlayerState);
            return gameplayPlayerStatesFlow.Merge(Observable.Return(PlayerStates.Spawning));
        }

        private static PlayerStates GetNewPlayerState(PlayerLifecycleEvent lifecycleEvent) => lifecycleEvent switch
        {
            PlayerLifecycleEvent.Spawned => PlayerStates.Playing,
            PlayerLifecycleEvent.Died => PlayerStates.Dead,
            PlayerLifecycleEvent.Ready => PlayerStates.Spawning,
            _ => throw new ArgumentOutOfRangeException(nameof(lifecycleEvent), lifecycleEvent, null)
        };
    }
}