using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCont : MonoBehaviour
{
    public GameObject player;
    public LineCont lineCont;
    Rigidbody2D playerRB;
    float offsetSpeed;
    float offsetX;
    float xNew;
    float yNew;
    // Start is called before the first frame update
    void Start()
    {
        offsetSpeed = 6f;

        offsetX = 6;
        playerRB = player.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        if (lineCont.GetResult() == "lineF" || Input.GetKey(KeyCode.RightArrow))
        {
            xNew = Mathf.Lerp(transform.position.x, player.transform.position.x + offsetX, offsetSpeed * Time.deltaTime);
        }
        else if (lineCont.GetResult() == "lineB" || Input.GetKey(KeyCode.LeftArrow))
        {
            xNew = Mathf.Lerp(transform.position.x, player.transform.position.x - offsetX, offsetSpeed * Time.deltaTime);
        }
        else
        {
            xNew = Mathf.Lerp(transform.position.x, player.transform.position.x, offsetSpeed * Time.deltaTime);
        }
        yNew = Mathf.Lerp(transform.position.y, player.transform.position.y, offsetSpeed * Time.deltaTime);
        transform.position = new Vector3(xNew, yNew, transform.position.z);

    }
}
