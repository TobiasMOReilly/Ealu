using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    //Current & High Scores
    private int currentscore;
    private float timeleft;
    [SerializeField] private SO_GameEvent WinEvent;
    [SerializeField] private SO_HighScore highScore;
    [SerializeField] private GameObject timer;
    [SerializeField] private Text DisplayScore;
    private bool hasSliotar;
    void Start()
    {
        
    }

    void Update()
    {
        hasSliotar = !gameObject.GetComponent<Throw>().isThrown;
      
    }


    public int getScore()
    {
        return currentscore;
    }

    public void SetHighScore()
    {
        highScore.AddHighScore(currentscore);
        print("Setting High Score");
    }

    public void incDistactEnemy()
    {
        currentscore++;
    }

    public void BonusScore()
    {
        if(hasSliotar == true)
        {
            currentscore += 100;
            print("Bonus");
        }
    }

    public void CalculateTimeScore()
    {
        print("Working");
        currentscore = (int)timer.GetComponent<Timer>().GetTimeLeftInSec() * 72;
        BonusScore();
        DisplayScore.text = "Score: " + currentscore;
        
    }





}
