using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HeroMove : MonoBehaviour {

	public GameObject Terrain;
	private NavMeshAgent navMeshAgent;
	private PartyMember partyMember;

	public float FollowSpacing;

	public void Start () {
		navMeshAgent = GetComponent<NavMeshAgent>();
		partyMember = GetComponent<PartyMember>();
	}

  public Vector3 FollowOffset;
	
	public void Update () {
		if (partyMember.IsPartyLeader()) {
			if (Input.GetMouseButton(0)) {
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Terrain.GetComponent<Collider>().Raycast (ray, out hit, Mathf.Infinity)) {
					navMeshAgent.SetDestination(hit.point);
				}
			}
		} else {
			if (Vector3.Distance(transform.position, partyMember.Party.PartyLeader().transform.position) > FollowSpacing)
				navMeshAgent.SetDestination(partyMember.Party.PartyLeader().transform.position + FollowOffset);
			else {
				navMeshAgent.SetDestination(transform.position);
				
			}
		}
	}
}
