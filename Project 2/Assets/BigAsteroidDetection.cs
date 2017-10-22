using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigAsteroidDetection : MonoBehaviour
{
    public GameObject smallastroid1;
    public GameObject smallastroid2;
    public GameObject smallastroid3;

    //iteration counter
    private int i = 1;
    public List<GameObject> smallAstroidList = new List<GameObject>();
    private SpriteBounds spritesBoundsAstroids;
    private GenerateAsteroids astroidScript;
    private List<GameObject> astroidCollList;
    private GameObject collidedAstroid;

    //gets bullets
    private Player playerScript;
    private List<GameObject> bulletCollList;
    private SpriteBounds spritesBoundsBullets;

    //gets ship collition
    private SpriteBounds spritesBoundsShip;

    //score
    public int totalScore;

    //SpriteBounds shipInfo;
    // Use this for initialization
    void Start()
    {
        totalScore = 0;
        playerScript = GameObject.Find("Player Ship").GetComponent<Player>();
        bulletCollList = playerScript.bulletList;
        spritesBoundsShip = GameObject.Find("Player Ship").GetComponent<SpriteBounds>();
        //spritesBoundsAstroids = GameObject.Find("Scene Manager").GetComponent<SpriteBounds>();
        astroidScript = GameObject.Find("Scene Manager").GetComponent<GenerateAsteroids>();
        astroidCollList = astroidScript.astroidList;
    }
    //this.gameObject
    // Update is called once per frame
    void Update()
    {
        bulletCollList = playerScript.bulletList;
        astroidCollList = astroidScript.astroidList;
        // Debug.Log(bulletCollList.Count);
        Collisions();
    }

    public void Collisions()
    {
        bool loop = true;
        foreach (GameObject astroid in astroidCollList)
        {
            foreach (GameObject bullet in bulletCollList)
            {
                if (bullet == null)
                {
                    continue;
                    //break;
                }
                //find x distance
                float x = Mathf.Pow(bullet.GetComponent<SpriteBounds>().CenterSprite().x - astroid.GetComponent<SpriteBounds>().CenterSprite().x, 2f);
                // Debug.Log("the ship X is ---->" + spritesBoundsShip.CenterSprite().x);
                // Debug.Log("the Astroid X is ---->" + astroid.GetComponent<SpriteBounds>().CenterSprite().x);
                //find y distance
                float y = Mathf.Pow(bullet.GetComponent<SpriteBounds>().CenterSprite().y - astroid.GetComponent<SpriteBounds>().CenterSprite().y, 2f);

                float totalDistance = x + y;

                if (totalDistance < bullet.GetComponent<SpriteBounds>().RadiusLength() - 0.1f + astroid.GetComponent<SpriteBounds>().RadiusLength())
                {
                    GetComponent<AudioSource>().Play();
                    loop = false;
                    totalScore = totalScore + 20;
                    astroidCollList.Remove(astroid);
                    Destroy(astroid);
                    bulletCollList.Remove(astroid);
                    Destroy(bullet);

                    if (i == 1)
                    {
                        GameObject baby1 = Instantiate(smallastroid1, astroid.transform.position + new Vector3(.01f, 0, 1), astroid.transform.rotation);
                        smallAstroidList.Add(baby1);
                        GameObject baby2 = Instantiate(smallastroid2, astroid.transform.position + new Vector3(-.01f, 0, 1), astroid.transform.rotation);
                        smallAstroidList.Add(baby2);
                        i++;
                        break;
                    }
                    else if (i == 2)
                    {
                        GameObject baby1 = Instantiate(smallastroid1, astroid.transform.position + new Vector3(.01f, 0, 1), astroid.transform.rotation);
                        smallAstroidList.Add(baby1);
                        GameObject baby2 = Instantiate(smallastroid3, astroid.transform.position + new Vector3(-.01f, 0, 1), astroid.transform.rotation);
                        smallAstroidList.Add(baby2);
                        i++;
                        break;
                    }
                    else if (i == 3)
                    {
                        GameObject baby1 = Instantiate(smallastroid3, astroid.transform.position + new Vector3(.01f, 0, 1), astroid.transform.rotation);
                        smallAstroidList.Add(baby1);
                        GameObject baby2 = Instantiate(smallastroid2, astroid.transform.position + new Vector3(-.01f, 0, 1), astroid.transform.rotation);
                        smallAstroidList.Add(baby2);
                        i = 1;
                        break;
                    }
                }// Debug.Log(astroidSmallCollList.Count);     
            }
            //Debug.Log("NO Collision");
            //return false;
            if (loop == false)
            {
                break;
            }
        }
    }
}