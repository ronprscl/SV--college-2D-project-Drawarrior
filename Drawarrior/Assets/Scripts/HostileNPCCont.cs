using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostileNPCCont : MonoBehaviour
{
    int random;
    float timer;
    Rigidbody2D rb;
    public LineCont lineCont;
    public Sprite injureState;
    BoxCollider2D bCol;
    Animator animator;
    int lives;
    int heartIndex;
    public GameObject NPC;
    // Start is called before the first frame update
    void Start()
    {
        NPC = GameObject.FindGameObjectWithTag("NPC");
        lineCont = FindObjectOfType<LineCont>();
        timer = 3;
        rb = GetComponent<Rigidbody2D>();
        bCol = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        lives = 3;
        heartIndex = 0;
        StartCoroutine(Spawn());
        
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

        }
        else if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
       
       
    }
    IEnumerator Spawn()
    {
        Destroy(NPC);
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).IsName("NPCIdle"));
        bCol.enabled = true;
        rb.bodyType = RigidbodyType2D.Dynamic;
        StopCoroutine(Spawn());
    }
}
