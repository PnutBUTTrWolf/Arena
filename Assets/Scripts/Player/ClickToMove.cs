using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour {

	private NavMeshAgent navMeshAgent;
	private Ray shootRay;
	private bool walking;

	// Use this for initialization
	void Awake ()
	{
		navMeshAgent = GetComponent<NavMeshAgent> (); 
	}

	// Update is called once per frame
	void Update () 
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Input.GetButtonDown ("Fire1")) 
		{
			if (Physics.Raycast (ray, out hit, 100)) 
			{				
				walking = true;
				navMeshAgent.destination = hit.point;
				navMeshAgent.Resume ();
			}
		}

	}
}
