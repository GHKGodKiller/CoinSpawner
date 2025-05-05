using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CountdownTimer : MonoBehaviour
{
    private float timeLeft = 60.0f;
    [SerializeField] GameObject pauseMenu;

    private void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
            GameOver();
    }

    private void GameOver()
    {
        SceneManager.LoadScene(3); 
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;

    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

}
