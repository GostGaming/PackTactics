using Data;
using Items.Data;
using UnityEngine;
using UnityEngine.Scripting;

namespace Units.Data {
    public class PlayerUnit: MonoBehaviour, ICharacterUnit {
        public int health { get; set; } = PlayerConstants.DEFAULT_MAX_HEALTH;
        public int maxHealth { get; set; } = PlayerConstants.DEFAULT_MAX_HEALTH;
        public int strength { get; set; } = PlayerConstants.DEFAULT_STR;
        public int dexterity { get; set; } = PlayerConstants.DEFAULT_DEX;
        public int initiative { get; set; } = PlayerConstants.DEFAULT_INIT;
        public int speed { get; set; } =  PlayerConstants.DEFAULT_SPEED;
        [RequiredMember] public UnitType unitType { get; } = UnitType.PLAYER_CHARACTER;

        public IWeapon equippedWeapon { get; set; } = new Fists();

        void Start() {
            
        }
    }
    
}