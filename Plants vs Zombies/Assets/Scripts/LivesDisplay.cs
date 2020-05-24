using UnityEngine.UI;
using UnityEngine;

public class LivesDisplay : MonoBehaviour
{
    [SerializeField] int lives = 5;
    int damage = 1;
    Text livesText;

    void Start()
    {
        livesText = GetComponent<Text>();
        UpdateDisplay();
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
