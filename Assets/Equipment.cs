using UnityEngine;
using System.Collections;

public interface IEquipment {

    string equipmentName { get; set; }
    int equipmentValue { get; set; }

    void equipEffect();
    void unequipEffect();


}
