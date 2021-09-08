using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    float currentSpeed = 1f;

    Animator myAnimator;
    GameObject currentTarget;

    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawned();
    }

    private void OnDestroy()
    {
        LevelController controller = FindObjectOfType<LevelController>();
        if (!controller) { return; }
        controller.AttackerKilled();
    }

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        transform.Translate(Vector2.left*Time.deltaTime*currentSpeed);
        UpdateAnimationState();
    }
    private void UpdateAnimationState()
    {
        if (!currentTarget)
            myAnimator.SetBool("IsAttacking", false);
    }

    
    public void SetMovementSpeed(float speed) { currentSpeed = speed; }

    public void Attack(GameObject target)
    {
        myAnimator.SetBool("IsAttacking", true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if(!currentTarget) 
        { 
            return;
        }
        Health health = currentTarget.GetComponent<Health>();
        if(health)
        {
            health.DealDamage(damage);
        }
    }
}
