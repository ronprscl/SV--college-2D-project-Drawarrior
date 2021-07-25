using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCont : MonoBehaviour
{
    
    int random;
    int randomDrop;
    float timer;
    Rigidbody2D rb;
    public LineCont lineCont;
    public Sprite injureState;
    
    Animator animator;
    int lives;
    int heartIndex;
    public GameObject[] hearts = new GameObject[3];
    public GameObject healthPotDrop;
    // Start is called before the first frame update
    void Start()
    {
        timer = 3;
        rb = GetComponent<Rigidbody2D>();
        
        animator = GetComponent<Animator>();
        lives = 3;
        heartIndex = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            random = Random.Range(-1, 2);
            timer = 3;
        }
        rb.velocity = new Vector2(random, rb.velocity.y);
        if(rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);

        }
        else if(rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Debug.Log(heartIndex);
            if (lineCont.GetResult() == "square" || lineCont.GetResult() == "squareLeft")
            {


                switch (heartIndex)
                {
                    case 0: Destroy(hearts[heartIndex]);
                        Destroy(hearts[heartIndex + 1]);
                        heartIndex += 2;
                       
                        break;
                    case 1:
                        Destroy(hearts[heartIndex]);
                        Destroy(hearts[heartIndex + 1]);
                        heartIndex += 2;
                        
                        break;
                    case 2: Destroy(hearts[heartIndex]);
                        heartIndex++;
                      
                        break;
                        

                }
                

                if (heartIndex == 3)
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
            if (heartIndex == 3)
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
        animator.Play("EnemyInjure");
        yield return new WaitForSeconds(1);
        animator.Play("EnemyIdle");
        StopAllCoroutines();
    }
    IEnumerator Death()
    {
        animator.Play("EnemyDeath");
       
            yield return new WaitForSeconds(1);
        randomDrop = Random.Range(0, 4);
        if (randomDrop == 0)
        {
           
            Instantiate(healthPotDrop, transform.position, Quaternion.identity);
        }
       
        Destroy(gameObject);
       
    }
}
