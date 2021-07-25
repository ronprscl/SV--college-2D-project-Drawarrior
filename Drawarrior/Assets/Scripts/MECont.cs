using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MECont : MonoBehaviour
{

    int random;
    float timer;
    Rigidbody2D rb;
    public LineCont lineCont;
    public GameObject magicSword;
    public GameObject healthPot;
    public GameObject player;
    Animator animator;
    bool isAttack;
    public GameObject alertArrow;
    int heartIndex;
    Vector2 positionWhenStartAtt;
    public GameObject[] hearts = new GameObject[4];
    // Start is called before the first frame update
    void Start()
    {
        timer = 3;
        rb = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();
        
        heartIndex = 0;
        animator.Play("MEIdle2");
      
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
                StartCoroutine(MagicAttack());
            }
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {

            if (lineCont.GetResult() == "square" || lineCont.GetResult() == "squareLeft")
            {


                switch (heartIndex)
                {
                    case 0:
                        Destroy(hearts[heartIndex]);
                        Destroy(hearts[heartIndex + 1]);
                        heartIndex += 2;
                        
                        break;
                    case 1:
                        Destroy(hearts[heartIndex]);
                        Destroy(hearts[heartIndex + 1]);
                        heartIndex += 2;
                        
                        break;
                    case 2:
                      
                        Destroy(hearts[heartIndex]);
                        Destroy(hearts[heartIndex + 1]);
                        heartIndex += 2;
                        break;
                    case 3:
                        Destroy(hearts[heartIndex]);
                        heartIndex++;
                        break;
                }


                if (heartIndex == 4)
                {
                    StartCoroutine(Death());
                }
                else
                {
                    StartCoroutine(Injure());
                }


            }
            else
            {

            }
        }
        else if (collision.transform.tag == "Kunai")
        {
            Destroy(hearts[heartIndex]);
            heartIndex++;
            if (heartIndex == 4)
            {
                StopCoroutine(Injure());
                StopCoroutine(MagicAttack());
                StartCoroutine(Death());
            }
            else
            {
                StartCoroutine(Injure());
            }
        }

    }
    IEnumerator Death()
    {
        animator.Play("MeDeath");

        yield return new WaitForSeconds(1);
        Instantiate(healthPot, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    IEnumerator Injure()
    {
        animator.Play("MEInjure");
        yield return new WaitForSeconds(1);
        animator.Play("MEIdle2");
        StopCoroutine(Injure());
    }
    IEnumerator MagicAttack()
    {
        isAttack = true;
        animator.Play("MEMagicAttack");
        positionWhenStartAtt = player.transform.position;
        GameObject hez = Instantiate(alertArrow, positionWhenStartAtt, Quaternion.identity);
        yield return new WaitForSeconds(2);
        Destroy(hez);
        GameObject SwordAttack = Instantiate(magicSword, positionWhenStartAtt , Quaternion.identity);
        animator.Play("MEIdle2");
        yield return new WaitForSeconds(1);
        Destroy(SwordAttack);
        
        StopCoroutine(MagicAttack());
        isAttack = false;

    }
}






