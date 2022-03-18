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
            Container.Bind<IMatchStateRepository>().To<MatchStateInMemoryRepository>().AsSingle();
            Container.Bind<IMatchTimersDurationRepository>().FromInstance(timersSORepository).AsSingle();
            Container.Bind<IMatchTimerRepository>().To<MatchTimerInMemoryRepository>().AsSingle();
        }
    }
}