using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class UI_Controller : MonoBehaviour
{
    private bool paused;
    private bool mute;

    [SerializeField] public GameObject PausePanel;
    [SerializeField] public FirstPersonController playerScript;
    [SerializeField] private AudioSource gameLevelsAudio;
    [SerializeField] private GameObject UIstats;

    void Start()
    {
        if(PausePanel == null)
        {
            return;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void MuteMusic()
    {
        switch (mute)
        {
            case true: //if game was muted
                mute = false;
                gameLevelsAudio.Play();
                break;

            case false:// if game wasn't muted
                mute = true;
                gameLevelsAudio.Pause();
                break;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Resume()
    {
        paused = false;
        PausePanel.SetActive(false);
        Time.timeScale = 1;
        playerScript.enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            switch (paused)
            {
                case true:
                    paused = false;
                    PausePanel.SetActive(false);
                    Time.timeScale = 1;
                    playerScript.enabled = true;
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                    UIstats.SetActive(true);
                    break;

                case false:
                    paused = true;
                    PausePanel.SetActive(true);
                    Time.timeScale = 0;
                    playerScript.enabled = false;
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.Confined;
                    UIstats.SetActive(false);
                    break;
            }

        }
    }
}
