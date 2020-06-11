using UnityEngine;
using System.Collections;

public class FireballMovement : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] GameObject fireVFX;
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
            scarecrow = otherCollider.gameObject;
            ScareCrowDeathEffect();
            scarecrow.GetComponent<SpriteRenderer>().color = Color.black;
            scarecrowBurnt = true;
            StartCoroutine(DestroyTheScareCrow());
        }
    }

    public bool GetScarecrowBurnBool()
    {
        return scarecrowBurnt;
    }
    private void ScareCrowDeathEffect()
    {
        if(!fireVFX) {return;}
        GameObject fire = Instantiate(fireVFX, scarecrow.transform.position, scarecrow.transform.rotation);
        Destroy(fire, 1f);
    }
    IEnumerator DestroyTheScareCrow()
    {
        yield return new WaitForSeconds(8);
        Destroy(scarecrow);
    }
}
