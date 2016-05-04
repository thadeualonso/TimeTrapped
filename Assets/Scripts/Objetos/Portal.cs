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
                Application.Quit();
            }

        }
    }

}
