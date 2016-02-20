﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class ThrowingPointTrigger1 : MonoBehaviour
{
    private RacingLogic racingLogic;

    // Use this for initialiation
    void Start()
    {
        GameObject racingLogicObject = GameObject.FindWithTag("RacingController");
        if (racingLogicObject != null)
        {
            racingLogic = racingLogicObject.GetComponent<RacingLogic>();
        }
        if (racingLogic == null)
        {
            Debug.Log("Cannot find 'RacingLogic' script");
        }
    }
    
    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.CompareTag("PlayerCar"))
        {
            if (racingLogic.GetDirection() == 2)
            {
                racingLogic.DestroyAllPickUps();
                racingLogic.DeactivateSign();
            }

            racingLogic.DestroyAllPickUps();
            racingLogic.SetDirection(1);


        }
    }


}