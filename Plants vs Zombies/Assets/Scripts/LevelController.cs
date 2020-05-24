﻿using System.Collections;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
   int numberOfAttackers = 0;
   bool levelTimerFinished = false;
   [SerializeField] float waitToLoad = 4f;

   private void Start()
   {
       winLabel.SetActive(false);
       loseLabel.SetActive(false);
   }
   public void AttackerSpawned()
   {
       numberOfAttackers++;
   }
   public void AttackerKilled()
   {
       Debug.Log("Attackers = " + numberOfAttackers);
       numberOfAttackers--;
       if(numberOfAttackers <= 0 && levelTimerFinished)
       {
          StartCoroutine(HandleWinCondition());
       }
   }

   IEnumerator HandleWinCondition()
   {
       winLabel.SetActive(true);
       GetComponent<AudioSource>().Play();
       yield return new WaitForSeconds(waitToLoad);
       FindObjectOfType<LevelLoader>().LoadNextScene();
   }

   public void HandleLoseCondition()
   {
       loseLabel.SetActive(true);
       Time.timeScale = 0;
   }
   public void LevelTimerFinished()
   {
       levelTimerFinished = true;
       Debug.Log("LevelTimer Finished");
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