using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCCont : MonoBehaviour
{
    public Text text;
    public Button button, button2;
    public GameObject BH1, BH2;
   
    Animator animator;
   
   
    bool isFriendly;
  
   
   


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        text.text = "";
        isFriendly = false;
        button.gameObject.SetActive(false);
        button2.gameObject.SetActive(false);
       
    }
    private void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Debug.Log(isFriendly);
        //}
    }



    private void OnMouseDown()
    {

        
            text.text = "...Who are you?";
        button.gameObject.SetActive(true);
        button2.gameObject.SetActive(true);



    }

    public void ButtonChoice(string result)
    {





        if (result == "A ninja")
        {
            isFriendly = false;
            Debug.Log(isFriendly);
        }
        else if (result == "I don't know")
        {
            isFriendly = true;
            Debug.Log(isFriendly);
        }


    }






}
