using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

    public bool recording = true;
    private float initialFixedDeltaTime;
    private bool isPaused = false; 


    private void Start()
    {
        PlayerPrefsManager.UnlockLevel(2);
        print(PlayerPrefsManager.IsLevelUnlocked(1));
        print(PlayerPrefsManager.IsLevelUnlocked(2));
        initialFixedDeltaTime = Time.fixedDeltaTime;
        print(initialFixedDeltaTime);
    }

    // Update is called once per frame
    void Update () {
	    if (CrossPlatformInputManager.GetButton("Fire1"))
        {
            recording = false;
        }
        else
        {
            recording = true;
        }

        if (Input.GetKeyDown(KeyCode.P) && isPaused) //better assign to a remapable button
        {
            isPaused = false;
            ResumeGame(); //update loop still runs, but timescale is set to 0
        }
        else if (Input.GetKeyDown(KeyCode.P) && !isPaused) //better assign to a remapable button
        {
            isPaused = true;
            PauseGame(); //update loop still runs, but timescale is set to 0
        }
        

    }

    void PauseGame()
    {
        Time.timeScale = 0;
        Time.fixedDeltaTime = 0; //physic loops are not called as well
    }
    void ResumeGame()
    {
        Time.timeScale = 1;
        Time.fixedDeltaTime = initialFixedDeltaTime;
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        isPaused = pauseStatus;
    }

}
