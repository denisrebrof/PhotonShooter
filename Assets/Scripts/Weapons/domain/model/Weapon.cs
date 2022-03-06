namespace Weapons.domain.model
{
    public class Weapon
    {
        public long ID;
        public string Name;
        public int AmmoCapacity;
        public DamageType Type;

        public Weapon(long id, string name, int ammoCapacity, DamageType type)
        {
            ID = id;
            Name = name;
            AmmoCapacity = ammoCapacity;
            Type = type;
        }

        public enum DamageType
        {
            Melee,
            Ranged
        }
    }
}