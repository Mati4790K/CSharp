using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    private bool gameEnded;
    public GameObject gameOverUI;
    public GameObject btn_shop;
    public GameObject speed2x;
    public GameObject speed4x;
    public int towers;

    public GameObject completeLevelUI;

    private void Start()
    {
        btn_shop.SetActive(true);
        speed2x.SetActive(false);
        speed4x.SetActive(false);
        gameEnded = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (gameEnded)
            return;

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            Toggle();
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Toggle2();
        }

    }

    public void Toggle()
    {
        speed2x.SetActive(!speed2x.activeSelf);

        if (speed2x.activeSelf)
        {
            Time.timeScale = 2.25f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void Toggle2()
    {
        speed4x.SetActive(!speed4x.activeSelf);

        if (speed4x.activeSelf)
        {
            Time.timeScale = 4f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void EndGame()
    {
        btn_shop.SetActive(false);
        gameEnded = true;
        gameOverUI.SetActive(true);
        Time.timeScale = 0.25f;
    }

    public void WinLevel()
    {
        completeLevelUI.SetActive(true);
        btn_shop.SetActive(false);
        gameEnded = true;
        Time.timeScale = 0.25f;
    }
}
