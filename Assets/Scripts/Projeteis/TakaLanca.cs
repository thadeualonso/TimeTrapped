using UnityEngine;
using System.Collections;

public class TakaLanca : MonoBehaviour {

    public float velocidade;
    public GameObject explosao;
    public float dano;
    public NiveisTerrenos nivelTerreno;
    public Direcoes direcao;

    private Rigidbody2D rgbd2D;

    void Awake()
    {
        rgbd2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Invoke("MudaNivelTerreno", 0.6f);
        Invoke("ChamarCurva", 0.6f);
    }

    void Update()
    {
        rgbd2D.velocity = transform.up * velocidade;
    }

    void ChamarCurva()
    {
        StartCoroutine(Curva());
    }

    IEnumerator Curva()
    {
        while (true)
        {
            Debug.Log("Coroutine");

            if (direcao == Direcoes.Left)
            {
                transform.Rotate(0f, 0f, 20f);
            }

            if (direcao == Direcoes.Right)
            {
                transform.Rotate(0f, 0f, -20f);
            }

            yield return new WaitForSeconds(0.8f);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player" && collider.GetComponent<Humanoid>().nivelTerreno == nivelTerreno)
        {
            collider.SendMessageUpwards("AplicarDano", dano);
            Instantiate(explosao, collider.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (collider.gameObject.tag == "Obstaculo" && nivelTerreno == NiveisTerrenos.Chao)
        {
            Debug.Log("Colidiu com algum obstaculo");
            Destroy(gameObject);
        }
    }

    void MudaNivelTerreno()
    {
        nivelTerreno = NiveisTerrenos.Chao;
    }
}
