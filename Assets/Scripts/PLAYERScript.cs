using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PLAYERScript : MonoBehaviour
{
    [SerializeField, Range(1f, 20f)] private float rotationspeed;

    private Camera cam;

    [SerializeField] private PROJECTILEScript projectilePrefab;

    [SerializeField] private FIRE2SCRIPT projectile2Prefab;

    [SerializeField] private Transform projectilePosition;

    public  float cdshoot;

    public float cdshoot2;

    public float cdenergy;

    public int vida;

    public float time;

    public float time2;

    public float energytime;

    public GameObject shield;

    public GameObject vidaSÍ0, vidaSÍ1, vidaSÍ2, vidaNO0, vidaNO1, vidaNO2, energy5, energy4, energy3, energy2, energy1, energy0;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;

        cdshoot = time;

        cdshoot2 = time2;

        cdenergy = energytime;

        shield.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        MouseControl();

        ATK();

        SHIELDFunction();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "meteorito" || col.gameObject.tag == "meteoritoG")
        {
            vida--;

            GestionVidas();

            if (vida == 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void ATK()
    {
        cdshoot -= Time.deltaTime;

        cdshoot2 -= Time.deltaTime;

        if (Input.GetButtonDown("Fire1") && cdshoot <= 0)
        {
            PROJECTILEScript projectile = Instantiate(projectilePrefab, projectilePosition.position, transform.rotation);

            projectile.ShootProjectile(transform.up);

            cdshoot = time;
        }

        if (Input.GetButtonDown("Fire2") && cdshoot2 <= 0)
        {
            FIRE2SCRIPT projectile2 = Instantiate(projectile2Prefab, projectilePosition.position, transform.rotation);

            projectile2.ShootFire2(transform.up);

            cdshoot2 = time2;
        }
    }

    private void SHIELDFunction()
    {
        

        while (Input.GetKeyDown(KeyCode.Space) && cdenergy > 0)
        { 
            shield.SetActive(true);

            cdenergy -= Time.deltaTime;
        }

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            shield.SetActive(false);

            if (cdenergy < 10)
            {
                cdenergy += Time.deltaTime;
            }
        }

        if (cdenergy <= 0)
        {
            cdenergy = 0;

            energy0.SetActive(true);
            energy1.SetActive(false);
            energy2.SetActive(false);
            energy3.SetActive(false);
            energy4.SetActive(false);
            energy5.SetActive(false);
        }

        if (cdenergy >= 0)
        {
            energy0.SetActive(false);
            energy1.SetActive(true);
            energy2.SetActive(false);
            energy3.SetActive(false);
            energy4.SetActive(false);
            energy5.SetActive(false);
        }

        if (cdenergy >= 2)
        {
            energy0.SetActive(false);
            energy1.SetActive(false);
            energy2.SetActive(true);
            energy3.SetActive(false);
            energy4.SetActive(false);
            energy5.SetActive(false);
        }

        if (cdenergy >= 4)
        {
            energy0.SetActive(false);
            energy1.SetActive(false);
            energy2.SetActive(false);
            energy3.SetActive(true);
            energy4.SetActive(false);
            energy5.SetActive(false);
        }

        if (cdenergy >= 6)
        {
            energy0.SetActive(false);
            energy1.SetActive(false);
            energy2.SetActive(false);
            energy3.SetActive(false);
            energy4.SetActive(true);
            energy5.SetActive(false);
        }

        if (cdenergy >= 8)
        {
            energy0.SetActive(false);
            energy1.SetActive(false);
            energy2.SetActive(false);
            energy3.SetActive(false);
            energy4.SetActive(false);
            energy5.SetActive(true);
        }
    }

    private void GestionVidas()
    {
        if (vida == 2)
        { 
            vidaSÍ2.SetActive(false);
            vidaNO2.SetActive(true);
        }

        if (vida == 1)
        { 
            vidaSÍ1.SetActive(false);
            vidaNO1.SetActive(true);
        }

        if (vida <= 0)
        { 
            vidaSÍ0.SetActive(false);
            vidaNO0.SetActive(true);
        }
    }

    private void MouseControl()
    {
        Vector2 mouseWorldPoint = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = mouseWorldPoint - (Vector2)transform.position;

        transform.up = Vector2.MoveTowards(transform.up, direction, rotationspeed * Time.deltaTime);
    }
}
