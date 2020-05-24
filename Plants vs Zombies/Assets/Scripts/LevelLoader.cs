using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour
{
   int currentSceneIndex;
   [SerializeField] int timeToWait = 4;
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(currentSceneIndex == 0)
        {
            StartCoroutine(WaitForTime());
        }
    }

    IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(timeToWait);
        LoadNextScene();
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start Screen");  
    }

    public void LoadOptionsScreen ()
    {
        SceneManager.LoadScene("Options Screen");  
    }

    public void RestartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);  
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);  
    }

    public void QuitGame()
    {
        Application.Quit();
    }
  public void LoadYouLose()
  {
      SceneManager.LoadScene("Lose Screen");
  }
}
