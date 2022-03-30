using System;
using UnityEngine;
using Weapons.domain;
using Weapons.domain.model;

namespace Weapons.data.models
{
    [Serializable]
    public class WeaponEntity
    {
        public string Name;
        public int AmmoCapacity;
        public int PerMinuteRate;
        public Weapon.DamageType Type;
        public Sprite preview;
        public GameObject prefab;
    }
}