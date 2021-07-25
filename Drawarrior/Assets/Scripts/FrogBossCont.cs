using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogBossCont : MonoBehaviour
{
    int random;
    float timer;
    Rigidbody2D rb;
    public LineCont lineCont;
    public Sprite injureState;

    Animator animator;
    int lives;
    // Start is called before the first frame update
    void Start()
    {
        timer = 3;
        rb = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();
        lives = 20;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            random = Random.Range(-1, 2);
            timer = 3;
        }
        rb.velocity = new Vector2(random, rb.velocity.y);
        if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            animator.Play("FrogBossWalk");

        }
        else if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            animator.Play("FrogBossWalk");
        }
        else
        {
            animator.Play("FrogBossIdle2");
        }
    }
}
