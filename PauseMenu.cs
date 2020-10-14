using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject ui;
    public GameObject btn_shop;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf);

        if (ui.activeSelf)
        {
            Time.timeScale = 0f;
            btn_shop.SetActive(false);
        }
        else
        {
            Time.timeScale = 1f;
            btn_shop.SetActive(true);
        }
    }
    public void Mute()
    {
        //AudioListener.pause = !AudioListener.pause;     -----> Mute All
        EnemyMovement.mute = !EnemyMovement.mute;
        Debug.Log(EnemyMovement.mute);

    }

    public void Retry()
    {
        Toggle();
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
