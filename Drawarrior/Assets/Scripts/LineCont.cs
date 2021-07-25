using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCont : MonoBehaviour
{
    
    LineRenderer lineR;
    float offset;
    float offsetTri;
     private string result;
    float timer;
    bool isTimer;
   
    // Start is called before the first frame update
    void Start()
    {
        
        lineR = GetComponent<LineRenderer>();
        offset = 1;
        offsetTri = 3f;
        timer =0.8f;
    }

    // Update is called once per frame
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector2 rayV = ray.GetPoint(0);

        if (Input.GetMouseButtonDown(0))
        {
            
            lineR.positionCount++;
            lineR.SetPosition(lineR.positionCount -1 , rayV);
           
            

        }
        else if (Input.GetMouseButtonDown(1))
        {

            result = LineCheck();
            if(result != "lineF" && result != "lineB"  && result != "SquareUp")
            {
                isTimer = true;
            }
            
            Debug.Log(GetResult());

        }
       else if (Input.GetKeyDown(KeyCode.Space) || PlayerCont.isHitWhileSquare == true || Input.GetKeyDown(KeyCode.W) && result != "lineF" &&  result != "lineB")
        {
            lineR.positionCount = 0;
            result = LineCheck();
            PlayerCont.isHitWhileSquare = false;
            isTimer = false;
        }

        if (isTimer)
        {
            timer -= Time.deltaTime;
            if(timer < 0)
            {
                lineR.positionCount = 0;
                result = LineCheck();
                timer = 0.8f;
                isTimer = false;
            }
        }


       
       
       
    }
    string LineCheck()
    {
        if (lineR.positionCount == 4 && Mathf.Abs(lineR.GetPosition(0).y - lineR.GetPosition(1).y) < offset &&
           Mathf.Abs(lineR.GetPosition(1).x - lineR.GetPosition(2).x) < offset && Mathf.Abs(lineR.GetPosition(2).y - lineR.GetPosition(3).y) < offset
           && Vector2.Distance(lineR.GetPosition(0), lineR.GetPosition(1)) > 2 && Vector2.Distance(lineR.GetPosition(1), lineR.GetPosition(2)) > 2 &&
           Vector2.Distance(lineR.GetPosition(2), lineR.GetPosition(3)) > 2 && lineR.GetPosition(1).x > lineR.GetPosition(0).x)
        {

           
           
            return "square";
            
        }
        else if (lineR.positionCount == 3 && Mathf.Abs(lineR.GetPosition(0).y - lineR.GetPosition(2).y) > Mathf.Abs(lineR.GetPosition(0).y -
            lineR.GetPosition(1).y) - offsetTri && Mathf.Abs(lineR.GetPosition(0).y - lineR.GetPosition(2).y) < Mathf.Abs(lineR.GetPosition(0).y -
            lineR.GetPosition(1).y) + offsetTri && lineR.GetPosition(0).x - lineR.GetPosition(1).x < 1 && lineR.GetPosition(1).x - lineR.GetPosition(2).x > 1 && 
            Vector2.Distance(lineR.GetPosition(0), lineR.GetPosition(1)) < Vector2.Distance(lineR.GetPosition(1), lineR.GetPosition(2)) +1.5f &&
            Vector2.Distance(lineR.GetPosition(0), lineR.GetPosition(1)) > Vector2.Distance(lineR.GetPosition(1), lineR.GetPosition(2)) - 1.5f)
        {
            return "triangle";
        }
        else if (lineR.positionCount == 3 && Mathf.Abs(lineR.GetPosition(0).y - lineR.GetPosition(2).y) > Mathf.Abs(lineR.GetPosition(0).y -
            lineR.GetPosition(1).y) - offsetTri && Mathf.Abs(lineR.GetPosition(0).y - lineR.GetPosition(2).y) < Mathf.Abs(lineR.GetPosition(0).y -
            lineR.GetPosition(1).y) + offsetTri && lineR.GetPosition(0).x - lineR.GetPosition(1).x > 1 && lineR.GetPosition(1).x - lineR.GetPosition(2).x < 1 &&
            Vector2.Distance(lineR.GetPosition(0), lineR.GetPosition(1)) < Vector2.Distance(lineR.GetPosition(1), lineR.GetPosition(2)) + 1.5f &&
            Vector2.Distance(lineR.GetPosition(0), lineR.GetPosition(1)) > Vector2.Distance(lineR.GetPosition(1), lineR.GetPosition(2)) - 1.5f )
        {
            return "triangleLeft";
        }
        else if (lineR.positionCount == 2 && Mathf.Abs(lineR.GetPosition(0).y - lineR.GetPosition(1).y) < 1 && lineR.GetPosition(0).x -
            lineR.GetPosition(1).x < -1)
        {
            return "lineF";
        }
        else if (lineR.positionCount == 2 && Mathf.Abs(lineR.GetPosition(0).y - lineR.GetPosition(1).y) < 1 && lineR.GetPosition(0).x - lineR.GetPosition(1).x > 1)
        {
            return "lineB";
            
        }
        else if (lineR.positionCount == 4 && Mathf.Abs(lineR.GetPosition(0).y - lineR.GetPosition(1).y) < offset &&
             Mathf.Abs(lineR.GetPosition(1).x - lineR.GetPosition(2).x) < offset && Mathf.Abs(lineR.GetPosition(2).y - lineR.GetPosition(3).y) < offset
             && Vector2.Distance(lineR.GetPosition(0), lineR.GetPosition(1)) > 2 && Vector2.Distance(lineR.GetPosition(1), lineR.GetPosition(2)) > 2 &&
             Vector2.Distance(lineR.GetPosition(2), lineR.GetPosition(3)) > 2 && lineR.GetPosition(1).x < lineR.GetPosition(0).x)
        {
            return "squareLeft";
        }
        else if(lineR.positionCount == 4 && Mathf.Abs(lineR.GetPosition(0).x - lineR.GetPosition(1).x) < offset &&
            Mathf.Abs(lineR.GetPosition(1).y - lineR.GetPosition(2).y) < offset && Mathf.Abs(lineR.GetPosition(2).x - lineR.GetPosition(3).x) < offset &&
            Vector2.Distance(lineR.GetPosition(0), lineR.GetPosition(1)) > 2 && Vector2.Distance(lineR.GetPosition(1), lineR.GetPosition(2)) > 2 &&
             Vector2.Distance(lineR.GetPosition(2), lineR.GetPosition(3)) > 2)
        {
            return "SquareUp";
        }
        else
        {
            return "none";
        }
    }
    public string GetResult()
    {
        return result;
    }
}
