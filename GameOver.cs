using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public AudioSource gameOver;

    void OnEnable()
    {
        gameOver.Play();
    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        gameOver.Stop();
    }

    public void Close()
    {
        Application.Quit();
    }
}
