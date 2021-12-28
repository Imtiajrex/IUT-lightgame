using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerMovement : MonoBehaviour
{
    public float speed = 2.0f;
    public float[] horizontalLimit = new float[2];
    public float[] verticalLimit = new float[2];
    public bool horizontal = true;
    private bool opposite = true;


    // Update is called once per frame
    void Update()
    {
        if (!PlayerManager.Instance.darkness)
        {
            if (horizontal)
            {
                if (opposite)
                    transform.Translate(Vector2.right * speed * Time.deltaTime);
                else
                    transform.Translate(-Vector2.right * speed * Time.deltaTime);

                if (transform.position.x >= horizontalLimit[0])
                {
                    //comparing with upper limit
                    opposite = false;
                }

                if (transform.position.x <= horizontalLimit[1])
                {
                    //comparing with lower limit
                    opposite = true;
                }
            }

        }
    }
}
