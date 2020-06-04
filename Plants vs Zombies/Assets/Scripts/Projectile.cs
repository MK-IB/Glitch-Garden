using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] float damage = 50f;
    [SerializeField] GameObject deathVFXFire;
    void Update()
    {
        transform.Translate(Vector2.right * speed *Time.deltaTime);
    }
    public void DamageByDragon()
    {
        if(!deathVFXFire) {return;}
        GameObject fireEffect = Instantiate(deathVFXFire, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(fireEffect, 1f);
    }
   private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var health = otherCollider.GetComponent<Health>();
        var attacker = otherCollider.GetComponent<Attacker>();
        if(attacker && health)
        {
            health.DealDamage(damage);
            Destroy(gameObject);
        }
    }
}
