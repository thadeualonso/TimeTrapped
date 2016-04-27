using UnityEngine;
using System.Collections;

public class EnemyGun : MonoBehaviour {

    // Prefab do tiro
    public GameObject enemyShot;
    public float fireRate;

    void Start()
    {
        InvokeRepeating("FireEnemyBullet", 0f, 1f);
    }

    void FireEnemyBullet()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            GameObject bullet = (GameObject)Instantiate(enemyShot);

            bullet.transform.position = transform.position;

            Vector2 direction = player.transform.position - bullet.transform.position;

            bullet.GetComponent<EnemyShot>().SetDirection(direction);
        }
    }

}
