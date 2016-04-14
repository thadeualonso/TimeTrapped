using UnityEngine;
using System.Collections;

public class EnemyShot : MonoBehaviour {

    // Velocidade que o tiro se move
    public float speed;
    // Direção que o tiro irá percorrer
    Vector2 _direction;
    // Flag para indicar se o tiro está pronto
    bool isReady;

    void Awake()
    {
        isReady = false;
    }

    void Update()
    {
        if (isReady)
        {
            // Recebe a posição atual do tiro
            Vector2 position = transform.position;

            // Calcula a nova posição do tiro
            position += _direction * speed * Time.deltaTime;

            // Atualiza a nova posição do tiro
            transform.position = position;
        }
    }

    // Método para definir a direção do tiro
    public void SetDirection(Vector2 direction)
    {
        // Define a direção normalized, para receber uma unidade de vetor
        _direction = direction.normalized;

        // Define o tiro como pronto
        isReady = true;
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.CompareTag("Limite"))
        {
            Destroy(gameObject);
        }
    }

}
