using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DispScore : MonoBehaviour {

    // Use this for initialization
    [SerializeField] private SO_HighScore highScore;
    private int[] HS;
    public Text Score1, Score2, Score3;
    void Start()
    {
        HS = highScore.getHighScores();
        Score1.text = "1: " + HS[2];
        Score2.text = "2: " + HS[1];
        Score3.text = "3: " + HS[0];



    }
}
