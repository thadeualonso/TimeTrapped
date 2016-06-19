using UnityEngine;
using System.Collections;

public class TesteManager : Singleton<TesteManager> {

    void Awake()
    {
        base.Awake();

        Debug.Log("Teste Manager");
    }

}
