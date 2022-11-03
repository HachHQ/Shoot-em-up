using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    //[SerializeField] private GameObject playerPrefab;
    //[SerializeField] private GameObject bulletEnemyPrefab;
    //private Rigidbody2D bulletEnemyPrefabRb;

    //public float speedOfBullet = 5f;
    
    private int _enemyLives = 3;
    public int enemyLives
    {
        get
        {
            return _enemyLives;
        }
        set
        {
            _enemyLives = value;

            if (_enemyLives <= 0)
            {
                Destroy(this.gameObject);
                Debug.Log("Enemy destroyed");
            }
        }
    }

    /*private void Start()
    {
        //Rigidbody2D playerPrefabRB = playerPrefab.GetComponent<Rigidbody2D>();
        //bulletEnemyPrefabRb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //StartCoroutine(ShotWithDelay());
    }*/

    /*IEnumerator ShotWithDelay()
    {
        yield return new WaitForSeconds(5);
        GameObject bulletPrefab = Instantiate(bulletEnemyPrefab, new Vector3(0f, -0.5f, 0f), Quaternion.identity);
        Rigidbody2D bulletPrefabRB = bulletPrefab.GetComponent<Rigidbody2D>();
        bulletPrefabRB.velocity = new Vector2(playerPrefab.transform.position.x, 0) * speedOfBullet;
    }*/

    private void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.name == "BulletFire(Clone)")
        {
            enemyLives -= 1;
        }
    }
}
