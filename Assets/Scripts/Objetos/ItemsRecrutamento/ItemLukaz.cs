using UnityEngine;
using System.Collections;

public class ItemLukaz : MonoBehaviour {

    public GameObject personagem;

    private GameManagerTeste gameManager;

    void Awake()
    {
        gameManager = GameObject.FindObjectOfType<GameManagerTeste>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            gameManager.AdicionaNaEquipe(personagem);
            Destroy(gameObject);
        }
    }
}
