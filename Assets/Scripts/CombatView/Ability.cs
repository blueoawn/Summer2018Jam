using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TargetType {Single, Area};
public enum AbilityType {Melee, Projectile};

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

    public AbilityType type;
    public GameObject projectilePrefab;

    public void Use(GameObject target) {
        Debug.Log("Use Ability");
        switch (type) {
          case AbilityType.Projectile:
            useProjectile(target);
            break;
          default:
            target.GetComponent<Combat>().TakeDamage(baseDamage);
            break;
        }
    }

    private void useProjectile(GameObject target) {
        GameObject projectileInstance = Instantiate(projectilePrefab, transform.position, Quaternion.identity) as GameObject; 
        projectileInstance.GetComponent<Projectile>().Fire(target, baseDamage);
    }


}



  

