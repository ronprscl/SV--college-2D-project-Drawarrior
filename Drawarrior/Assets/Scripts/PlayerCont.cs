using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerCont : MonoBehaviour
{
    bool isTouchDoor;
    public LineCont lineCont;
    float speed;
    Rigidbody2D rb;
    Animator animator;
    public static bool isHitWhileSquare;
    public string dir;
    float timer;
    bool isWalk;
    float jumpThrust;
    bool isJump;
   public static bool isGrounded;
    bool isJumpCo;
    float translateSpeed;
    public GameObject kunai;
    bool isThrow;
    public static int lives;
    SpriteRenderer SR;
    bool isInjured;
    bool isAttacking;
    BoxCollider2D bCollider2D;
    Vector2 center;
    Vector2 contactPoint;
    string[] itemsTag;
    int itemIndex;
    public Image[] slots = new Image[4];
    bool isPickUp;
    public Image[] slotsCU = new Image[4];
    public Sprite GFX;
    int itemPickupIndex;
    GameObject door;
    
    

    // Start is called before the first frame update
    void Start()
    {
        itemPickupIndex = 0;
        slots[0] = slots[0].GetComponent<Image>();
        slots[1] = slots[1].GetComponent<Image>();
        slots[2] = slots[2].GetComponent<Image>();
        slots[3] = slots[3].GetComponent<Image>();
        slotsCU[0] = slotsCU[0].GetComponent<Image>();
        slotsCU[1] = slotsCU[1].GetComponent<Image>();
        slotsCU[2] = slotsCU[2].GetComponent<Image>();
        slotsCU[3] = slotsCU[3].GetComponent<Image>();


        itemsTag = new string[4];
        itemIndex = 0;
        bCollider2D = GetComponent<BoxCollider2D>();
        speed = 2000;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        timer = 1;
        isWalk = false;
        jumpThrust = 600;
        translateSpeed = 10f;
        lives = 3;
        SR = GetComponent<SpriteRenderer>();
        timer = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(lives <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }

        switch (itemIndex)
        {
            case 0:
               
                slotsCU[0].color = new Color(slotsCU[0].color.r, slotsCU[0].color.g, slotsCU[0].color.b, 0.3f);
                slotsCU[1].color = new Color(slotsCU[0].color.r, slotsCU[0].color.g, slotsCU[0].color.b, 0);
                slotsCU[2].color = new Color(slotsCU[0].color.r, slotsCU[0].color.g, slotsCU[0].color.b, 0);
                slotsCU[3].color = new Color(slotsCU[0].color.r, slotsCU[0].color.g, slotsCU[0].color.b, 0);
                break;
            case 1:
                slotsCU[1].color = new Color(slotsCU[1].color.r, slotsCU[1].color.g, slotsCU[1].color.b, 0.3f);
                slotsCU[0].color = new Color(slotsCU[0].color.r, slotsCU[0].color.g, slotsCU[0].color.b, 0);
                slotsCU[2].color = new Color(slotsCU[0].color.r, slotsCU[0].color.g, slotsCU[0].color.b, 0);
                slotsCU[3].color = new Color(slotsCU[0].color.r, slotsCU[0].color.g, slotsCU[0].color.b, 0);
                break;
            case 2:
                slotsCU[2].color = new Color(slotsCU[2].color.r, slotsCU[2].color.g, slotsCU[2].color.b, 0.3f);
                slotsCU[1].color = new Color(slotsCU[0].color.r, slotsCU[0].color.g, slotsCU[0].color.b, 0);
                slotsCU[0].color = new Color(slotsCU[0].color.r, slotsCU[0].color.g, slotsCU[0].color.b, 0);
                slotsCU[3].color = new Color(slotsCU[0].color.r, slotsCU[0].color.g, slotsCU[0].color.b, 0);
                break;
            case 3:
                slotsCU[3].color = new Color(slotsCU[3].color.r, slotsCU[3].color.g, slotsCU[3].color.b, 0.3f);
                slotsCU[0].color = new Color(slotsCU[0].color.r, slotsCU[0].color.g, slotsCU[0].color.b, 0);
                slotsCU[1].color = new Color(slotsCU[0].color.r, slotsCU[0].color.g, slotsCU[0].color.b, 0);
                slotsCU[2].color = new Color(slotsCU[0].color.r, slotsCU[0].color.g, slotsCU[0].color.b, 0);
                break;
                

        }
        if (isPickUp)
        {
            if (Input.GetAxisRaw("Mouse ScrollWheel") > 0 && itemIndex < 3)
            {
                itemIndex++;
            }
            else if (Input.GetAxisRaw("Mouse ScrollWheel") > 0 && itemIndex == 3)
            {
                itemIndex = 0;
            }
            else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0 && itemIndex > 0)
            {
                itemIndex--;
            }
            else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0 && itemIndex == 0)
            {
                itemIndex = 3;
            }
        }
      
        if (lineCont.GetResult() == "square")
        {
            
            animator.Play("PlayerAttack");
            rb.velocity = new Vector2(8, 0);
            transform.localScale = new Vector3(1, 1, 1);
           
        }
        else if(lineCont.GetResult() == "squareLeft")
        {
           
            animator.Play("PlayerAttack");
            rb.velocity = new Vector2(-8, 0);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (lineCont.GetResult() == "triangle" && isThrow == false || lineCont.GetResult() == "triangleLeft" && isThrow == false)
        {
            StartCoroutine(ThrowKunai());
           
        }
        else if (lineCont.GetResult() == "lineF" )
        {

            transform.Translate(translateSpeed * Time.deltaTime, 0, 0);

           
           
         if (isJumpCo == false)
            {
                animator.Play("PlayerRun");
            }
            transform.localScale = new Vector3(1, 1, 1);
           

           
        }
        else if(lineCont.GetResult() == "lineB")
        {
            transform.Translate(-translateSpeed * Time.deltaTime, 0, 0);
           
            if (isJumpCo == false)
            {
                animator.Play("PlayerRun");
            }
            transform.localScale = new Vector3(-1, 1, 1);
            
        }
      
        else if (isJumpCo == false)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            animator.Play("PlayerIdle");
            
        }
        if (Input.GetKeyDown(KeyCode.W) && isGrounded == true)
        {
           
            rb.AddForce(transform.up * jumpThrust);
            isJump = true;
        }
       if (Input.GetKeyDown(KeyCode.R))
        {
            switch (itemsTag[itemIndex])
            {
                case "HealthPot":
                    if(lives < 3)
                    {
                        lives++;
                    }
                    itemsTag[itemIndex] = "none";
                    slots[itemIndex].sprite = GFX;
                    slots[itemIndex].color = new Color(slotsCU[0].color.r, slotsCU[0].color.g, slotsCU[0].color.b, 0);
                    
                    break;
                case "Key":
                    if (isTouchDoor)
                    {
                        Destroy(door);
                    }
                    break;
            }
        }
        if (isJump)
        {
            StartCoroutine(JumpGlide());
        }

        if (timer < 0)
        {
            lives--;
            timer = 1;

        }



    }
    
    IEnumerator JumpGlide()
    {
        isJump = false;
        isJumpCo = true;
       
        
        animator.Play("PlayerJump");
        yield return new WaitForSeconds(0.5f);
        animator.Play("PlayerGlide");
        yield return new WaitUntil(() => isGrounded == true);
        isJumpCo = false;
        StopCoroutine(JumpGlide());
        
    }
    IEnumerator ThrowKunai()
    {
        isThrow = true;
        if (lineCont.GetResult() == "triangleLeft")
        {
            GameObject sakin = Instantiate(kunai, new Vector2(transform.position.x - 2, transform.position.y), Quaternion.identity);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            GameObject sakin = Instantiate(kunai, new Vector2(transform.position.x + 2, transform.position.y), Quaternion.identity);
            transform.localScale = new Vector3(1, 1, 1);
        }
        yield return new WaitForSeconds(1);
        isThrow = false;
        StopCoroutine(ThrowKunai());

    }
    IEnumerator Injured()
    {
        isInjured = true;
        SR.enabled = false;
        yield return new WaitForSeconds(0.1f);
        SR.enabled = true;
        yield return new WaitForSeconds(0.1f);
        SR.enabled = false;
        yield return new WaitForSeconds(0.1f);
        SR.enabled = true;
        yield return new WaitForSeconds(0.1f);
        SR.enabled = false;
        yield return new WaitForSeconds(0.1f);
        SR.enabled = true;
        yield return new WaitForSeconds(0.1f);
        SR.enabled = false;
        yield return new WaitForSeconds(0.1f);
        SR.enabled = true;
        yield return new WaitForSeconds(0.1f);
        SR.enabled = false;
        yield return new WaitForSeconds(0.1f);
        SR.enabled = true;
        yield return new WaitForSeconds(0.1f);
        SR.enabled = false;
        yield return new WaitForSeconds(0.1f);
        SR.enabled = true;
       
        StopCoroutine(Injured());
        isInjured = false;
    }
   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Door")
        {
            isTouchDoor = true;
            door = collision.gameObject;
        }
        if (collision.transform.tag == "Ground")
        {
           contactPoint = collision.contacts[0].point;
           center = bCollider2D.bounds.center;

           
            bool top = contactPoint.y > center.y;
            //if( top == true)
            //{
            //    bCollider2D.isTrigger = true;
            //    rb.isKinematic = true;
            //}
           
            isGrounded = true;
        }
        
        else if (collision.transform.tag == "Enemy" && lineCont.GetResult() != "square" && lineCont.GetResult() != "squareLeft" && isInjured == false)
        {
            lives--;
            StartCoroutine(Injured());
            if (isGrounded)
            {
                switch (transform.localScale.x)
                {
                    case 1:
                        rb.AddForce(-transform.right * 3000);
                        rb.AddForce(transform.up * 200);
                        break;
                    case -1:
                        rb.AddForce(transform.right * 3000);
                        rb.AddForce(transform.up * 200);
                        break;
                }
            }
           
            isHitWhileSquare = true;
        }
        else if(collision.transform.tag == "Enemy" && lineCont.GetResult() == "square"|| collision.transform.tag == "Enemy" && lineCont.GetResult() == "squareLeft")
        {
            
            switch (transform.localScale.x)
            {
                case 1:
                    rb.AddForce(-transform.right * 3000);
                    rb.AddForce(transform.up * 100);
                    break;
                case -1: rb.AddForce(transform.right * 3000);
                    rb.AddForce(transform.up * 100);
                    break;
            }
            isHitWhileSquare = true;
           
        }
        else if(collision.transform.tag == "Missile")
        {
            lives -= 3;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.transform.tag == "EnemyArrow")
        //{
        //    lives--;
        //    StartCoroutine(Injured());
        //}
        //else if (collision.transform.tag == "HealthPot")
        //{
        //    isPickUp = true;
        //    if(itemPickupIndex < 3)
        //    {
               
        //        slots[itemPickupIndex].sprite = collision.GetComponent<SpriteRenderer>().sprite;
        //        slots[itemPickupIndex].color = new Color(slots[itemIndex].color.r, slots[itemIndex].color.g, slots[itemIndex].color.b, 1);
        //        itemsTag[itemPickupIndex] = collision.transform.tag;
        //        Debug.Log(collision.transform.name + " added to" + itemPickupIndex);

        //        Destroy(collision.gameObject);
        //        itemPickupIndex++;
        //    }
          
        //}
        switch (collision.transform.tag)
        {
            case "EnemyArrow":
                lives--;
                StartCoroutine(Injured());
                break;
            case "HealthPot":
                isPickUp = true;
                if (itemPickupIndex < 3)
                {

                    slots[itemPickupIndex].sprite = collision.GetComponent<SpriteRenderer>().sprite;
                    slots[itemPickupIndex].color = new Color(slots[itemIndex].color.r, slots[itemIndex].color.g, slots[itemIndex].color.b, 1);
                    itemsTag[itemPickupIndex] = collision.transform.tag;
                    Debug.Log(collision.transform.name + " added to" + itemPickupIndex);

                    Destroy(collision.gameObject);
                    itemPickupIndex++;
                }
                break;
            case "Key":
                isPickUp = true;
                if (itemPickupIndex < 3)
                {

                    slots[itemPickupIndex].sprite = collision.GetComponent<SpriteRenderer>().sprite;
                    slots[itemPickupIndex].color = new Color(slots[itemIndex].color.r, slots[itemIndex].color.g, slots[itemIndex].color.b, 1);
                    itemsTag[itemPickupIndex] = collision.transform.tag;
                    Debug.Log(collision.transform.name + " added to" + itemPickupIndex);

                    Destroy(collision.gameObject);
                    itemPickupIndex++;
                }
                break;


        }


    }
    private void OnTriggerStay2D(Collider2D collision)
    {
         if (collision.transform.tag == "Ladder")
        {
          
            if (Input.GetKey(KeyCode.W))
            {
                bCollider2D.isTrigger = true;
                //rb.isKinematic = true;
                rb.AddForce(transform.up * 100 * Time.deltaTime);
               
            }
            else if (Input.GetKey(KeyCode.S))
            {
                
                bCollider2D.isTrigger = true;
                //rb.isKinematic = true;
                rb.AddForce(transform.up * -100 * Time.deltaTime);
               
            }
           

        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        
        if (collision.transform.tag == "Enemy")
        {
            timer -= Time.deltaTime;

            Debug.Log(timer);
        }
        
       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
       
        if(collision.transform.tag == "Ladder")
        {
            bCollider2D.isTrigger = false;
            animator.Play("PlayerIdle");
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            isGrounded = false;
            isJump = true;
        }
       else if (collision.transform.tag == "Enemy")
        {
            timer = 1;
            Debug.Log("col exit");
        }
    }
   

}
