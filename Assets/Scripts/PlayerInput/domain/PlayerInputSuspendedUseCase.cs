using PlayerInput.domain.model;
using PlayerInput.domain.repositories;
using Zenject;

namespace PlayerInput.domain
{
    public class PlayerInputSuspendedUseCase
    {
        [Inject] private IInputStateRepository inputStateRepository;
        [Inject] private IInputMaskRepository inputMaskRepository;

        public bool GetAxisSuspended(CharacterInputAxis axis)
        {
            var state = inputStateRepository.GetInputState();
            return !inputMaskRepository.GetInputMask(state).InputAvailable(axis);
        }
        
        public bool GetNumericInputSuspended()
        {
            var state = inputStateRepository.GetInputState();
            return !inputMaskRepository.GetInputMask(state).NumericInputAvailable();
        }
    }
}