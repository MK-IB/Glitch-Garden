using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] GameObject deathVFX;
    [SerializeField] AudioClip deathSFX;
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
        GameObject deathVFXObj = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(deathVFXObj, 1f);
        //FindObjectOfType<LevelController>().GetComponent<AudioSource>().play
        AudioSource.PlayClipAtPoint(deathSFX, transform.position);
    }
}
