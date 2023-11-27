using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.VFX;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseCanvas;
    [SerializeField] bool firstMenu = true;
    
    

    private void Start()
    {
        pauseCanvas.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && firstMenu)
        {
            Pause();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && !firstMenu)
        {
            Resume();
        }
    }
    public void Pause()
    {
        pauseCanvas.SetActive(true);
        firstMenu = false;
    }
    //resumes the game
    public void Resume()
    {
        pauseCanvas.SetActive(false);
        firstMenu = true;
    }
    public void Quit()
    {
        Application.Quit();
    }
}
