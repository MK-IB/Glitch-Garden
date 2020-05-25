using UnityEngine.UI;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
   
   [Tooltip("Our level timer in seconds")]
   [SerializeField] float levelTime = 30;
   bool triggeredLevelFinished = false;
    void Update()
    {
        if(triggeredLevelFinished) { return; }
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

        bool timerFinished = (Time.timeSinceLevelLoad >= levelTime);
        if(timerFinished)
        {
           FindObjectOfType<LevelController>().LevelTimerFinished();
           triggeredLevelFinished = true;
        }
    }
}
