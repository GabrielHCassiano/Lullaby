using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MenuPause : MonoBehaviour
{
    public Transform pauseMenu;
    public Transform pauseOp;
    public Transform pauseDisplay;
    public Transform pauseAudio;
    public Transform pauseControl;
    private GameObject jogo;
    private GameObject timetime;

    // Start is called before the first frame update
    void Start()
    {
        jogo = GameObject.FindWithTag("Jogo");
        timetime = GameObject.FindWithTag("Times");
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !pauseOp.gameObject.activeSelf && !pauseDisplay.gameObject.activeSelf && !pauseAudio.gameObject.activeSelf && !pauseControl.gameObject.activeSelf && timetime.GetComponent<TimeTime>().end == false)
        {
            if(pauseMenu.gameObject.activeSelf)
            {
                jogo.SetActive(true);
                pauseMenu.gameObject.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                jogo.SetActive(false);
                pauseMenu.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    public void ResumeGame()
    {
        jogo.SetActive(true);
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
