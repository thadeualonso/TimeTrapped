using UnityEngine;
using System.Collections;

public class TiroColisao : MonoBehaviour {

    void Start()
    {
        Invoke("Destruir", 0.1f);
    }

    void Destruir()
    {
        Destroy(gameObject);
    }

}
