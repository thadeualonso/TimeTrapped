using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public float timer;
    public Text txtTimer;
    public Text enemyCount;
    public Text txtCoolDownMissel;
    public GameObject[] inimigosArray;

	// Use this for initialization
	void Start ()
    {
        timer = 200f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer -= Mathf.RoundToInt(Time.deltaTime);
        txtTimer.text = timer.ToString();

        float coolDownMissel = Mathf.Round(FindObjectOfType<PlayerLukaz>().coolDownMissel);

        if (coolDownMissel != 0)
        {
            txtCoolDownMissel.enabled = true;
            txtCoolDownMissel.text = coolDownMissel.ToString();
        }

        txtCoolDownMissel.enabled = false;
	}
}
