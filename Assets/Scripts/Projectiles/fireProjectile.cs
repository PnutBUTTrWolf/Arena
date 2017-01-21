using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireProjectile : MonoBehaviour {

    public GameObject prefab;
    public GameObject spawnpoint;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(1))
        {
            Fire();
        }

    }

    public void Fire()
    {
       
            if (Input.GetMouseButtonDown(1))
            { // only do anything when the button is pressed:
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100))
                {
                    Debug.DrawLine(transform.position, hit.point);
                    // cache oneSpawn object in spawnPt, if not cached yet
                    GameObject projectile = GameObject.Instantiate(prefab, spawnpoint.transform.position + .01f * transform.forward, transform.rotation);
                    // turn the projectile to hit.point
                    projectile.transform.LookAt(hit.point + new Vector3(0,spawnpoint.transform.position.y));
                    // accelerate it
                    //projectile.rigidbody.velocity = projectile.transform.forward * 10;
                }
            }


        
    }
}
