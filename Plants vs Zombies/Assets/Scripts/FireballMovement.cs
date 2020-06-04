using UnityEngine;

public class FireballMovement : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    void Update()
    {
        transform.Translate(Vector2.up * speed *Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        Debug.Log("Collision occured");
        var defender = otherCollider.GetComponent<Defender>();
        var projectile = otherCollider.GetComponent<Projectile>();
        if(defender)
        {
            FindObjectOfType<Health>().DamageByDragon();
        }
        if (projectile)
        {
            FindObjectOfType<Projectile>().DamageByDragon();
        }
    }
}
