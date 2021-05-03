using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : AIBase
{
    public float speed = 25f;

    public bool rotateOnce = false;

    public Vector3 movePosition;
    private float dist;

    public Vector3 shootDirection;
   
    public bool goLeft = false;

    public bool created = false;

    public GameObject arrowInst;

    public GameObject arrowObj;

    void Start()
    {
        if (GameObject.Find("NetworkManager") != null)
        {
            shootDirection = (GameObject.FindGameObjectWithTag("Player").transform.Find("Camera").GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition) - transform.position);
        }
        else
        {
            shootDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        }
        shootDirection.z = 0;
        shootDirection.Normalize();
    }

    void Update()
    {
        transform.position = transform.position + shootDirection * speed * Time.deltaTime;

        if (!rotateOnce)
        {
            float angle;
            angle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            rotateOnce= true;
        }

        created = true;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Terrain")
        {
            Destroy(this.gameObject);
        }
    }
}