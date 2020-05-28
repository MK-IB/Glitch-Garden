using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelLoader : MonoBehaviour
{
   int currentSceneIndex;
   [SerializeField] int timeToWait = 4;
   [SerializeField] Image tooltip;
   float toolTipStayTime = 3;
   
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(currentSceneIndex == 0)
        {
            StartCoroutine(WaitForTime());
        }
        if(tooltip){
            tooltip.enabled = false;
        }

    }
    public void LoadNewGame()
    {
        SceneManager.LoadScene("Level 1");
        PlayerPrefsController.SetLevelNumber(0);
    }
    public void LoadSavedLevel()
    {
        int levelToLoad = PlayerPrefsController.GetLevelNumber() + 1;

        if(levelToLoad < 3)
        {
            if(tooltip.enabled == false)
            {
                tooltip.enabled = true;
                StartCoroutine(HideTooltip());
            }
               
        }
        else
        SceneManager.LoadScene(levelToLoad);
    }

    IEnumerator HideTooltip()
    {
        yield return new WaitForSeconds(toolTipStayTime);
        tooltip.enabled = false;
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
}
