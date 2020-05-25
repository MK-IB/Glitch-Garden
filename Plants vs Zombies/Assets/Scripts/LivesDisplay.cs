using UnityEngine.UI;
using UnityEngine;

public class LivesDisplay : MonoBehaviour
{
    [SerializeField] float baseLives = 6;
    [SerializeField] int damage = 1;
    float lives;
    Text livesText;

    void Start()
    {
        lives = baseLives - PlayerPrefsController.GetDifficulty();
        livesText = GetComponent<Text>();
        UpdateDisplay();
        Debug.Log("Difficulty = " + PlayerPrefsController.GetDifficulty());
    }

    private void UpdateDisplay()
    {
        livesText.text = lives.ToString();
    }
    public void TakeLife()
    {
        lives -= damage;
        UpdateDisplay();
        if(lives  <= 0)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
    }
}
