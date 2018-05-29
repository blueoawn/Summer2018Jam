//This script is responsible for placing the party members and enemies into their correct positions for battle mode.
//it also sets up the UI buttons for the party member abilities
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class UnitPlacer : MonoBehaviour {

    public GameObject AbilityButtonPrefab;

    private GameObject partyAbilityButtonParent;

	void Start () {
        GameObject party = GameObject.Find("Party");
        GameObject enemies = GameObject.Find("Enemies");
        GameObject unitslots = GameObject.Find("UnitSlots");
        Party partyScript = party.GetComponent<Party>();
        partyAbilityButtonParent = GameObject.Find("PartyAbilityButtons");

        Transform[] partySlots = unitslots.transform.Find("Party").GetComponentsInChildren<Transform>();
        Transform[] enemySlots = unitslots.transform.Find("Enemy").GetComponentsInChildren<Transform>();


        Transform[] abilityButtonSlots = partyAbilityButtonParent.GetComponentsInChildren<Transform>();

        int i = 0;
        foreach (GameObject partyMember in party.GetComponent<Party>().partyMembers) {
            partyMember.GetComponent<HeroMove>().enabled = false;

            partyMember.GetComponent<NavMeshAgent>().enabled = false;
            Vector3 targetPosition = partySlots[(i + 1) % partySlots.Length].position;
            /* partyMember.GetComponent<NavMeshAgent>().SetDestination(targetPosition); */
            partyMember.transform.position = targetPosition;

            GameObject abilityButton = Instantiate(AbilityButtonPrefab) as GameObject;
            abilityButton.transform.SetParent(partyAbilityButtonParent.transform);
            abilityButton.transform.position = abilityButtonSlots[i + 1].position;

            Combat partyMemberCombat = partyMember.GetComponent<Combat>();
            abilityButton.GetComponent<Button>().onClick.AddListener(delegate { partyMemberCombat.UseAbility(); } );
            i++;
        }
        i = 0;
        foreach (Transform enemy in enemies.GetComponentsInChildren<Transform>()) {
            /* enemy.position = enemySlots[i % enemySlots.Length].position; */
            /* enemy.transform.Find("UnitWorldUI").position = Vector3.zero; */
            i++;
        }

		
	}
	
}
