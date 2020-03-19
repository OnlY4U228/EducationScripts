using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public bool IsPaused = false;
    public GameObject PauseMenuUI;
    public GameObject Player;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
                Resume();
            else
                Pause();
        }
    }
    public void Resume()
    {
        Player.GetComponentInChildren<CamTest>().enabled = true;
        Cursor.visible = false;
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }
    void Pause()
    {
        Player.GetComponentInChildren<CamTest>().enabled = false;
        Cursor.visible = true;
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }
}
