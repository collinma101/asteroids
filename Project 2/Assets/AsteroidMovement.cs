using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    //Vectors For Moving at a contstant velocity
    private Vector3 position;
    private Vector3 direction;
    private Vector3 velocity;
    public float speed;

    //Wrapping Screen
    private Vector3 screenPos;
    private Vector3 camBottomLeft;
    private Vector3 camTopRight;
    private Camera gameCamera;

    // Use this for initialization
    void Start()
    {
        position = transform.position;
        direction = new Vector3(0, 1, 0); //make this random
        velocity = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0) * speed;

        //Screen Info
        gameCamera = Camera.main;
        gameCamera.enabled = true;
        screenPos = gameCamera.WorldToScreenPoint(position);
        camBottomLeft = new Vector3(0, 0, 0);
        camTopRight = new Vector3(gameCamera.pixelWidth, gameCamera.pixelHeight, 0);

    }
    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        ScreenWrap(); //screen warpping
        position = position + velocity;
        transform.position = position;
    }
    void ScreenWrap()
    {
        //screen pos
        screenPos = gameCamera.WorldToScreenPoint(position);

        //Test top wall
        if (screenPos.y > camTopRight.y)
        {
            position.y = gameCamera.ScreenToWorldPoint(camBottomLeft).y + 0.1f;
        }

        //bottom
        if (screenPos.y < camBottomLeft.y)
        {
            position.y = gameCamera.ScreenToWorldPoint(camTopRight).y - 0.1f;
        }

        //right
        if (screenPos.x > camTopRight.x)
        {
            position.x = gameCamera.ScreenToWorldPoint(camBottomLeft).x + 0.1f;
        }

        //left
        if (screenPos.x < camBottomLeft.x)
        {
            position.x = gameCamera.ScreenToWorldPoint(camTopRight).x - 0.1f;
        }
    }
}
