using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class OptionsMenu : MonoBehaviour
{
    public AudioSource pauseMenu;
    public Dropdown resolutionDropdown;
    public Dropdown qualityDropdown;

    private void Start()
    {
        int val = MainMenuScript.res;
        resolutionDropdown.value = val;
        pauseMenu.Play();
        resolutionDropdown.RefreshShownValue();
        qualityDropdown.value = QualitySettings.GetQualityLevel();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Menu();
        }
    }

    public void SetResolution (int resolutionIndex)
    {

        if (resolutionIndex == 0)
        {
            Screen.SetResolution(640, 480, Screen.fullScreen);
            resolutionDropdown.value = resolutionIndex;
            resolutionDropdown.RefreshShownValue();
            MainMenuScript.res = resolutionIndex;
        }
        else if (resolutionIndex == 1)
        {
            Screen.SetResolution(800, 450, Screen.fullScreen);
            resolutionDropdown.value = resolutionIndex;
            resolutionDropdown.RefreshShownValue();
            MainMenuScript.res = resolutionIndex;
        }
        else if (resolutionIndex == 2)
        {
            Screen.SetResolution(1024, 768, Screen.fullScreen);
            resolutionDropdown.value = resolutionIndex;
            resolutionDropdown.RefreshShownValue();
            MainMenuScript.res = resolutionIndex;
        }
        else if (resolutionIndex == 3)
        {
            Screen.SetResolution(1280, 720, Screen.fullScreen);
            resolutionDropdown.value = resolutionIndex;
            resolutionDropdown.RefreshShownValue();
            MainMenuScript.res = resolutionIndex;
        }
        else if (resolutionIndex == 4)
        {
            Screen.SetResolution(1280, 800, Screen.fullScreen);
            resolutionDropdown.value = resolutionIndex;
            resolutionDropdown.RefreshShownValue();
            MainMenuScript.res = resolutionIndex;
        }
        else if (resolutionIndex == 5)
        {
            Screen.SetResolution(1280, 1024, Screen.fullScreen);
            resolutionDropdown.value = resolutionIndex;
            resolutionDropdown.RefreshShownValue();
            MainMenuScript.res = resolutionIndex;
        }
        else if (resolutionIndex == 6)
        {
            Screen.SetResolution(1360, 768, Screen.fullScreen);
            resolutionDropdown.value = resolutionIndex;
            resolutionDropdown.RefreshShownValue();
            MainMenuScript.res = resolutionIndex;
        }
        else if (resolutionIndex == 7)
        {
            Screen.SetResolution(1366, 768, Screen.fullScreen);
            resolutionDropdown.value = resolutionIndex;
            resolutionDropdown.RefreshShownValue();
            MainMenuScript.res = resolutionIndex;
        }
        else if (resolutionIndex == 8)
        {
            Screen.SetResolution(1440, 900, Screen.fullScreen);
            resolutionDropdown.value = resolutionIndex;
            resolutionDropdown.RefreshShownValue();
            MainMenuScript.res = resolutionIndex;
        }
        else if (resolutionIndex == 9)
        {
            Screen.SetResolution(1600, 900, Screen.fullScreen);
            resolutionDropdown.value = resolutionIndex;
            resolutionDropdown.RefreshShownValue();
            MainMenuScript.res = resolutionIndex;
        }
        else if (resolutionIndex == 10)
        {
            Screen.SetResolution(1680, 1050, Screen.fullScreen);
            resolutionDropdown.value = resolutionIndex;
            resolutionDropdown.RefreshShownValue();
            MainMenuScript.res = resolutionIndex;
        }
        else if (resolutionIndex == 11)
        {
            Screen.SetResolution(1920, 1080, Screen.fullScreen);
            resolutionDropdown.value = resolutionIndex;
            resolutionDropdown.RefreshShownValue();
            MainMenuScript.res = resolutionIndex;
        }
        else if (resolutionIndex == 12)
        {
            Screen.SetResolution(1920, 1200, Screen.fullScreen);
            resolutionDropdown.value = resolutionIndex;
            resolutionDropdown.RefreshShownValue();
            MainMenuScript.res = resolutionIndex;
        }
        else if (resolutionIndex == 13)
        {
            Screen.SetResolution(2560, 1080, Screen.fullScreen);
            resolutionDropdown.value = resolutionIndex;
            resolutionDropdown.RefreshShownValue();
            MainMenuScript.res = resolutionIndex;
        }
        else if (resolutionIndex == 14)
        {
            Screen.SetResolution(2560, 1440, Screen.fullScreen);
            resolutionDropdown.value = resolutionIndex;
            resolutionDropdown.RefreshShownValue();
            MainMenuScript.res = resolutionIndex;
        }
        else if (resolutionIndex == 15)
        {
            Screen.SetResolution(3440, 1440, Screen.fullScreen);
            resolutionDropdown.value = resolutionIndex;
            resolutionDropdown.RefreshShownValue();
            MainMenuScript.res = resolutionIndex;
        }
        else if (resolutionIndex == 16)
        {
            Screen.SetResolution(3840, 2160, Screen.fullScreen);
            resolutionDropdown.value = resolutionIndex;
            resolutionDropdown.RefreshShownValue();
            MainMenuScript.res = resolutionIndex;
        }

    }

    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void Menu()
    {
        pauseMenu.Stop();
        SceneManager.LoadScene("MainMenu");
    }
}
