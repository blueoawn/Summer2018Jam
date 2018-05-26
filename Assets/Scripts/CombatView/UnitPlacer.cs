using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitPlacer : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject party = GameObject.Find("Party");
        GameObject enemies = GameObject.Find("Enemies");
        GameObject unitslots = GameObject.Find("UnitSlots");

        Transform[] partySlots = unitslots.transform.Find("Party").GetComponentsInChildren<Transform>();
        Transform[] enemySlots = unitslots.transform.Find("Enemy").GetComponentsInChildren<Transform>();


        int i = 0;
        foreach (GameObject partyMember in party.GetComponent<Party>().partyMembers) {
            Debug.Log("place", partyMember);
            partyMember.GetComponent<HeroMove>().enabled = false;

            partyMember.GetComponent<NavMeshAgent>().enabled = false;
            Vector3 targetPosition = partySlots[i % partySlots.Length].position;
            /* partyMember.GetComponent<NavMeshAgent>().SetDestination(targetPosition); */
            partyMember.transform.position = targetPosition;
            i++;
        }
        i = 0;
        foreach (Transform enemy in enemies.GetComponentsInChildren<Transform>()) {
            enemy.position = enemySlots[i % enemySlots.Length].position;
            i++;
        }

		
	}
	
}
