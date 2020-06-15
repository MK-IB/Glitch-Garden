using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] AudioClip loseClip;
    [SerializeField] AudioClip winClip;
   int numberOfAttackers = 0;
   int killedByDefender;
   bool levelTimerFinished = false;
   [SerializeField] float waitToLoad = 4f;

   private void Start()
   {
       winLabel.SetActive(false);
       loseLabel.SetActive(false);
       pauseMenu.SetActive(false);
   }
   public void AttackerSpawned()
   {
       numberOfAttackers++;
   }

   /*public void KilledByDefender()
   {
       killedByDefender++;
   } */
   public void AttackerKilled()
   {
       //Debug.Log("Attackers = " + numberOfAttackers);
       numberOfAttackers--;
       if(numberOfAttackers <= 0 && levelTimerFinished)
       {
          StartCoroutine(HandleWinCondition());
       }
   }
    public void AttackerKilledByDefender()
    {
        FindObjectOfType<StarDisplay>().AddStars(10);
    }

    public void PauseTheGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GetComponent<AudioSource>().Stop();
    }

    public void ResumeTheGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GetComponent<AudioSource>().Play();
    }

   IEnumerator HandleWinCondition()
   {
       winLabel.SetActive(true);
       GetComponent<AudioSource>().Stop();
       AudioSource.PlayClipAtPoint(winClip, transform.position);
       yield return new WaitForSeconds(waitToLoad);
       FindObjectOfType<LevelLoader>().LoadNextScene();
       PlayerPrefsController.SetLevelNumber(SceneManager.GetActiveScene().buildIndex);
   }

   public void HandleLoseCondition()
   {
       loseLabel.SetActive(true);
       AudioSource.PlayClipAtPoint(loseClip, transform.position);
       Time.timeScale = 0;
   }
   public void LevelTimerFinished()
   {
       levelTimerFinished = true;
      // Debug.Log("LevelTimer Finished");
       StopSpawners();
   }

   private void StopSpawners()
   {
       AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();
       foreach(AttackerSpawner spawner in spawnerArray)
       {
           spawner.StopSpawning();
       }
   }
}
