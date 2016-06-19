using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager> {

    //public Text[] textos;

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

    void Update()
    {
        //textos[0].text = FindObjectOfType<GameManager>().timer.ToString("0");
        //textos[1].text = FindObjectOfType<EnemyManager>().inimigosCont.ToString();
    }

}
