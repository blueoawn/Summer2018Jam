//Any unit which can engage in combat should have this script. It primarily handles health, SP and ability usage
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Combat : MonoBehaviour {

    public int maxHP;
    private int currentHP;

    public int maxSP;
    private int currentSP;

    public GameObject abilityPrefab;
    private GameObject abilityInstance;

    private bool alive = true;

    public void Start () {
        currentHP = maxHP;
        currentSP = maxSP;
        if (abilityPrefab) {
            abilityInstance = Instantiate(abilityPrefab) as GameObject;
            abilityInstance.transform.SetParent(transform);
        }
        updateHealthBar();
    }

    public void TakeDamage(int amount) {
        this.currentHP -= amount;
        if (this.currentHP <= 0) {
            die();
        }
        updateHealthBar();
    }

    private void updateHealthBar() {
        float val = this.maxHP > 0 ? (float)this.currentHP / this.maxHP : 0;
        gameObject.transform.Find("UnitWorldUI").GetComponent<UnitWorldUI>().SetHealthBarValue(val);
    }

    private void die() {
        this.alive = false;
    }

    public bool UseAbility() {
        if (!alive) return false;
        if (!abilityInstance) return false;

        GameObject target = null;
        if (gameObject.GetComponent<PartyMember>()) {
            Party party = gameObject.GetComponent<PartyMember>().Party;
            target = party.GetTarget();
        } else {
            //enemy
        }

        if (target != null) {
            abilityInstance.GetComponent<Ability>().Use(target);
        }

        return true;
    }


}
