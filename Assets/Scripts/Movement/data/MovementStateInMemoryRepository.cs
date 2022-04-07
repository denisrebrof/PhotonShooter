using System;
using Movement.domain;
using Movement.domain.model;
using UniRx;
using Utils;
using Utils.Reactive;

namespace Movement.data
{
    public class MovementStateInMemoryRepository: IMovementStateRepository
    {
        private readonly ReactiveDictionary<string, MovementState> movableIdToStateMap = new();

        public MovementState GetMovementState(string movableID)=> movableIdToStateMap[movableID];

        public IObservable<MovementState> GetMovementStateFlow(string movableID) => movableIdToStateMap
            .GetItemFlow(movableID)
            .DistinctUntilChanged();

        void IMovementStateRepository.SetMovementState(string movableID, MovementState state) => movableIdToStateMap[movableID] = state;
    }
}