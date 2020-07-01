using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    [SerializeField] private GameObject Pause, player, cam;
    [SerializeField] private bool IsVisible;
	void Start () {
        Pause.SetActive(false);
        IsVisible = false;
        ResumeGame();
	}
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetKeyDown(KeyCode.Escape) && IsVisible == false)
        {
            PauseGame();
            

        }
        else if(Input.GetKeyDown(KeyCode.Escape) && IsVisible == true)
        {
            ResumeGame();
        }
	}

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
        print("Going to menu");
    }

    private void PauseGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
        print("Display Menu");
        Pause.SetActive(true);
        IsVisible = true;
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<Throw>().enabled = false;
        player.GetComponent<Pickup>().enabled = false;
        cam.GetComponent<PlayerLook>().enabled = false;



    }
    public void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
        print("Close Menu");
        Pause.SetActive(false);
        IsVisible = false;
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<Throw>().enabled = true;
        player.GetComponent<Pickup>().enabled = true;
        cam.GetComponent<PlayerLook>().enabled = true;

    }
}
