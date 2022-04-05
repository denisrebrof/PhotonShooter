using System;
using CharacterInput.domain.model;
using CharacterInput.domain.repositories;
using UniRx;
using UnityEngine;
using Utils;

namespace CharacterInput.data
{
    internal class CharacterInputSceneRepository : MonoBehaviour, ICharacterInputRepository
    {
        public bool GetSelection(out int selection) => NumericInput.GetNumericInput(out selection);

        public float GetAxis(CharacterInputAxis axis) => axis switch
        {
            CharacterInputAxis.Shooting => Input.GetMouseButton(0) ? 1f : 0f,
            CharacterInputAxis.HorizontalLook => Input.GetAxisRaw("Mouse X"),
            CharacterInputAxis.VerticalLook => Input.GetAxisRaw("Mouse Y"),
            CharacterInputAxis.HorizontalMovement => Input.GetAxis("Horizontal"),
            CharacterInputAxis.VerticalMovement => Input.GetAxis("Vertical"),
            CharacterInputAxis.Running => Input.GetKey(KeyCode.LeftShift) ? 1f : 0f,
            CharacterInputAxis.SwitchWeaponUp =>  Input.mouseScrollDelta.y > 0f ? 1f : 0f,
            CharacterInputAxis.SwitchWeaponDown => Input.mouseScrollDelta.y < 0f ? 1f : 0f,
            CharacterInputAxis.Reload => Input.GetKeyDown(KeyCode.R)? 1f : 0f,
            CharacterInputAxis.Jump => Input.GetKeyDown(KeyCode.Space)? 1f : 0f,
            _ => throw new ArgumentOutOfRangeException(nameof(axis), axis, null)
        };
    }
}