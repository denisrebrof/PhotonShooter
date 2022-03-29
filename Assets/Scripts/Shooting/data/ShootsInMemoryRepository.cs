using System;
using Shooting.domain;
using Shooting.domain.model;
using UniRx;

namespace Shooting.data
{
    public class ShootsInMemoryRepository: IShootingRepository
    {
        private Subject<Shoot> shootsSubject = new();

        public IObservable<Shoot> GetShotsFlow(string sourceID) => shootsSubject
            .Where(shoot => shoot.PlayerID == sourceID);

        public void AddShoot(Shoot shoot) => shootsSubject.OnNext(shoot);
    }
}