using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New High Score", menuName = "Scriptable Object/High Score")]
public class SO_HighScore : ScriptableObject {


    public int[] HighScores;



    public void AddHighScore(int score)
    {
        for (int i = 3; i > 0; i--)
        {
            if (score > HighScores[i - 1])
            {
                HighScores[i - 1] = score;
                return;
            }
        }

    }

    public int[] getHighScores()
    {

        return HighScores;
    }
	
}
