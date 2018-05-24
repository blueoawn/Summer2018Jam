using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyMember : MonoBehaviour {

	private Party party;

	public Party Party {
		get {
			return party;
		}
	}

	// Use this for initialization
	void Start () {
		party = transform.parent.GetComponent<Party>();
		if (party == null)
			Debug.LogError("Party Members must be the direct children of a Party");
	}
	
	public bool IsPartyLeader() {
		return party.PartyLeader() == this.gameObject;
	}
}
