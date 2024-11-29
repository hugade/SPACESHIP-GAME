using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PROJECTILEScript : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody2D projectileRb;

    private float destroyDelay = 2f;

    private void Awake()
    {
        projectileRb = GetComponent<Rigidbody2D>();
    }

    public void ShootProjectile(Vector2 direction)
    { 
     projectileRb.velocity = direction * speed;

        Destroy(gameObject, destroyDelay);
    }

    private void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.tag == "meteorito" || col.gameObject.tag == "meteoritoG")
        {
            Destroy(gameObject);
        }
        
    }
}
