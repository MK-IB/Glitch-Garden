using System.Collections;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int starCost = 100;
    float waitTime;
    void Start()
    {
        waitTime = Random.Range(30f, 45f);
        StartCoroutine(DestroyDefender());
    }

    IEnumerator DestroyDefender()
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);

    }
    public int GetStarCost()
    {
        return starCost;
    }

    public void AddStars(int amount)
    {
        FindObjectOfType<StarDisplay>().AddStars(amount);
    }
}
