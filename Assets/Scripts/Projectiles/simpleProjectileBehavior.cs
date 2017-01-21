using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleProjectileBehavior : MonoBehaviour
{

    public int speed = 25;
    public int dmgMultiplier = 15;
    public int explosionForce = 100;
    public int explosionRadius = 2;
    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, 9000);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        List<string> affectedPlayers = new List<string>();

        //if (other.tag != "Enemy")
        //   return;

        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        // Go through all the colliders...       
        for (int i = 0; i < colliders.Length; i++)
        {
            Transform rootTransform = colliders[i].transform.root;
            if (affectedPlayers.Contains(rootTransform.name))
                continue;

            Rigidbody targetRigidbody = rootTransform.GetComponent<Rigidbody>();
            //player_Health playerHealth = rootTransform.GetComponent<player_Health>();
            // If they don't have a rigidbody, go on to the next collider.
            if (!targetRigidbody)
                continue;

            // Add an explosion force.
            affectedPlayers.Add(rootTransform.name);
            targetRigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius);

            Destroy(gameObject);
        }
    }
}
