using UnityEngine;
using System.Collections;
public class Dragon : MonoBehaviour
{
   [SerializeField] GameObject fireball, mouth;
   GameObject fireballParent;
   const string FIREBALL_PARENT_NAME = "Fireballs";
   [SerializeField] GameObject deathVFX;
   [SerializeField] AudioClip deathSFX;
   void Start()
   {
      CreateFireballParent();
   }

   private void OnTriggerEnter2D(Collider2D collider)
   {
      if(collider.tag == "gravestone")
        {
            gameObject.GetComponent<Attacker>().SetMovementSpeed(0f);
        }

        if(collider.tag == "scarecrow" && FindObjectOfType<FireballMovement>().GetScarecrowBurnBool() == true)
        {
           Destroy(gameObject);
           PlayDeathVFX();
        }
   }
   private void PlayDeathVFX()
    {
        if(!deathVFX) { return;}
        GameObject deathVFXObj = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(deathVFXObj, 1f);
        if(!deathSFX) {return;}
        AudioSource.PlayClipAtPoint(deathSFX, transform.position);
    }
   private void CreateFireballParent()
   {
      fireballParent = GameObject.Find(FIREBALL_PARENT_NAME);

      if(!fireballParent)
      {
         fireballParent = new GameObject(FIREBALL_PARENT_NAME);
      }
   }

   public void ThrowFireball()
   {
      GameObject fireballs =
      Instantiate(fireball, mouth.transform.position, mouth.transform.rotation) as GameObject;
      fireballs.transform.parent = fireballParent.transform;
   }
}
