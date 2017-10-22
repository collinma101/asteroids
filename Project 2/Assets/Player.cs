using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Vector3 position;
    private Vector3 direction;
    private Vector3 velocity;
    private Vector3 force; 

    public float deltaForce = .001f;
    public float deltaAngle = 1f;
    public float maxSpeed = 1f;
    public float drag = .99f;

    //ship shooting
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;
    public Vector3 bulletStartingVelocity;
    public Vector3 bulletStartingPosision;
    public List<GameObject> bulletList = new List<GameObject>();
    private Vector3 screenPos;
    private Vector3 camBottomLeft;
    private Vector3 camTopRight;
    public Camera gameCamera;


    // Use this for initialization
    void Start()
    {
        position = new Vector3(0, 0, 0);
        direction = new Vector3(0, 1, 0); // start pointing up
        velocity = new Vector3(0, 0, 0);
        velocity = new Vector3(0, 0, 0); velocity = new Vector3(0, 0, 0);
        screenPos = gameCamera.WorldToScreenPoint(position);
        camBottomLeft = new Vector3(0, 0, 0);
        camTopRight = new Vector3(gameCamera.pixelWidth, gameCamera.pixelHeight, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space") && Time.time > nextFire)
        {
            GetComponent<AudioSource>().Play();
            nextFire = Time.time + fireRate;
            GameObject bullet = Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            bulletStartingPosision = shotSpawn.position;
            Vector3 bulletDirection = direction;
            bulletStartingVelocity = bulletDirection * .1f;
            bulletList.Add(bullet);

            Destroy(bullet, 3);
        }

    }


    // Update is called once per fixed delta time
    void FixedUpdate()
    {
        TurnShip(); 
        PushForward(); 
        ScreenWrap();
        UpdatePosition(); 
        transform.position = position; 

    }
    void ScreenWrap()
    {
        screenPos = gameCamera.WorldToScreenPoint(position);

        if (screenPos.y > camTopRight.y)
        {
            position.y = gameCamera.ScreenToWorldPoint(camBottomLeft).y + 0.1f;
        }
        if (screenPos.y < camBottomLeft.y)
        {
            position.y = gameCamera.ScreenToWorldPoint(camTopRight).y - 0.1f;
        }
        if (screenPos.x > camTopRight.x)
        {
            position.x = gameCamera.ScreenToWorldPoint(camBottomLeft).x + 0.1f;
        }
        if (screenPos.x < camBottomLeft.x)
        {
            position.x = gameCamera.ScreenToWorldPoint(camTopRight).x - 0.1f;
        }
    }
    void UpdatePosition()
    {
        velocity = velocity + force;
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        position += velocity;
    }
    void TurnShip()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            direction = Quaternion.Euler(0, 0, deltaAngle * 3f) * direction;
            transform.Rotate(new Vector3(0, 0, deltaAngle * 3f));
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            direction = Quaternion.Euler(0, 0, -deltaAngle * 3f) * direction;
            transform.Rotate(new Vector3(0, 0, -deltaAngle * 3f));
        }
    }
    void PushForward()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            force += direction * deltaForce;
        }
        else
        { 
            {
                force = Vector3.zero;
                velocity *= drag;
            }
        }

    }
}
