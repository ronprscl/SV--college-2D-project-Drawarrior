﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PTCont : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Ground")
        {
            PlayerCont.isGrounded = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            PlayerCont.isGrounded = true;
        }
    }
}
