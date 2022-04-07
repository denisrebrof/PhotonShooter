using Movement.domain.model;
using PlayerInput.domain;
using PlayerInput.domain.model;
using Zenject;

namespace Movement.domain
{
    public class CurrentPlayerMovementStateUseCase
    {
        [Inject] private PlayerInputUseCase inputUseCase;
        [Inject] private IJumpingStateRepository jumpingStateRepository;

        public MovementState GetCurrentMovementState()
        {
            var xAxis = inputUseCase.GetAxis(CharacterInputAxis.HorizontalMovement);
            var yAxis = inputUseCase.GetAxis(CharacterInputAxis.VerticalMovement);
            
            return new MovementState(
                GetMovementStateAxisValue(xAxis),
                GetMovementStateAxisValue(yAxis),
                jumpingStateRepository.IsJumping()
            );
        }

        private int GetMovementStateAxisValue(float inputAxisValue)
        {
            if (inputAxisValue == 0f)
                return 0;

            var baseValue = inputAxisValue > 0f ? 1 : 0;
            var runningMul = inputUseCase.GetAxis(CharacterInputAxis.Running) > 0f ? 2 : 1;
            return baseValue * runningMul;
        }
    }
}