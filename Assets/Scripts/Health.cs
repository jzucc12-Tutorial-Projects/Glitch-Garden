using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 30f;
    [SerializeField] GameObject deathVFX;
    [SerializeField] float deathVFXtimer = 1f;

    public float GetHealth() { return health; }

    public void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
            Die();
    }

    public void Die()
    {
        health = 0;
        if (deathVFX)
        {
            GameObject deathVFXObject = Instantiate(deathVFX, transform.position, Quaternion.identity);
            Destroy(deathVFXObject, deathVFXtimer);
        }
        Destroy(gameObject);
    }
}
