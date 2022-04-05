using System;
using CharacterInput.domain.model;
using UniRx;

namespace CharacterInput.domain.repositories
{
    internal interface ICharacterInputRepository
    {
        public bool GetSelection(out int selection);
        public float GetAxis(CharacterInputAxis axis);
    }
}