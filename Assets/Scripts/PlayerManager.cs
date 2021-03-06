using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }

    public bool darkness = false;
    public float darknessMeter = 100f;

    public bool alive = true;
    [SerializeField]
    private PlayerMovement playerMovement;
    [SerializeField]
    private ParticleSystem deathParticles;
    [SerializeField]
    private SpriteRenderer playerSprite;
    [SerializeField]
    private Rigidbody2D playerRigidbody;
    [SerializeField]
    private Light2D globalLight;


    [SerializeField] private float darknessPerSecond = 25f;
    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There is more than one instance!");
            return;
        }

        Instance = this;
    }
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
                    if (darknessMeter > 0f)
                    {
                        darkness = true;
                        globalLight.intensity = 0f;
                        InvokeRepeating("DarknessTimer", 0.1f, 0.1f);
                    }
                }
                else
                {
                    darkness = false;

                    globalLight.intensity = 1f;
                    CancelInvoke("DarknessTimer");
                }
            }
        }
        else
        {
            playerRigidbody.velocity = new Vector2(0f, 0f);
        }
        if (darkness && darknessMeter <= 0f)
        {
            darkness = false;
            globalLight.intensity = 1f;
            CancelInvoke("DarknessTimer");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Die" && !darkness && alive && !GameManager.Instance.gameover && !GameManager.Instance.win)
        {
            AudioManager.instance.Play("Death");
            alive = false;
            playerMovement.enabled = false;
            playerSprite.enabled = false;
            deathParticles.gameObject.SetActive(true);
            GameManager.Instance.GameOver();
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Finish" && alive && !GameManager.Instance.gameover)
        {

            AudioManager.instance.Play("Win");
            GameManager.Instance.playing = false;

            playerMovement.enabled = false;
            playerRigidbody.bodyType = RigidbodyType2D.Static;
            GameManager.Instance.Finish();
        }

    }

    private void DarknessTimer()
    {
        if (darkness)
        {
            darknessMeter -= darknessPerSecond / 10;
        }
    }
}
