using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiCont : MonoBehaviour
{
     PlayerCont player;
    Rigidbody2D rb;
    float thrust;
   

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        thrust = 1500;
        player = FindObjectOfType<PlayerCont>();
        if (player.gameObject.transform.localScale.x < 0)
        {
            rb.AddForce(-transform.right * thrust);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            rb.AddForce(transform.right * thrust);
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Enemy")
        {
            //Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }
}
