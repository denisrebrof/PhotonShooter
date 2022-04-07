using PlayerInput.domain.model;

namespace PlayerInput.domain.repositories
{
    public interface IInputStateRepository
    {
        public CharacterInputState GetInputState();
    }
}