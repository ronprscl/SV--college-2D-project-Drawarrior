using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWarCont : MonoBehaviour
{
    int random;
    float timer;
    Rigidbody2D rb;
    public LineCont lineCont;
    public Sprite injureState;
    Animator animator;
    int lives;
    int heartIndex;
    public GameObject[] hearts = new GameObject[20];
    bool isAttack;
    Vector2 positionWhenStartAtt;
    public GameObject player, alertArrow, magicHit;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = 3;
        rb = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();
        lives = 20;
        heartIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            random = Random.Range(-1, 2);
            timer = 3;
            if (Vector2.Distance(player.transform.position, transform.position) < 10 && isAttack == false)
            {
                StartCoroutine(GroundAttack());
            }
        }
        if(isAttack == false)
        {
            rb.velocity = new Vector2(random * 5, rb.velocity.y);
        }
       
        else if (rb.velocity.x < 0 && isAttack ==false)
        {
            transform.localScale = new Vector3(1, 1, 1);
            animator.Play("BossRun");

        }
        else if (rb.velocity.x > 0 && isAttack == false)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            animator.Play("BossRun");
        }
        else if(isAttack == false)
        {
            animator.Play("BossIdle1");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Debug.Log(heartIndex);
            if (lineCont.GetResult() == "square" || lineCont.GetResult() == "squareLeft")
            {



                if (heartIndex == 20)
                {
                    StartCoroutine(Death());
                }
                else if (heartIndex == 19)
                {
                    Destroy(hearts[heartIndex]);
                    StartCoroutine(Injure());
                }
                else
                {
                    Destroy(hearts[heartIndex]);
                    Destroy(hearts[heartIndex + 1]);
                    StartCoroutine(Injure());
                    heartIndex += 2;
                }


            }


           
        }
        else if (collision.transform.tag == "Kunai")
        {

            Destroy(hearts[heartIndex]);
            heartIndex++;
            if (heartIndex == 20)
            {
                StartCoroutine(Death());
            }
            else
            {
                StartCoroutine(Injure());
            }
        }

    }
   IEnumerator Injure()
    {
        animator.Play("BossInjured");
        yield return new WaitForSeconds(1);
        animator.Play("BossIdle1");
        StopCoroutine(Injure());
    }
    IEnumerator Death()
    {
        animator.Play("BossWDeath");

        yield return new WaitForSeconds(1);
        
        Destroy(gameObject);
    }
    IEnumerator GroundAttack()
    {
        isAttack = true;
        animator.Play("BossGAttack");
        positionWhenStartAtt = player.transform.position;
        GameObject azhara = Instantiate(alertArrow, positionWhenStartAtt, Quaternion.identity);
        yield return new WaitForSeconds(2);
        Destroy(azhara);
        GameObject pgia = Instantiate(magicHit, positionWhenStartAtt, Quaternion.identity);
        animator.Play("BossIdle1");
        yield return new WaitForSeconds(1);
        Destroy(pgia);

        StopCoroutine(GroundAttack());
        isAttack = false;

    }
}
