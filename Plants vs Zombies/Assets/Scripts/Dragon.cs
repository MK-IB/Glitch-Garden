using UnityEngine;

public class Dragon : MonoBehaviour
{
   [SerializeField] GameObject fireball, mouth;
   GameObject fireballParent;
   const string FIREBALL_PARENT_NAME = "Fireballs";

   void Start()
   {
      CreateFireballParent();
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
