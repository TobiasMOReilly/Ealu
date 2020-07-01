using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManageScript : MonoBehaviour {

    [SerializeField] private GameObject RotatePoint;


    private void Update()
    {
        if(RotatePoint != null)
       RotatePoint.transform.Rotate(0, 0.1f, 0);

    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Map-Detailed");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
	public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
