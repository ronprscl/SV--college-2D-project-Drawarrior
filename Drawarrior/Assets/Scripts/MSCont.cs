using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MSCont : MonoBehaviour
{
    public LineCont linecont;
    Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        linecont = FindObjectOfType<LineCont>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if(linecont.GetResult() == "SquareUp")
        {
            animator.Play("MSBlocked");
          
        }
        else
        {
           
            animator.Play("MSHit");
        }
    }
}
