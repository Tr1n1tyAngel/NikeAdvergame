using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
[System.Serializable]
public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject saveMenu;
    [SerializeField] GameObject CharacterSelectMenu;
    [SerializeField] GameObject settingsMenu;
    [SerializeField] public AudioMixer audioMixer;
    [SerializeField] public TMP_Dropdown resolutionDropdown;
    Resolution[] resolutions;


    // Start is called before the first frame update
    void Start()
    {
        
        mainMenu.SetActive(true);
        saveMenu.SetActive(false);
        settingsMenu.SetActive(false);
        CharacterSelectMenu.SetActive(false);
        Resolution();
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SaveMenu()
    {
        AudioManager.instance.Play("Button");
        mainMenu.SetActive(false);
        saveMenu.SetActive(true);
        settingsMenu.SetActive(false);
        CharacterSelectMenu.SetActive(false);
    }
    public void NewGame()
    {
        AudioManager.instance.Play("Button");
        mainMenu.SetActive(false);
        saveMenu.SetActive(false);
        settingsMenu.SetActive(false);
        CharacterSelectMenu.SetActive(true);
    }
    public void SettingsMenu()
    {
        AudioManager.instance.Play("Button");
        mainMenu.SetActive(false);
        saveMenu.SetActive(false);
        settingsMenu.SetActive(true);
        CharacterSelectMenu.SetActive(false);
    }
    public void Back()
    {
        AudioManager.instance.Play("Button");
        mainMenu.SetActive(true);
        saveMenu.SetActive(false);
        settingsMenu.SetActive(false);
        CharacterSelectMenu.SetActive(false);
    }
    public void CharacterSelect1()
    {
        AudioManager.instance.Play("Button");
        GameManager.Instance.CH1 = true;
        SceneManager.LoadScene("Shop");
    }
    public void CharacterSelect2()
    {
        AudioManager.instance.Play("Button");
        GameManager.Instance.CH2 = true;
        SceneManager.LoadScene("Shop");
    }
    public void Quit()
    {
        AudioManager.instance.Play("Button");
        Application.Quit();
    }
    void Resolution()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }
    public void setQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    //sets the volume of the game
    public void setVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }
    //sets the resolution
    public void setResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];

        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void SetFullscreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}
