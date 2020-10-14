using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenuScript : MonoBehaviour
{

    public static int res = 11;
    public string levelToLoad = "Map01";

    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;

    int x;

    private void Awake()
    {
        Screen.SetResolution(1920, 1080, Screen.fullScreen);
        Time.timeScale = 1f;
    }

    public void Play()
    {
        Time.timeScale = 1f;
        StartCoroutine(LoadAsynch(levelToLoad));
    }

    IEnumerator LoadAsynch(string levelToLoad)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelToLoad);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            progressText.text = (int)Math.Round(progress * 100f) + "%";

            yield return null;
        }
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
}
