using UnityEngine;
using System.Collections;

public class GoroRock : MonoBehaviour {

    public float velocidade;

    private Rigidbody2D rgbd2D;

    void Awake()
    {
        rgbd2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rgbd2D.velocity = transform.up * velocidade;
    }

    void OnTriggerEnter2D (Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            collider.SendMessageUpwards("AplicarDano", 2);
            Destroy(gameObject);
        }
    }

}
