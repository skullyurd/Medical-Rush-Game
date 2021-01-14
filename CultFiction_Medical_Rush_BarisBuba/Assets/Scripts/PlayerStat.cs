using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerStat : MonoBehaviour
{
    [SerializeField] private int playerLife;
    [SerializeField] private int score;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private UI_Controller UIconScript;
    [SerializeField] private Text lifeUI;
    [SerializeField] private Text scoreUI;
    [SerializeField] private AudioSource playerAudio;
    [SerializeField] private AudioClip gameOverMusic;

    public void Start()
    {
        scoreUI.text = "Score: " + score;
        lifeUI.text = "Lifes: " + playerLife;
    }

    public void loseLife()
    {
        playerLife--;
        Debug.Log(playerLife);
        if (playerLife < 1)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            UIconScript.PausePanel = null;
            UIconScript.playerScript.enabled = false;
            playerAudio.clip = gameOverMusic;
            playerAudio.Play();
        }
        lifeUI.text = "Lifes: " + playerLife;
    }

    public void gainPoints(int TimeLeftOnPatient)
    {
        score += 100 + TimeLeftOnPatient;
        scoreUI.text = "Score: " + score;
    }

    public void losePoints(int TimeLeftOnPatient)
    {
        score -= 50 + TimeLeftOnPatient;
        scoreUI.text = "Score: " + score;
    }
}
