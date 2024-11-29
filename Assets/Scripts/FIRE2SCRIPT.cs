using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FIRE2SCRIPT : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody2D projectile2Rb;

    private float destroyDelay = 2f;

    private void Awake()
    {
        projectile2Rb = GetComponent<Rigidbody2D>();
    }

    public void ShootFire2(Vector2 direction)
    {
        projectile2Rb.velocity = direction * speed;

        Destroy(gameObject, destroyDelay);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "meteorito" || col.gameObject.tag == "meteoritoG")
        {
            Destroy(gameObject);
        }

    }
}
