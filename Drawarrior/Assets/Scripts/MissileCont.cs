using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileCont : MonoBehaviour
{
    public GameObject NPC;
    Rigidbody2D rb;
    Animator animator;
    bool isHit;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if(isHit == false)
        {
            if (NPC.transform.localScale.x > 0)
            {
                rb.velocity = new Vector2(30, 0);

            }
            else
            {
                rb.velocity = new Vector2(-30, 0);
            }
            transform.right = -rb.velocity;
        }
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(Boom());
    }

    IEnumerator Boom()
    {
        isHit = true;
        animator.Play("MissileBoom");
        rb.velocity = new Vector2(0, 0);
        rb.isKinematic = true;
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
