using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateAsteroids : MonoBehaviour
{
    public GameObject Astroid1;
    public GameObject Astroid2;
    public GameObject Astroid3;
    private int i = 1;
    public float spawnerTime;
    private float nextSpawn;
    public Vector3 posision;
    private Camera gameCamera;
    private Vector3 camBottomLeft;
    private Vector3 camTopRight;
    public List<GameObject> astroidList = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        gameCamera = Camera.main;
        gameCamera.enabled = true;
        camBottomLeft = new Vector3(0, 0, 0);
        camTopRight = new Vector3(gameCamera.pixelWidth, gameCamera.pixelHeight, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnerTime;
            if (i == 1)
            {
                GameObject temp1 = Instantiate(Astroid1, new Vector3(Random.Range(camBottomLeft.x, camTopRight.x), 0, 0), Quaternion.Euler(0f, 0f, Random.Range(0f, 360f)));
                posision = temp1.transform.position;
                astroidList.Add(temp1);
                i++;
            }
            else if (i == 2)
            {
                GameObject temp2 = Instantiate(Astroid2, new Vector3(Random.Range(camBottomLeft.x, camTopRight.x), 0, 0), Quaternion.Euler(0f, 0f, Random.Range(0f, 360f)));
                posision = temp2.transform.position;
                astroidList.Add(temp2);
                i++;
            }
            else if (i == 3)
            {
                GameObject temp3 = Instantiate(Astroid2, new Vector3(Random.Range(camBottomLeft.x, camTopRight.x), 0, 0), Quaternion.Euler(0f, 0f, Random.Range(0f, 360f)));
                posision = temp3.transform.position;
                astroidList.Add(temp3);
                i = 1;
            }
        }
    }
}

