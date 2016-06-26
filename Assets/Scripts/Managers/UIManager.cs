using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : Singleton<UIManager>
{
    //public Text[] textos;

    public GameObject setaDireitaP1;
    public GameObject setaEsquerdaP1;
    //public Image setaDireitaP2;
    //public Image setaEsquerdaP2;
    public Image screenFader;
    public Text qntTimer;
    public Text qntEquipeP1;
    public Text qntSalvosP1;
    public Text qntInimigos;

    private GameManager gameManager;
    private InputManager inputManager;
    private EnemyManager enemyManager;

    void Awake()
    {
        base.Awake();

        BuscaElementosGUI();

        inputManager = GameObject.FindObjectOfType<InputManager>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
        enemyManager = GameObject.FindObjectOfType<EnemyManager>();
    }

    void Update()
    {
        AtualizaGUI();

        //textos[0].text = FindObjectOfType<GameManager>().timer.ToString("0");
        //textos[1].text = FindObjectOfType<EnemyManager>().inimigosCont.ToString();
    }

    public void AtualizaGUI()
    {
        if (gameManager.gameStart)
        {
            setaDireitaP1.GetComponent<Animator>().SetBool("selecao", false);
            setaEsquerdaP1.GetComponent<Animator>().SetBool("selecao", false);
        }

        qntEquipeP1.text = GameManager.equipeP1.ToString();
        qntTimer.text = gameManager.timer.ToString("0");
        qntInimigos.text = enemyManager.inimigosCont.ToString();

    }

    void OnLevelWasLoaded(int level)
    {
        BuscaElementosGUI();
    }

    void BuscaElementosGUI()
    {
        if (SceneManager.GetActiveScene().name != "TelaGameOver")
        {
            // Busca e atribui os elementos GUI na fase carregada
            screenFader = GameObject.Find("ScreenFader").GetComponent<Image>();
            qntEquipeP1 = GameObject.Find("qntEquipeP1").GetComponent<Text>();
            qntSalvosP1 = GameObject.Find("qntSalvosP1").GetComponent<Text>();
            setaDireitaP1 = GameObject.Find("SetaDireitaP1");
            setaEsquerdaP1 = GameObject.Find("SetaEsquerdaP1");
            qntEquipeP1 = GameObject.Find("qntEquipeP1").GetComponent<Text>();
            qntTimer = GameObject.Find("qntTempo").GetComponent<Text>();
            qntInimigos = GameObject.Find("qntInimigos").GetComponent<Text>();
        }

    }

    public IEnumerator ScreenFade()
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

}
