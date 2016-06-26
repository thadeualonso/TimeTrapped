using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : Singleton<GameManager> {

    [Header("Spawn de personagens")]
    // Indice que indica qual personagem esta selecionado
    public int indicePJ;
    // Array contendo os personagens disponiveis para seleção
    public GameObject[] arrayPJs;
    // Localização do spawn dos personagens do player 1
    public GameObject spawnP1;
    // Personagem selecionado pelo jogador
    public static GameObject charP1;
    // Imagem do personagem selecionado
    private Image avatarSelecionado;

    [Header("Informação dos jogadores", order = 1)]
    [Header("Player 1", order = 2)]
    // Quantidade de personagens na equipe do player 1
    public static int equipeP1;
    // Quantidade de personagens salvos do player 1
    public static int salvosP1;
    //public static int equipeP2;
    //public static int salvosP2;

    [Header("Regras")]
    // Tempo da fase
    public float timer;
    // Flag indicando se o jogo iniciou 
    public bool gameStart = false;
    // Flag indicando se o game over foi chamado
    public bool gameOver = false;
    // Flah indicando se todos os personagens da cena estão mortos
    public bool pjsMortos = false;
    // Flag indicando se o teclado ou joystick está sendo utilizado
    public bool stickInUse = false;

    float analogHorizontal;

    [Header("Componentes do sistema")]
    public InputManager inputManager;
    public UIManager uiManager;

    void Awake()
    {
        base.Awake();

        // Atribuição de componentes
        inputManager = FindObjectOfType<InputManager>();
        uiManager = FindObjectOfType<UIManager>();

        // Busca na cena e atribui o gameObject 'Spawn1'
        spawnP1 = GameObject.Find("SpawnP1");

        // Indice do personagem inicia em 0
        indicePJ = 0;

        avatarSelecionado = GameObject.Find("imgJogadorP1").GetComponent<Image>();
    }

    void Start()
    {
        equipeP1 = ChecaEquipe();
    }

	void Update ()
    {
        // Representa o analogico ou setas no eixo horizontal
        analogHorizontal = inputManager.horizontal;

        if(analogHorizontal != 0f)
        {
            SelecaoDePersonagens();
        }
        else
        {
            stickInUse = false;
        }

        if (Input.GetButtonDown("A"))
        {
            ConfirmarSelecao();
        }

        // Se a flag 'gameOver' for true...
        if (gameOver)
        {
            // Chama o método de GameOver
            ChamaGameOver();
        }

        // Se a flag 'gameStart' for true...
        if (gameStart)
        {
            // Se o timer for maior ou igual a zero...
            if (timer >= 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                //ChamaGameOver();

                // Se tiver ao menos 1 personagem em cena...
                if (FindObjectOfType<Personagem>() != null)
                {
                    // Zera o HP do personagem
                    FindObjectOfType<Personagem>().hp = 0;
                }
            }
        }
	}

    int ChecaEquipe()
    {
        int contagem = 0;

        for (int i = 0; i < arrayPJs.Length; i++)
        {
            if(arrayPJs[i] != null)
            {
                contagem++;
            }
        }

        return contagem;
    }

    void ChecaGameOver()
    {
        if (equipeP1 <= 0)
        {
            pjsMortos = true;
            CarregaGameOver();
        }
    }

    void OnLevelWasLoaded(int level)
    {
        gameStart = false;
        timer = 240;
        spawnP1 = GameObject.Find("SpawnP1");
    }

    public void CarregaFase(string fase)
    {
        SceneManager.LoadScene(fase);
    }

    public void ChamaGameOver()
    {
        StartCoroutine(uiManager.ScreenFade());
        Invoke("CarregaGameOver", 3f);
    }

    void CarregaGameOver()
    {
        SceneManager.LoadScene("TelaGameOver");
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
            string direcao = null;

            if(analogHorizontal >= 0.1f)
            {
                direcao = "right";
            }
            
            if(analogHorizontal <= -0.1f)
            {
                direcao = "left";
            }

            MoverSelecao(direcao);
        }
    }

    // Método para selecionar o personagem que será instanciado na cena
    void MoverSelecao(string direcao)
    {
        // Se o controle ou teclado nao estiver sendo usado...
        if (stickInUse == false)
        {
            // Indice do personagem selecionado recebe o retorno do método Selecao()
            // Método Selecao anda no array decrementando o indicePJ
            indicePJ = Selecao(arrayPJs, indicePJ, direcao);

            if(arrayPJs[indicePJ] != null)
            {
                avatarSelecionado.sprite = arrayPJs[indicePJ].GetComponent<Personagem>().avatar;
            }
            else
            {
                return;
            }

            //avatarSelecionado.sprite = arrayPJs[indicePJ].GetComponent<Personagem>().avatar;
            // Flag para indicar o uso do controle
            stickInUse = true;
        }
    }

    // Método para confirmar a seleção feita com o método MoverSeleção()
    void ConfirmarSelecao()
    {
        if (gameStart == false || pjsMortos == true)
        {
            // Se todos os personagens da cena estiverem mortos...
            if (pjsMortos)
            {
                // Flag para indicar que existe pelo menos 1 personagem na cena
                pjsMortos = false;
            }

            // P1 recebe o personagem selecionado presente no script GameManager
            GameObject P1;

            // P1 recebe o personagem ativo
            P1 = arrayPJs[indicePJ];

            //// Se o personagem selecionado não estiver disponivel na equipe...
            //if (P1 == null)
            //{
            //    // Se o indice de personagem for igual a 1
            //    if (indicePJ == 1)
            //    {
            //        P1 = arrayPJs[0];
            //    }

            //    if (indicePJ == 0)
            //    {
            //        P1 = arrayPJs[1];
            //    }
            //}

            Instantiate(P1, spawnP1.transform.position, Quaternion.identity);
            //setaDireitaP1.GetComponent<Animator>().SetBool("selecao", false);
            //setaEsquerdaP1.GetComponent<Animator>().SetBool("selecao", false);

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
