using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    private bool moving = false;
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity = new Vector2(0f,speed);
            moving = true;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.velocity = new Vector2(0f, -speed);
            moving = true;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(speed, 0f);
            moving = true;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-speed, 0f);
            moving = true;
        }
    }
}
