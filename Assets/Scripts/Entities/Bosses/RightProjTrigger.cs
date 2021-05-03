using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightProjTrigger : MonoBehaviour
{
    public GameObject redLaser;
    public GameObject lpEye;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Random.Range(0, 5) == 0)
            {
                GameObject rl = Instantiate(redLaser, new Vector2(lpEye.transform.position.x, lpEye.transform.position.y), Quaternion.identity);
                rl.GetComponent<RedLaser>().goLeft = false;
            }
        }
    }
}
