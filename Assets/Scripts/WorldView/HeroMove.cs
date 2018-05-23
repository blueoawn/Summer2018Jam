using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HeroMove : MonoBehaviour {

	public GameObject Terrain;
	private NavMeshAgent navMeshAgent;

	public void Start () {
		navMeshAgent = GetComponent<NavMeshAgent>();
	}
	
	public void Update () {
		if (Input.GetMouseButton(0)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Terrain.GetComponent<Collider>().Raycast (ray, out hit, Mathf.Infinity)) {
				navMeshAgent.SetDestination(hit.point);
			}
		}
	}
}
