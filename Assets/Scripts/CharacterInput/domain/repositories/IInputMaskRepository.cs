using CharacterInput.domain.model;

namespace CharacterInput.domain.repositories
{
    public interface IInputMaskRepository
    {
        public IInputMask GetInputMask(InputState state);
    }
}