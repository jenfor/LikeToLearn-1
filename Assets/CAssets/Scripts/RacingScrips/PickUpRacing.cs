﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;



public class PickUpRacing : MonoBehaviour {
    public GameObject text;
    private RacingLogic racingLogic;

    private float points;
    private float f;

    // Use this for initialization
    void Start() {


        GameObject racingLogicObject = GameObject.FindWithTag("RacingController");
        if (racingLogicObject != null)
        {
            racingLogic = racingLogicObject.GetComponent<RacingLogic>();
        }
        if(racingLogic == null)
        {
            Debug.Log("Cannot find 'RacingLogic' script");
        }
       
        points = 0;

        SetValue();
       

    }

    // Update is called once per frame
    void Update()
    {

        

    }

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.CompareTag("PlayerCar"))
        {

            gameObject.SetActive(false);

            racingLogic.AddScore(-2);

            points = points + f;
            //Debug.Log(points);


        }
    }


    void SetValue()
    {
        f = Mathf.Floor(Random.value * 100f);
        text.GetComponent<TextMesh>().text = "" + f;

    }
   

   
}
  