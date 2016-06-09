using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour {

    public void AbrirPortal(bool abrindo)
    {
        GetComponent<Animator>().SetBool("abrindo", abrindo);
    }

    void OnTriggerEnter2D (Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            if (SceneManager.GetActiveScene().name == "TelaJogo")
            {
                FindObjectOfType<GameManager>().CarregaFase("TelaJogo_2");
            }

            if (SceneManager.GetActiveScene().name == "TelaJogo_2")
            {
                FindObjectOfType<GameManager>().CarregaFase("TelaJogo_3");
            }

            if (SceneManager.GetActiveScene().name == "TelaJogo_3")
            {
                FindObjectOfType<GameManager>().CarregaFase("TelaJogo_4");
            }

            if (SceneManager.GetActiveScene().name == "TelaJogo_4")
            {
                FindObjectOfType<GameManager>().CarregaFase("TelaJogo_5");
            }

        }
    }

}
