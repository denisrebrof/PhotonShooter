using System.ComponentModel;
using MatchState.data;
using MatchState.domain;
using MatchState.domain.repositories;
using UnityEngine;
using Zenject;

namespace MatchState._di
{
    [CreateAssetMenu(fileName = "MatchStateBaseInstaller", menuName = "Installers/MatchStateBaseInstaller", order = 0)]
    public class MatchStateBaseInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private MatchTimersDurationScriptableObjectRepository timersSORepository;
        
        public override void InstallBindings()
        {
            //Data
            Container.Bind<IMatchStateRepository>().To<MatchStateInMemoryRepository>().AsSingle();
            Container.Bind<IMatchTimersDurationRepository>().FromInstance(timersSORepository).AsSingle();
            Container.Bind<IMatchTimerRepository>().To<MatchTimerInMemoryRepository>().AsSingle();
            //Domain
            Container.Bind<GetMatchStateTimerUpdateRequestsFlowUseCase>().ToSelf().AsSingle();
            Container.Bind<GetNextMatchStateUseCase>().ToSelf().AsSingle();
            Container.Bind<GetTimerStatePerMatchStateFlowUseCase>().ToSelf().AsSingle();
            Container.Bind<MatchStateDurationUseCase>().ToSelf().AsSingle();
            Container.Bind<StartMatchStateUseCase>().ToSelf().AsSingle();
            Container.Bind<StartNextMatchStateUseCase>().ToSelf().AsSingle();
            Container.Bind<TimerCompletedEventFlowUseCase>().ToSelf().AsSingle();
        }
    }
}