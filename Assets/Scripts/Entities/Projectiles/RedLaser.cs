using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedLaser : AIBase
{

    public bool goLeft;

    void Update()
    {
        if (goLeft)
        {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(100, 3));
        } else if (!goLeft)
        {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(-100, 3));
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Health.health -= 25;
            Destroy(this.gameObject);
        }
    }
}
