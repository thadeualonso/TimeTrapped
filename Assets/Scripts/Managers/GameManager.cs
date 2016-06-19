using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : Singleton<GameManager> {

    [Header("GUI")]
    public Image setaDireitaP1;
    //public Image setaDireitaP2;
    public Image setaEsquerdaP1;
    //public Image setaEsquerdaP2;
    public Image screenFader;
    public int indiceAvatarP1;
    public Image avatarP1;
    public GameObject[] arrayAvatarP1;
    public Text txtTimer;
    public Text txtCoolDownMissel;
    public Text txtEquipeP1;
    public Text txtSalvosP1;

    [Header("Spawn de personagens")]
    public int indicePJ;
    public GameObject[] arrayPJs;
    public GameObject spawnP1;
    //public GameObject spawnP2;
    public static GameObject charP1;
    //public GameObject charP2;

    [Header("Informação dos jogadores", order = 1)]
    [Header("Player 1", order = 2)]
    public static int equipeP1;
    public static int salvosP1;

    [Header("Regras")]
    public float timer;
    public bool gameStart = false;
    public bool gameOver = false;
    public bool pjsMortos = false;
    public bool stickInUse = false;

    [Header("Componentes do sistema")]
    private InputManager inputManager;

    void Awake()
    {
        base.Awake();

        if (FindObjectOfType<InputManager>() != null)
        {
            inputManager = FindObjectOfType<InputManager>();
        }
        else
        {
            Debug.LogWarning("InputManager não encontrado");
        }

        spawnP1 = GameObject.Find("SpawnP1");

        indicePJ = 0;
        indiceAvatarP1 = 0;
    }

	// Update is called once per frame
	void Update ()
    {
        SelecaoDePersonagens();
        AtualizaGUI();

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
            else
            {
                if (FindObjectOfType<PlayerLukaz>() != null)
                {
                    FindObjectOfType<PlayerLukaz>().hp = 0;
                }
            }
        }
	}

    void OnLevelWasLoaded(int level)
    {
        gameStart = false;
        timer = 240;
        spawnP1 = GameObject.Find("SpawnP1");

        txtEquipeP1 = GameObject.Find("qntEquipeP1").GetComponent<Text>();
        setaDireitaP1 = GameObject.Find("SetaDireitaP1").GetComponent<Image>();
        setaEsquerdaP1 = GameObject.Find("SetaEsquerdaP1").GetComponent<Image>();
    }

    private void AtualizaGUI()
    {
        txtEquipeP1.text = equipeP1.ToString();
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
        if (gameStart == false || pjsMortos == true)
        {
            MoverSelecao();
            ConfirmarSelecao();
        }
    }

    void MoverSelecao()
    {
        // Representa o analogico ou setas no eixo horizontal
        float analogHorizontal = inputManager.horizontal;

        if (analogHorizontal <= -0.1f)
        {
            if (stickInUse == false)
            {
                indicePJ = Selecao(arrayPJs, indicePJ, "left");
                //indiceAvatarP1 = Selecao(arrayAvatarP1, indiceAvatarP1, "left");
                stickInUse = true;
            }
        }

        if (analogHorizontal >= 0.1f)
        {
            if (stickInUse == false)
            {
                indicePJ = Selecao(arrayPJs, indicePJ, "right");
                //indiceAvatarP1 = Selecao(arrayAvatarP1, indiceAvatarP1, "right");
                stickInUse = true;
            }
        }

        if (analogHorizontal != 0f)
        {
            stickInUse = true;
        }
        else
        {
            stickInUse = false;
        }

    }

    void ConfirmarSelecao()
    {
        if (Input.GetButtonDown("A"))
        {

            if(pjsMortos)
            {
                pjsMortos = false;
            }

            GameObject P1 = GameManager.charP1;

            P1 = arrayPJs[indicePJ];

            if (P1 == null)
            {
                if (indicePJ == 1)
                {
                    P1 = arrayPJs[0];
                }
                
                if (indicePJ == 0)
                {
                    P1 = arrayPJs[1];
                }
            }

            Instantiate(P1, spawnP1.transform.position, Quaternion.identity);
            setaDireitaP1.GetComponent<Animator>().SetBool("selecao", false);
            setaEsquerdaP1.GetComponent<Animator>().SetBool("selecao", false);

            gameStart = true;
        }
    }

    private int Selecao(GameObject[] arrayPJs, int indicePJ, string direcao)
    {
        if (direcao == "right")
        {
            if (indicePJ == arrayPJs.Length - 1)
            {
                indicePJ = 0;
            }
            else
            {
                indicePJ++;
            }
        }

        if (direcao == "left")
        {
            if (indicePJ == 0)
            {
                indicePJ = arrayPJs.Length - 1;
            }
            else
            {
                indicePJ--;
            }
        }

        return indicePJ;
    }

    public void RecrutaMembro(GameObject personagem)
    {
        arrayPJs[1] = personagem;
        GameManager.equipeP1++;
    }
}
