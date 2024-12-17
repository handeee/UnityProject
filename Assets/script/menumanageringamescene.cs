using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menumanageringamescene : MonoBehaviour
{
    public GameObject inGameScreen, pauseScreen;
    // Start is called before the first frame update
    void Start()
    {
        pauseScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Pausebutton()
    {
        Time.timeScale = 0;
        inGameScreen.SetActive(false);
        pauseScreen.SetActive(true);
    }
    public void Playbutton()
    {
        Time.timeScale = 1;
        inGameScreen.SetActive(true);
        pauseScreen.SetActive(false);
    }
    public void RePlaybutton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    public void Homebutton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
