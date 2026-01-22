using Data;
using Items.Data;
using UnityEngine.Scripting;

namespace Units.Data {
    public interface ICharacterUnit {
        // current health
        int health { get; set; }
        int maxHealth { get; set; }
        // damage for melee weapons
        int strength { get; set; }
        // damage for ranged weapons
        int dexterity { get; set; }
        // turn order
        int initiative { get; set; }
        // Range of motion for the character
        int speed { get; set; }
        [RequiredMember]
        UnitType unitType { get; }
        IWeapon equippedWeapon { get; set; }
    }
}