﻿using UnityEngine;
using System.Collections;

public abstract class MiniGameAbstract : MonoBehaviour
{

    private bool playing = false;

    private float startTime;
    private float remainingTime;
    private int currentScore;
    private Question q;

    // Use this for initialization
    public virtual void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (playing)
        {
            remainingTime -= Time.deltaTime;
            //print("playing:" + remainingTime + " score: " + currentScore);    

            if (remainingTime < 0)
            {
                StopGame();
            }
        }
    }



    public virtual void StartGame()
    {
        startTime = Time.timeSinceLevelLoad;
        remainingTime = 90f; // 90s default remaining time
        currentScore = 0;

        playing = true;

    }

    public virtual void StopGame()
    {
        //TODO save highscore and whatnot
        //convert score to prize
        playing = false;
    }

    public virtual float GetPlayedTime()
    {
        return Time.timeSinceLevelLoad - startTime;
    }
    public virtual bool GetPlaying()
    {
        return playing;
    }
    public virtual int GetCurrentScore()
    {
        return currentScore;
    }
    public virtual float GetRemainingTime()
    {
        return remainingTime;
    }


    public virtual void AddScore(int score)
    {
        currentScore += score;
    }

    public virtual void cleanScore()
    {
        currentScore = 0;
    }

    public virtual void AddTime(float time)
    {
        remainingTime += time;
    }

    public void CreateQuestion(int n)
    {
        q = GameController.control.GetQuestion(n);
        Debug.Log("question: " + q.question);
    }

    public Question GetQuestion()
    {
        return q;
    }
}
