namespace PlayerInput.domain.model.InputMask
{
    public interface IInputMask
    {
        public bool InputAvailable(CharacterInputAxis axis);
        public bool NumericInputAvailable();
    }
}