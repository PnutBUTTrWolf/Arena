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
        GameObject.Instantiate(prefab, spawnpoint.transform.position + .01f * transform.forward, transform.rotation);
        
    }
}
