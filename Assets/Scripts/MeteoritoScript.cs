using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MeteoritoScript : MonoBehaviour
{
    public float speed;

    public int vida;

    private Rigidbody2D meteoritoRb;

    public GameObject PlayerObj;

    private float distancePlayerObj;

    public GameObject meteoro;

    private Vector3 meteoroposition1;

    private Vector3 meteoroposition2;

    private GameObject UIManagerObject;
    private UIManagerScript uimanagerscript;

    // Start is called before the first frame update
    void Start()
    {
        meteoritoRb = GetComponent<Rigidbody2D>();

        meteoroposition1 = new Vector3 (gameObject.transform.position.x + 2, gameObject.transform.position.y, 0);

        meteoroposition2 = new Vector3(gameObject.transform.position.x - 2, gameObject.transform.position.y, 0);

        UIManagerObject = GameObject.Find("UIManager");
        uimanagerscript = UIManagerObject.GetComponent<UIManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        distancePlayerObj = Vector2.Distance(transform.position, PlayerObj.transform.position);

        Vector3 direction = (PlayerObj.transform.position - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime);

        if (vida <= 0)
        {
            DestroyMe();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "projectile")
        {
            vida--;

            if (vida <= 0)
            {
                uimanagerscript.UIScore++;

                if (this.gameObject.tag == "meteoritoG")
                {
                    uimanagerscript.UIScore++;
                }   
            }
            
        }

        if (col.gameObject.tag == "projectile2")
        {
            vida = vida - 4;

            uimanagerscript.UIScore++;

            if (this.gameObject.tag == "meteoritoG")
            {
                uimanagerscript.UIScore++;
            }
        }

        if (col.gameObject.tag == "player")
        {
            Destroy(gameObject);
        }

        if (col.gameObject.tag == "shield")
        {
            Destroy(gameObject);
        }
    }

    private void DestroyMe()
    {
        meteoroposition1 = new Vector3(gameObject.transform.position.x + 2, gameObject.transform.position.y, 0);

        meteoroposition2 = new Vector3(gameObject.transform.position.x - 2, gameObject.transform.position.y, 0);

        if (this.gameObject.tag == "meteoritoG")
        {
            Instantiate(meteoro, meteoroposition1, gameObject.transform.rotation);

            Instantiate(meteoro, meteoroposition2, gameObject.transform.rotation);
        }
        

        Destroy(gameObject);
    }
}
