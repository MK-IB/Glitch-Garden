using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile, gun;
    AttackerSpawner myLaneSpawner;
    GameObject projectileParent;
    const string PROJECTILE_PARENT_NAME = "Projectiles";

    private void Start()
    {
        SetLaneSpawner();
        CreateProjectileParent();
    }

    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);;
        if(!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
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
       GameObject newProjectile = 
            Instantiate(projectile, gun.transform.position, transform.rotation)
            as GameObject;
        newProjectile.transform.parent = projectileParent.transform;

   }
}
