using CharacterInput.domain.model;
using CharacterInput.domain.repositories;
using Zenject;

namespace CharacterInput.domain
{
    public class InputSuspendedUseCase
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