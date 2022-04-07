using System.Collections.Generic;

namespace PlayerInput.domain.model.InputMask
{
    public class ExclusiveInputMask: IInputMask
    {
        private List<CharacterInputAxis> axisList;
        private bool numeric;

        public ExclusiveInputMask(
            List<CharacterInputAxis> axisList,
            bool excludeNumeric = true
        )
        {
            this.axisList = axisList;
            numeric = excludeNumeric;
        }
        
        public ExclusiveInputMask()
        {
            axisList = new List<CharacterInputAxis>();
            numeric = false;
        }

        public bool InputAvailable(CharacterInputAxis axis) => !axisList.Contains(axis);

        public bool NumericInputAvailable() => !numeric;
    }
}