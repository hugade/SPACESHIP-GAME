using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Spaceship : MonoBehaviour
{
    [SerializeField, Range(1f, 20f)] public float rotationspeed;

    private Camera cam;

    [SerializeField] private PROJECTILEScript projectilePrefab;

    [SerializeField] private FIRE2SCRIPT projectile2Prefab;

    [SerializeField] private Transform projectilePosition;

    public float cdshoot, cdshoot2, cdenergy, time, time2, energytime;

    public GameObject shield, energy5, energy4, energy3, energy2, energy1, energy0, vida3, vida2, vida1, vida0;

    public int energylvl, vidalvl;

    public bool shieldon;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;

        cdshoot = time;

        cdshoot2 = time2;

        cdenergy = 6;

        energylvl = 3;

        vidalvl = 3;

        shieldon = false;
    }

    // Update is called once per frame
    void Update()
    {
        MouseControl();

        ATK();

        SHIELDFunction();
    }

    private void MouseControl()
    {
        Vector2 mouseWorldPoint = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = mouseWorldPoint - (Vector2)transform.position;

        transform.up = Vector2.MoveTowards(transform.up, direction, rotationspeed * Time.deltaTime);
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
        if (Input.GetKeyDown(KeyCode.Space) && cdenergy == 6)
        {
            shield.SetActive(true);

            shieldon = true;

            cdenergy = 3;
        }

        if (shieldon == true)
        {
            cdenergy -= Time.deltaTime;

            if (cdenergy <= 0)
            {
                shieldon = false;

                shield.SetActive(false);
            }
        }

        if (shieldon == false && cdenergy < 6)
        {
            cdenergy += Time.deltaTime;

            if (cdenergy >= 6)
            {
                cdenergy = 6;
            }
        }

        if (energylvl == 3)
        {
            if (cdenergy <= 0 && shieldon == true || cdenergy >= 0 && shieldon == false)
            {
                energy0.SetActive(true);
                energy1.SetActive(false);
                energy2.SetActive(false);
                energy3.SetActive(false);
            }

            if (cdenergy > 0 && shieldon == true || cdenergy >= 2 && shieldon == false)
            {
                energy0.SetActive(false);
                energy1.SetActive(true);
                energy2.SetActive(false);
                energy3.SetActive(false);
            }

            if (cdenergy >= 1 && shieldon == true || cdenergy >= 4 && shieldon == false)
            {
                energy0.SetActive(false);
                energy1.SetActive(false);
                energy2.SetActive(true);
                energy3.SetActive(false);
            }

            if (cdenergy >= 2 && shieldon == true || cdenergy >= 6 && shieldon == false)
            {
                energy0.SetActive(false);
                energy1.SetActive(false);
                energy2.SetActive(false);
                energy3.SetActive(true);
            }
        }
    }

    private void GestionVida()
    {
        if (vidalvl == 2)
        {
            vida3.SetActive(false);
            vida2.SetActive(true);
        }

        if (vidalvl == 1)
        {
            vida2.SetActive(false);
            vida1.SetActive(true);
        }

        if (vidalvl <= 0)
        {
            vida1.SetActive(false);
            vida0.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "meteorito" || col.gameObject.tag == "meteoritoG")
        {
            vidalvl--;

            GestionVida();

            if (vidalvl == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
