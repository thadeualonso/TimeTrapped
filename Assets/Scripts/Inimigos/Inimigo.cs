 using UnityEngine;
using System.Collections;

public class Inimigo : MonoBehaviour {

    public int hp;
    public float moveX;
    public float moveY;

    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

	    if(hp <= 0) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Tiro")
        {
            Debug.Log("Colidindo com tiro do player");
            hp--;
        }
    }

}
