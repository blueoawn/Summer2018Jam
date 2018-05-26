using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HeroMove : MonoBehaviour {

	public GameObject terrain;
	private NavMeshAgent navMeshAgent;
	private PartyMember partyMember;

	public float followSpacing;

	public void Start () {
		navMeshAgent = GetComponent<NavMeshAgent>();
		partyMember = GetComponent<PartyMember>();
	}

    public Vector3 followOffset;
	
    public void Update () {
        if (partyMember.IsPartyLeader()) {
            if (Input.GetMouseButton(0)) {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (terrain.GetComponent<Collider>().Raycast (ray, out hit, Mathf.Infinity)) {
                    navMeshAgent.SetDestination(hit.point);
                }
            }
        } else {
            if (Vector3.Distance(transform.position, partyMember.Party.PartyLeader().transform.position) > followSpacing)
                navMeshAgent.SetDestination(partyMember.Party.PartyLeader().transform.position + followOffset);
            else {
                navMeshAgent.SetDestination(transform.position);
            }
        }
    }
}
