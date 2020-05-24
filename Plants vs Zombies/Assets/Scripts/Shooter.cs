using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile, gun;
    AttackerSpawner myLaneSpawner;

    private void Start()
    {
        SetLaneSpawner();
    }

    private void Update()
    {
        
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in spawners)
        {
            float diff = transform.position.y - spawner.transform.position.y;

            if(diff == 3)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool IsAttackerInLane()
    {
        //line spawner child count
        if(myLaneSpawner.transform.childCount <= 0)
            return false;
        else
            return false;
    }
   public void Fire()
   {
       Instantiate(projectile, gun.transform.position, transform.rotation);
   }
}
