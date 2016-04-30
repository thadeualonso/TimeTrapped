using UnityEngine;
using System.Collections;

public class Explosao : MonoBehaviour {

    void Start()
    {
        Invoke("Explode", 0.5f);
    }

    void Explode()
    {
        Destroy(gameObject);
    }

}
