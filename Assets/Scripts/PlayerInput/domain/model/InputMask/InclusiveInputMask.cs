using System.Collections.Generic;

namespace PlayerInput.domain.model.InputMask
{
    public class InclusiveInputMask : IInputMask
    {
        private List<CharacterInputAxis> axisList;
        private bool numeric;

        public InclusiveInputMask(
            List<CharacterInputAxis> axisList,
            bool numeric = false
        )
        {
            this.axisList = axisList;
            this.numeric = numeric;
        }

        public InclusiveInputMask()
        {
            axisList = new List<CharacterInputAxis>();
            numeric = false;
        }

        public bool InputAvailable(CharacterInputAxis axis) => axisList.Contains(axis);

        public bool NumericInputAvailable() => numeric;
    }
}