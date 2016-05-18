using UnityEngine;
using System.Collections;

public class ThaddeusSword : MonoBehaviour {

    void Start()
    {
        Invoke("Destruir", 0.5f);
    }

    void Destruir()
    {
        Destroy(gameObject);
    }

}
