using UnityEngine;
using System.Collections;

public class Explosao : MonoBehaviour {

    public float delay;

    void Start()
    {
        Invoke("Explode", delay);
    }

    void Explode()
    {
        Destroy(gameObject);
    }

}
