using UnityEngine;
using System.Collections;

public class FireballMovement : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    GameObject scarecrow;
    public bool scarecrowBurnt = false;
    void Update()
    {
        transform.Translate(Vector2.up * speed *Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if(otherCollider.tag == "defender")
        {
            otherCollider.GetComponent<Health>().DamageByDragon();
            //FindObjectOfType<Health>().DamageByDragon();
        }
        else if(otherCollider.tag == "scarecrow")
        {
            //burn and make it black
            scarecrow = GameObject.FindGameObjectWithTag("scarecrow");
            scarecrow.GetComponent<SpriteRenderer>().color = Color.black;
            scarecrowBurnt = true;
            StartCoroutine(DestroyTheScareCrow());
        }
    }
    IEnumerator DestroyTheScareCrow()
    {
        yield return new WaitForSeconds(8);
        Destroy(scarecrow);
    }
}
