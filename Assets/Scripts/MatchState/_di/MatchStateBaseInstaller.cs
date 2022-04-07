using System.ComponentModel;
using MatchState.data;
using MatchState.domain;
using MatchState.domain.repositories;
using MatchState.presentation.SyncHandler;
using MatchTimer.data;
using MatchTimer.domain.repositories;
using UnityEngine;
using Zenject;

namespace MatchState._di
{
    [CreateAssetMenu(fileName = "MatchStateBaseInstaller", menuName = "Installers/MatchStateBaseInstaller", order = 0)]
    internal class MatchStateBaseInstaller : ScriptableObjectInstaller
    {
        // ReSharper disable once InconsistentNaming
        [SerializeField] private MatchStateDurationScriptableObjectRepository stateSoRepository;
        public override void InstallBindings()
        {
            //Data
            Container.Bind<IMatchStateDurationRepository>().FromInstance(stateSoRepository).AsSingle();
            Container.Bind<IMatchStateRepository>().To<MatchStateInMemoryRepository>().AsSingle();//Domain
            Container.Bind<MatchStateUpdatesUseCase>().ToSelf().AsSingle();
            Container.Bind<NextMatchStateUseCase>().ToSelf().AsSingle();
            Container.Bind<MatchStateTimerStateFlowUseCase>().ToSelf().AsSingle();
            Container.Bind<StartMatchStateUseCase>().ToSelf().AsSingle();
            //Presentation
            Container.Bind<RoomMatchStateParamsNavigator>().ToSelf().AsSingle();
        }
    }
}