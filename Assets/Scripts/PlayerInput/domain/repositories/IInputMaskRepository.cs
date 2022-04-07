using PlayerInput.domain.model;
using PlayerInput.domain.model.InputMask;

namespace PlayerInput.domain.repositories
{
    public interface IInputMaskRepository
    {
        public IInputMask GetInputMask(CharacterInputState state);
    }
}