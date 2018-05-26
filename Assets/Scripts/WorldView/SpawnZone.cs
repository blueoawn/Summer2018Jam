using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZone : MonoBehaviour {
    public GameObject enemy;
    public float chance;
    private int counter = 0;
    public int framesPerSpawnChance;

    private GameObject party;

    public void Start() {
        party = GameObject.Find("Party");
        if (party == null) 
            Debug.LogError("SpawnZone cannot exist without a Party GameObject");
    }

    public void OnTriggerStay(Collider other) {
        if (other.gameObject.GetComponent<PartyMember>()) {
            counter++;
            if (counter > framesPerSpawnChance) {
                attemptToSpawn();
                counter = 0;
            }
        }
    }

    private void attemptToSpawn() {

        if (Random.value > chance) {
            GameObject[] enemies = {enemy};
            party.GetComponent<Party>().InitiateCombat(enemies);
        }
    }

}
