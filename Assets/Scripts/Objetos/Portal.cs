using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {

    void OnTriggerEnter2D (Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            FindObjectOfType<GameManager>().CarregaFase("TelaJogo_2");
        }
    }

}
