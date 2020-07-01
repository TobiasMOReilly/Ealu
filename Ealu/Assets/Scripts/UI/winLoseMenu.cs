using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winLoseMenu : MonoBehaviour {

    [SerializeField] private GameObject WinMenu, LoseMenu, playercamera;

	// Use this for initialization
	void Start () {
		
	}

    public void Win()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        print("Win");
        Time.timeScale = 0;
        playercamera.GetComponent<PlayerLook>().enabled = false;
        WinMenu.SetActive(true);
    }

    public void Lose()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        print("Lose");
        Time.timeScale = 0;
        playercamera.GetComponent<PlayerLook>().enabled = false;
        LoseMenu.SetActive(true);
    }
	

}
