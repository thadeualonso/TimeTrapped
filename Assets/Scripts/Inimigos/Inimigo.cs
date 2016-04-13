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

	    if(hp <= 0) { Destroy(gameObject); }

        moveX = transform.position.x;
        moveY = transform.position.y;

        if (moveY < 0)
        {
            anim.SetFloat("SpeedY", -1f);
        }
        else if (moveY > 0)
        {
            anim.SetFloat("SpeedY", 1f);
        }

    }


    void OnTriggerEnter2D (Collider2D collider)
    {
        if(collider.gameObject.tag == "Tiro")
        {
            hp--;
        }
    }

}
