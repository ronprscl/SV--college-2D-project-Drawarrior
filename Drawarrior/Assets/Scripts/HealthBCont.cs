using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBCont : MonoBehaviour
{
    public Sprite fullHealth;
    public Sprite twoThirds;
    public Sprite oneThird;
    public Sprite Empty;
    Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerCont.lives == 3)
        {
            image.sprite = fullHealth;
        }
        else if(PlayerCont.lives == 2)
        {
            image.sprite = twoThirds;
        }
        else if(PlayerCont.lives == 1)
        {
            image.sprite = oneThird;
        }
        else
        {
            image.sprite = Empty;
        }
        
    }
}
