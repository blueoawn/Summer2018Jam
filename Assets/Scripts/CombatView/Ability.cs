using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TargetType {Single, Area};

public class Ability : MonoBehaviour {
    public float cooldownSeconds;

    public float weaponDamageCoefficient;    
    public int baseDamage;

    public float weaponHealingCoefficient;
    public int baseHealing;

    public TargetType targetType;

    public int spRequired;

    public GameObject effectApplied;
    public float effectApplyChance;

    public void Use(GameObject target) {
        target.GetComponent<Combat>().TakeDamage(baseDamage);
    }


}


  

