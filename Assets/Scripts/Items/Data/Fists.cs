using System;
using Data;
using UnityEngine;
using UnityEngine.Scripting;

namespace Items.Data {
    public class Fists: IWeapon {
        public string itemId => "1";
        public string itemName => "Fists";
        public string description => "Just using your hands";
        public int range { get; set; } = 1;
        public Range damageRange { get; set; } = new Range(1, 2);
        public DamageType damageType { get; set; } = DamageType.BLUDGEON;
        [RequiredMember]
        public GameObject gameObjectPrefab { get; }
    }
}