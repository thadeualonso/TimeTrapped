using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public float timer;
    public Text txtTimer;
    public Text txtCoolDownMissel;
    public Image screenFader;

    public Image setaDireitaP1;
    public Image setaDireitaP2;
    public Image setaEsquerdaP1;
    public Image setaEsquerdaP2;
    public GameObject spawnP1;
    public GameObject spawnP2;
    public GameObject charP1;
    public GameObject charP2;

    public bool gameStart = false;

    public bool gameOver = false;

	// Update is called once per frame
	void Update ()
    {
        SelecaoDePersonagens();

        if (gameOver)
        {
            ChamaGameOver();
        }

        if (gameStart)
        {
            if (timer >= 0)
            {
                timer -= Time.deltaTime;
            }

            if (timer <= 0)
            {
                if (FindObjectOfType<PlayerLukaz>() != null)
                {
                    FindObjectOfType<PlayerLukaz>().hp = 0;
                }
            }
        }
	}

    public void CarregaFase(string fase)
    {
        SceneManager.LoadScene(fase);
    }

    public void ChamaGameOver()
    {
        StartCoroutine(ScreenFade());
        Invoke("CarregaGameOver", 3f);
        
    }

    void CarregaGameOver()
    {
        SceneManager.LoadScene("TelaGameOver");
    }

    IEnumerator ScreenFade()
    {
        while (true)
        {
            Debug.Log("Aplicando alfa");

            Color color = screenFader.color;
            color.a += 0.01f;
            screenFader.color = color;

            yield return new WaitForSeconds(0.01f);
        }

    }

    void ChecaTempo()
    {
        if (timer <= 0f)
        {
            gameOver = true;
        }
    }

    void ChecaInimigos()
    {
        if (FindObjectOfType<EnemyManager>().inimigosCont <= 0)
        {
            gameOver = true;
        }
    }

    void SelecaoDePersonagens()
    {
        if (gameStart == false)
        {
            if (Input.GetButtonDown("A"))
            {
                Instantiate(charP1, spawnP1.transform.position, Quaternion.identity);
                setaDireitaP1.GetComponent<Animator>().SetBool("selecao", false);
                setaEsquerdaP1.GetComponent<Animator>().SetBool("selecao", false);

                gameStart = true;
            }
        }

    }
}
