using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadCont : MonoBehaviour
{
    public GameObject player;
    public PlayerCont playerCont;
    string veloQuadRe;
     public Material material;
    float speedX;
    float speedY;
    float offsetX;
    float offsetY;
    float xNew;
    float offsetSpeed;
    float yNew;
    // Start is called before the first frame update
    void Start()
    {
        offsetSpeed = 20f;
        material.mainTextureOffset = new Vector2(0, 0);
        //speedY = 0.11f;
        //speedX = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        xNew = Mathf.Lerp(transform.position.x, player.transform.position.x , offsetSpeed * Time.deltaTime);
        yNew = Mathf.Lerp(transform.position.y, player.transform.position.y, offsetSpeed * Time.deltaTime);
        transform.position = new Vector3(xNew, yNew, 1);


        //if (playerCont.VeloForQuad() == "Right")
        //{

        //    material.mainTextureOffset = new Vector2(material.mainTextureOffset.x + speedX * Time.deltaTime, material.mainTextureOffset.y);
        //}
        //else if (playerCont.VeloForQuad() == "Left")
        //{

        //    material.mainTextureOffset = new Vector2(material.mainTextureOffset.x - speedX * Time.deltaTime, material.mainTextureOffset.y);
        //}

    }
}
