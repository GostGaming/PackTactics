using System;
using Data;
using UnityEngine;
using UnityEngine.Scripting;

namespace Items.Data {
    public interface IWeapon: IItem {
        int range { get; set; }
        Range damageRange { get; set; }
        DamageType damageType { get; set; }
        [RequiredMember]
        GameObject gameObjectPrefab { get; }
    }
}