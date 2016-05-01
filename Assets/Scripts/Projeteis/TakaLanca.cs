using UnityEngine;
using System.Collections;

public class TakaLanca : MonoBehaviour {

    public float velocidade;
    public GameObject explosao;
    public float dano;

    private Rigidbody2D rgbd2D;

    void Awake()
    {
        rgbd2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rgbd2D.velocity = transform.right * velocidade;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            collider.SendMessageUpwards("AplicarDano", dano);
            Instantiate(explosao, collider.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
