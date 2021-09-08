using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject gun;
    AttackerSpawner myLaneSpawner;
    Animator myAnimator;

    GameObject projectileParent;
    const string PROJECTILE_PARENT_NAME = "projectiles";

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
        CreateParentProjectile();
        SetLaneSpawner();
    }
 
    private void CreateParentProjectile()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    private void Update()
    {
        if (IsAttackerInLane())
        {
            myAnimator.SetBool("IsAttacking", true);
        }
        else
        {
            myAnimator.SetBool("IsAttacking", false);

        }
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] attackerSpawners = FindObjectsOfType<AttackerSpawner>();
        foreach(AttackerSpawner spawner in attackerSpawners)
        {
            bool isCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);
            if(isCloseEnough)
            {
                myLaneSpawner = spawner;
            }    
        }
    }

    private bool IsAttackerInLane()
    {
        int childNum = myLaneSpawner.transform.childCount;
        return (childNum > 0);
    }

    public void Fire()
    {
        GameObject newProjectile = Instantiate(projectile, gun.transform.position, Quaternion.identity) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
    }
}
