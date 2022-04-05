using CharacterInput.domain.model;

namespace CharacterInput.domain.repositories
{
    public interface IInputStateRepository
    {
        public CharacterInputState GetInputState();
    }
}