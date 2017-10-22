using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 projVelocity;
    private Vector3 bulletPosition;
    public GameObject projectile;
    private Player playerScript;
    private Vector3 position;
    private Vector3 direction;
    private Vector3 velocity;
    private Vector3 force; 
    private Vector3 screenPos;
    private Vector3 camBottomLeft;
    private Vector3 camTopRight;
    private Camera gameCamera;
    // Use this for initialization
    void Start()
    {

        playerScript = GameObject.Find("Player Ship").GetComponent<Player>();
        projVelocity = playerScript.bulletStartingVelocity;
        position = playerScript.bulletStartingPosision;
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

    // Update is called once per fixed delta time
    //moves projectile
    void FixedUpdate()
    {
        position = position + projVelocity;
        transform.position = position;
    }

}
