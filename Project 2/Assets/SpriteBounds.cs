using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpriteBounds : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public float MinX()
    {
        return this.GetComponent<SpriteRenderer>().bounds.min.x;
    }

    public float MaxX()
    {
        return this.GetComponent<SpriteRenderer>().bounds.max.x;
    }

    public float MinY()
    {
        return this.GetComponent<SpriteRenderer>().bounds.min.y;
    }

    public float MaxY()
    {
        return this.GetComponent<SpriteRenderer>().bounds.max.x;
    }

    public Vector2 SpriteSize()
    {
        return this.GetComponent<SpriteRenderer>().size;
    }

    public Vector3 CenterSprite()
    {
        return this.GetComponent<SpriteRenderer>().bounds.center;
    }

    public float RadiusLength()
    {
        return MaxX() - CenterSprite().x;
    }
}

