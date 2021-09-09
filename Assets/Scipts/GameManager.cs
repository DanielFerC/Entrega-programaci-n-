using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject GameOverMenu;
    [SerializeField] int numAnimals;

    // Start is called before the first frame update
    void Start()
    {
       
    }
    

    // Update is called once per frame
    void Update()
    {
        PauseGame();
    }
    public void Realentizar()
    {
        Time.timeScale = 0.5f;
       
        /*
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        if (stopwatch.ElapsedMilliseconds >= 5000)
        {
            stopwatch.Stop();
            Time.timeScale = 1;

        }
       */
    }
    public void Normalizar()
    {
        Time.timeScale = 1;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void BackToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void NextLevel2()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
    }
    public void Nextlevel3()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(3);
    }
    void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
            }
          
        }
        
        


    }
    public void CaptureAnimal()
    {
        numAnimals--;
        if (numAnimals < 1)
        {
            Time.timeScale = 0;
            GameOverMenu.SetActive(true);
        }

    }
}
