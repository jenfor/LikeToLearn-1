﻿using UnityEngine;
using System.Collections;

public class BoatExitTrigger : MonoBehaviour
{
    public GameObject enter;
    private float startTime;

    // Use this for initialization
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {   

    }

    void OnTriggerEnter(Collider c)
    {
        if (c.tag.Equals("PlayerBoat") && Time.timeSinceLevelLoad - startTime > 4f)
        {
            GameObject.Find("BoatGame").GetComponent<BoatGame>().StopGame(); // stop game in boatgame script

            // Disable boat, freeze
            GameObject boat = GameObject.Find("Speedboat");
            boat.GetComponent<BoatController>().StopBoat();
            Rigidbody boatrb = boat.GetComponent<Rigidbody>();
            boatrb.constraints = RigidbodyConstraints.FreezeAll;

            // Enble player's components again (all of them)
            GameObject p = GameObject.FindGameObjectWithTag("Player");
            Component[] components = p.GetComponents<MonoBehaviour>();
            foreach (MonoBehaviour comp in components)
            {
                comp.enabled = true;
            }

            // Move to spawnpoint
            p.GetComponentInChildren<Camera>().enabled = true;
            p.GetComponent<Rigidbody>().velocity = Vector3.zero;
            p.GetComponent<Rigidbody>().Sleep();
            p.transform.position = GameObject.FindGameObjectWithTag("SpawnPoint").transform.position;

            startTime = Time.timeSinceLevelLoad;


        }
    }

    public void StartTimer()
    {
        startTime = Time.timeSinceLevelLoad;
    }

}
