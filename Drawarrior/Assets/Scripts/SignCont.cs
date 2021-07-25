using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignCont : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            text.text = "";
        }
    }

    private void OnMouseDown()
    {
        switch (transform.name)
        {
            case ("WalkSign"):
                text.text = "Press the left mouse button on two spots at the same height to move. Press 'Space' to redo the spots";
                break;
            case "JumpSign":
                text.text = "'W' to jump. Note: jumping removes current clicked spots.";
                break;
            case "AttackSign":
                text.text = "Draw three quarters of a square to attack (like a sideways table).";
                break;

        }
      
    }
}
