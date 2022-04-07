using MatchTimer.data;
using MatchTimer.domain;
using MatchTimer.domain.repositories;
using UnityEngine;
using Zenject;

namespace MatchTimer._di
{
    [CreateAssetMenu(menuName = "Installers/MatchTimerBaseInstaller")]
    internal class MatchTimerBaseInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            //Data
            Container.Bind<IMatchTimerRepository>()
                .To<MatchTimerSceneRepository>()
                .FromNewComponentOnNewGameObject()
                .AsSingle();
            //Domain
            Container.Bind<TimerCompletedEventUseCase>().ToSelf().AsSingle();
        }
    }
}