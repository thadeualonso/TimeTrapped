using UnityEngine;
using System.Collections;

public class EnemyGun : MonoBehaviour {

    // Prefab do tiro
    public GameObject enemyShot;
    public float fireRate;

    void Start()
    {
        InvokeRepeating("FireEnemyBullet", 0f, fireRate);
    }

    void Update()
    {


    }

    IEnumerator Shoot()
    {
        Debug.Log("Coroutine iniciada");
        FireEnemyBullet();
        yield return new WaitForSeconds(0.5f);
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
