using System;
using MatchState.domain.model;
using MatchState.domain.repositories;
using SpawnPoints.domain.repositories;
using UniRx;
using Zenject;

namespace SpawnPoints.domain
{
    public class SpawnPointCooldownUseCase
    {
        [Inject] private IMatchStateRepository matchStateRepository;
        [Inject] private ISpawnPointApplyCooldownEventRepository cooldownEventRepository;
        
        public IObservable<int> GetCooldownFlow(int pointId) => matchStateRepository
            .GetMatchStateFlow()
            .Select(matchState => GetCooldownFlow(matchState, pointId))
            .Switch();

        private IObservable<int> GetCooldownFlow(MatchStates matchState, int pointId)
        {
            if (matchState != MatchStates.Playing) return Observable.Return(0);
            var setCooldownFlow = cooldownEventRepository
                .GetApplyCooldownEventFlow()
                .Where(cooldownEvent => cooldownEvent.PointId == pointId)
                .Select(cooldownEvent => cooldownEvent.Cooldown);

            return setCooldownFlow.Select(CreateCountdown).Switch();
        }

        private static IObservable<int> CreateCountdown(int seconds) => Observable.Create<int>(observer =>
        {
            if (seconds == 0)
            {
                observer.OnNext(0);
                observer.OnCompleted();
                return Disposable.Empty;
            }

            var span = TimeSpan.FromSeconds(1);
            return Observable
                .Timer(span)
                .Repeat()
                .Select(_ => --seconds)
                .StartWith(seconds)
                .TakeWhile(cooldownLeft => cooldownLeft >= 0)
                .Subscribe(cooldownLeft =>
                {
                    observer.OnNext(cooldownLeft);
                    if (cooldownLeft != 0) return;
                    observer.OnCompleted();
                });
        });
    }
}