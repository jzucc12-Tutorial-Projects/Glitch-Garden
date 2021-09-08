using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 1f;
    [SerializeField] float damage = 10f;

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * projectileSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var target = other.GetComponent<Attacker>();
        if(target)
        {
            var health = other.GetComponent<Health>();
            health.DealDamage(damage);
            Destroy(gameObject);
        }
    }
}
