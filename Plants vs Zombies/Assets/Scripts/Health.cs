using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] GameObject deathVFX;
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
        if(!deathVFX){ return;}
        explosionPosition = new Vector2(transform.position.x - 0.5f, transform.position.y - 0.2f);
        GameObject deathVFXObj = Instantiate(deathVFX, explosionPosition, transform.rotation);
        Destroy(deathVFXObj, 1f);
        //FindObjectOfType<LevelController>().GetComponent<AudioSource>().play
        AudioSource.PlayClipAtPoint(deathSFX, transform.position);
    }
}
