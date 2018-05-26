using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

  public Vector3 offset;
  public Party party;

  public void Update() {
    GameObject partyLeader = party.PartyLeader();
    transform.position = partyLeader.transform.position + offset;
    transform.LookAt(partyLeader.transform);
  }

}
