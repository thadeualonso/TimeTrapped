﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text[] textos;

    void Update()
    {
        textos[0].text = FindObjectOfType<GameManager>().timer.ToString("0");
        textos[1].text = FindObjectOfType<EnemyManager>().inimigosCont.ToString();
    }

}
