using UnityEngine;
using System.Collections;
using System;

public class SimpleObstacle : MonoBehaviour, IOnTouchEvent
{
    //public Vector2 vector;
    [SerializeField]
    private float speed;

    public Manual Manual
    {
        get
        {
            throw new NotImplementedException();
        }
    }

    public float Speed
    {
        get
        {
            return speed;
        }

        set
        {
            speed = value;
        }
    }

    void Start()
    {

    }

    void Update()
    {
        //transform.Translate(new Vector3(vector.x, vector.y, transform.position.z) * Time.deltaTime * speed);
    }

    public void OnTouch()
    {
        throw new NotImplementedException();
    }

    /*void OnCollisionEnter2D(Collision2D collision)
    {
        var temp = collision.collider.gameObject.GetComponent<Wall>();
        if (temp != null)
        {
            vector.x = vector.x * (-1);
            vector.y = vector.y * (-1);
        }
    }*/
}
