using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingDanger : MonoBehaviour
{
    public Transform player;
    public float speed = 5f;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerManager.Instance.darkness)
        {
            //Find direction
            Vector3 dir = (player.transform.position - rb.transform.position).normalized;
            //Check if we need to follow object then do so 
            if (Vector3.Distance(player.transform.position, rb.transform.position) > 0.1f)
            {
                rb.MovePosition(rb.transform.position + dir * speed * Time.fixedDeltaTime);
            }
        }
    }
}
