using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.VFX;
[System.Serializable]
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
        AudioManager.instance.Play("Button");
        pauseCanvas.SetActive(true);
        firstMenu = false;
    }
    //resumes the game
    public void Resume()
    {
        AudioManager.instance.Play("Button");
        pauseCanvas.SetActive(false);
        firstMenu = true;
    }
    public void Quit()
    {
        AudioManager.instance.Play("Button");
        Application.Quit();
    }
}
