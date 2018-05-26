using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Party : MonoBehaviour {

	public List<GameObject> partyMembers;

	private int leaderIndex =  0;

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
}
