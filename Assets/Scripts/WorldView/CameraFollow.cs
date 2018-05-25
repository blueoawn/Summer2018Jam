using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

  public Vector3 Offset;
  public Party Party;

  public void Update() {
    GameObject partyLeader = Party.PartyLeader();
    transform.position = partyLeader.transform.position + Offset;
    transform.LookAt(partyLeader.transform);
  }

}
