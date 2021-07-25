using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCTry : MonoBehaviour
{
    public Button button, button2;
    bool isFriendly;
    Animator animator;
    public Text text;
    public GameObject missile;
    float offset;
    public GameObject key;
    bool isDone;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isFriendly = true;
        button.gameObject.SetActive(false);
        button2.gameObject.SetActive(false);
        text.text = "";

    }

    // Update is called once per frame
    void Update()
    {
        if(isFriendly == false)
        {
            Debug.Log("istest is verifird false");
        }
        if(transform.localScale.x > 0)
        {
            offset = -2;
        }
        else
        {
            offset = 2;
        }
       
    }


    private void OnMouseDown()
    {
        if(isDone == false)
        {
            button.gameObject.SetActive(true);
            button2.gameObject.SetActive(true);
            text.text = "Who are you...?";
        }
       
    }

    public void ButtonCheck(string choice)
    {
        if(choice == "IDK")
        {
            isFriendly = true;
            StartCoroutine(KeyGive());
           
        }
        else if(choice == "A ninja")
        {
            isFriendly = false;
            StartCoroutine(PrepareToDie());
           
        }
        button.gameObject.SetActive(false);
        button2.gameObject.SetActive(false);
        

    }
    IEnumerator PrepareToDie()
    {
        isDone = true;
        text.text = "Very well... Then it is time.";
        yield return new WaitForSeconds(3);
        transform.localScale = new Vector3(-1, 1, 1);
        text.text = "";
        animator.Play("NPCMissileAttack2");
        yield return new WaitForSeconds(1.5f);
        GameObject til = Instantiate(missile, new Vector2(transform.position.x + offset, transform.position.y), Quaternion.identity);
        animator.Play("NPCIdle");
        StopCoroutine(PrepareToDie());

    }
    IEnumerator KeyGive()
    {
        isDone = true;
        transform.localScale = new Vector3(-1, 1, 1);
        text.text = "Then you must go. Take this.";
        yield return new WaitForSeconds(2);
        text.text = "";
        Instantiate(key, new Vector2(transform.position.x + offset, transform.position.y), Quaternion.identity);
        StopCoroutine(KeyGive());
    }

    
}
