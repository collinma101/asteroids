using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCollision : MonoBehaviour
{
    public GameObject smallastroid;
    private GameObject collidedAstroid;
    private SpriteBounds spritesBoundsAstroids;
    private GenerateAsteroids astroidScript;
    private BigAsteroidDetection astroidBigCollScript;
    private SpriteBounds spritesBoundsShip;
    public List<GameObject> smallAstroidList;
    private List<GameObject> astroidCollList;
    private List<GameObject> astroidSmallCollList;
    public int shipHP;

    // Use this for initialization
    void Start()
    {
        shipHP = 3;
        spritesBoundsShip = GameObject.Find("Player Ship").GetComponent<SpriteBounds>();
        astroidScript = GameObject.Find("Scene Manager").GetComponent<GenerateAsteroids>();
        astroidCollList = astroidScript.astroidList;
        astroidBigCollScript = GameObject.Find("Scene Manager").GetComponent<BigAsteroidDetection>();
        astroidSmallCollList = astroidBigCollScript.smallAstroidList;
    }

    // Update is called once per frame
    void Update()
    {
        astroidCollList = astroidScript.astroidList;
        Collisions();
        CollisionsSmall();

    }

    //detects collsions for big asteroids
    public void Collisions()
    {
        foreach (GameObject astroid in astroidCollList)
        {
            if (astroid == null)
            {
                continue;

            }
            float x = Mathf.Pow(spritesBoundsShip.CenterSprite().x - astroid.GetComponent<SpriteBounds>().CenterSprite().x, 2f);
            float y = Mathf.Pow(spritesBoundsShip.CenterSprite().y - astroid.GetComponent<SpriteBounds>().CenterSprite().y, 2f);

            float totalDistance = x + y;

            if (totalDistance < spritesBoundsShip.RadiusLength() - 0.1f + astroid.GetComponent<SpriteBounds>().RadiusLength())
            {
                shipHP = shipHP - 1;

                astroidCollList.Remove(astroid);
                Destroy(astroid);
                break;
            }
        }
    }
    //detects collision for small asteroids
    public void CollisionsSmall()
    {
        foreach (GameObject astroid in astroidSmallCollList)
        {
            if (astroid == null)
            {
                continue;

            }
            float x = Mathf.Pow(spritesBoundsShip.CenterSprite().x - astroid.GetComponent<SpriteBounds>().CenterSprite().x, 2f);
            float y = Mathf.Pow(spritesBoundsShip.CenterSprite().y - astroid.GetComponent<SpriteBounds>().CenterSprite().y, 2f);

            float totalDistance = x + y;

            if (totalDistance < spritesBoundsShip.RadiusLength() - 0.1f + astroid.GetComponent<SpriteBounds>().RadiusLength())
            {
                shipHP = shipHP - 1;

                astroidCollList.Remove(astroid);
                Destroy(astroid);
                break;
            }
        }

    }
}

