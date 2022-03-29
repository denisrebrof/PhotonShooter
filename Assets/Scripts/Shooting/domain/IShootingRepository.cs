using System;
using Shooting.domain.model;

namespace Shooting.domain
{
    public interface IShootingRepository
    {
        public IObservable<Shoot> GetShotsFlow(string sourceID);
        public void AddShoot(Shoot shoot);
    }
}