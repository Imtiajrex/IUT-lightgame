using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishComponent : MonoBehaviour
{

    [SerializeField]
    private ParticleSystem winParticles;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.win)
            winParticles.gameObject.SetActive(true);
    }
}
