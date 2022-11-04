using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private GameObject bulletEnemyPrefab;
    private Rigidbody2D bulletEnemyPrefabRb;

    public int fireRate = 3;
    public bool CanShoot;
    public float speedOfBullet = 5f;
    
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

    private void Start()
    {
        bulletEnemyPrefabRb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        InvokeRepeating("EnemyShoot", UnityEngine.Random.Range(0, 4f), fireRate);
    }

    public void EnemyShoot()
    {
        if (CanShoot)
        {
            GameObject newBullet = Instantiate(bulletEnemyPrefab, new Vector3(0, -1, 0), Quaternion.identity);
            Rigidbody2D newBulletRB = newBullet.GetComponent<Rigidbody2D>();
            newBulletRB.velocity = Vector3.down * speedOfBullet;
        }
    }

    

    private void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.name == "BulletFire(Clone)")
        {
            enemyLives -= 1;
        }
    }
}
