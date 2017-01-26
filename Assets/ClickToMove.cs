using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour {

	private Animator anim;
	private NavMeshAgent navMeshAgent;
	private Transform targetedEnemy;
	private Ray shootRay;
	private RaycastHit shootHit;
	private bool walking;

	// Use this for initialization
	void Awake ()
	{
		anim = GetComponent<Animator> ();
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

		anim.SetBool ("IsWalking", walking);

	}
}
