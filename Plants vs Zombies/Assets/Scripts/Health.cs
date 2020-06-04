using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject deathVFXFire;
    [SerializeField] AudioClip deathSFX;
    Vector2 explosionPosition;
    public void DealDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            PlayDeathVFX();
            FindObjectOfType<LevelController>().AttackerKilledByDefender();
            Destroy(gameObject);
        }
    }

    private void PlayDeathVFX()
    {
        if(!deathVFX) { return;}
        //explosionPosition = new Vector2(transform.position.x - 0.5f, transform.position.y - 0.2f);
        GameObject deathVFXObj = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(deathVFXObj, 1f);
        if(!deathSFX) {return;}
        AudioSource.PlayClipAtPoint(deathSFX, transform.position);
    }

    public void DamageByDragon()
    {
        Debug.Log("Damage() called");
        Destroy(gameObject);
        if(!deathVFXFire) {return;}
        GameObject fireEffect = Instantiate(deathVFXFire, transform.position, transform.rotation);
        Destroy(fireEffect, 1f);
    }
}
