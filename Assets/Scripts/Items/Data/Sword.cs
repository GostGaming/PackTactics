using System;
using Data;
using UnityEngine;
using UnityEngine.Scripting;

namespace Items.Data {
    public class Sword: IWeapon {
        public string itemId => "2";
        public string itemName => "Sword";
        public string description => "Sword";
        public int range { get; set; } = 2;
        public Range damageRange { get; set; } = new Range(1, 10);
        public DamageType damageType { get; set; } = DamageType.PIERCE;
        [RequiredMember]
        public GameObject gameObjectPrefab { get; }
    }
}