using Movement.domain;
using Movement.domain.model;
using Zenject;

namespace Movement.presentation.SyncHandler
{
    public class PlayerMovementStateSyncHandler: MovementStateSyncHandler
    {
        [Inject] private CurrentPlayerMovementStateUseCase movementStateUseCase;
        protected override string HandlerId => photonView.Controller.UserId;
        protected override MovementState CurrentState => movementStateUseCase.GetCurrentMovementState();
    }
}