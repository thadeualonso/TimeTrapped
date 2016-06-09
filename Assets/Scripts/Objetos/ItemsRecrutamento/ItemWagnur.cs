using UnityEngine;
using System.Collections;

public class ItemWagnur : MonoBehaviour {

    public GameObject personagem;

    public GameManager gm;

    void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            gm.RecrutaMembro(personagem);
            Destroy(gameObject);
        }
    }

}
