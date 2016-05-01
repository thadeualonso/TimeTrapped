using UnityEngine;
using System.Collections;

public class GoroRock : MonoBehaviour {

    public float velocidade;
    public GameObject explosao;

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
            Instantiate(explosao, collider.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}
