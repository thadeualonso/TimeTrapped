using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public float timer;
    public Text txtTimer;
    public Text enemyCount;
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
	}
}
