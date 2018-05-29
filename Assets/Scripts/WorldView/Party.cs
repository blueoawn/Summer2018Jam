//This script is on the Party GameObject. The party gameobject has the party member game objects as children, as well as containg them in the 
//partyMembers member variable
//
//the index of the party leader is stored in leaderIndex
//the also stores the current target of the party, used only in combat mode
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Party : MonoBehaviour {

	public List<GameObject> partyMembers;

	private int leaderIndex =  0;

    private GameObject target = null;

    public void Start() {
        DontDestroyOnLoad(this.gameObject);
    }

	public GameObject PartyLeader() {
		return partyMembers[leaderIndex];
	}

    public void Update() {
        if (Input.GetKeyDown("tab")) {
            leaderIndex = (leaderIndex + 1) % partyMembers.Count;
        }
        if (Input.GetMouseButton(0)) {
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit) {
                if (hitInfo.transform.gameObject.GetComponent<Combat>()) {
                    SetTarget(hitInfo.transform.gameObject);
                }
            } else {

            }
        }
    }

    public void InitiateCombat(GameObject[] enemies) {
        Debug.Log("initiate Combat");
        /* GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy"); */
        //TODO
        //check for nearby enemies here
        //
        /* foreach (GameObject enemy in enemies) { */
        /*     DontDestroyOnLoad(enemy); */
        /* } */
        SceneManager.LoadScene("BattleModeTesting", LoadSceneMode.Single);
        GameObject enemiesGameObject = new GameObject("Enemies");
        foreach (GameObject enemy in enemies) {
            GameObject g = Instantiate(enemy) as GameObject;
            g.transform.SetParent(enemiesGameObject.transform);
        }
        DontDestroyOnLoad(enemiesGameObject);
    }


    public void SetTarget(GameObject desiredTarget) {
        if (!desiredTarget.GetComponent<Combat>()) {
            Debug.LogError("Cannot target a non combat unit");
        }
        //first toggle OFF the indicator for the old target, if there was one
        if (target != null)
            target.transform.Find("UnitWorldUI").GetComponent<UnitWorldUI>().SetTargetIndicatorVisibility(false);

        //set the new target
        target = desiredTarget;

        //toggle the new target indicator ON
        target.transform.Find("UnitWorldUI").GetComponent<UnitWorldUI>().SetTargetIndicatorVisibility(true);
    }

    public GameObject GetTarget() {
        return target;
    }
}
