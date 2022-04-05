namespace CharacterInput.domain.model
{
    public interface IInputMask
    {
        public bool InputAvailable(CharacterInputAxis axis);
        public bool NumericInputAvailable();
    }
}