using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallAsteroidDetection : MonoBehaviour
{
    private GameObject collidedAstroid;
    private SpriteBounds spritesBoundsShip;
    private SpriteBounds spritesBoundsAstroids;
    private BigAsteroidDetection astroidScript;
    private Player playerScript;
    private List<GameObject> bulletCollList;
    private List<GameObject> astroidSmallCollList;
    public int totalScore;

    // Use this for initialization
    void Start()
    {

        playerScript = GameObject.Find("Player Ship").GetComponent<Player>();
        bulletCollList = playerScript.bulletList;
        spritesBoundsShip = GameObject.Find("Player Ship").GetComponent<SpriteBounds>();
        astroidScript = GameObject.Find("Scene Manager").GetComponent<BigAsteroidDetection>();
        astroidSmallCollList = astroidScript.smallAstroidList;
        totalScore = astroidScript.totalScore;
    }

    // Update is called once per frame
    void Update()
    {
        Collisions();

    }

    public void Collisions()
    {
        bool loop = true;
        foreach (GameObject smallAstroid in astroidSmallCollList)
        {
            foreach (GameObject bullet in bulletCollList)
            {
                if (bullet == null)
                {
                    continue;
                }
                float x = Mathf.Pow(bullet.GetComponent<SpriteBounds>().CenterSprite().x - smallAstroid.GetComponent<SpriteBounds>().CenterSprite().x, 2f);
                float y = Mathf.Pow(bullet.GetComponent<SpriteBounds>().CenterSprite().y - smallAstroid.GetComponent<SpriteBounds>().CenterSprite().y, 2f);

                float totalDistance = x + y;

                if (totalDistance < bullet.GetComponent<SpriteBounds>().RadiusLength() - 0.1f + smallAstroid.GetComponent<SpriteBounds>().RadiusLength())
                {
                    GetComponent<AudioSource>().Play();
                    loop = false;
                    totalScore = totalScore + 50;
                    astroidSmallCollList.Remove(smallAstroid);
                    Destroy(smallAstroid);
                    bulletCollList.Remove(bullet);
                    Destroy(bullet);
                    break;
                }
            }
            if (loop == false)
            {
                break;
            }
        }
    }
}