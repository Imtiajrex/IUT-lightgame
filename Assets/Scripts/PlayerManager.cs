using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public bool darkness = false;
    public float darknessMeter = 100f;

    public bool alive = true;
    [SerializeField]
    private PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (!darkness)
                {
                    darkness = true;
                    StartCoroutine("DarknessTimer");
                }
                else
                {
                    darkness = false;
                }
            }
            if (darkness)
            {
                darknessMeter -= 0.1f;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Die")
        {
            alive = false;
            playerMovement.enabled = false;
        }
    }
    IEnumerator DarknessTimer()
    {
        yield return new WaitForSecondsRealtime(1); //Wait 1 second
        darkness = false;
    }
}
