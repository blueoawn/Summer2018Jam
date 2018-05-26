using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Party : MonoBehaviour {

	public List<GameObject> PartyMembers;

	private int leaderIndex =  0;

	public GameObject PartyLeader() {
		return PartyMembers[leaderIndex];
	}

  public void Update() {
    if (Input.GetKeyDown("tab")) {
      leaderIndex = (leaderIndex + 1) % PartyMembers.Count;
    }
  }
}
