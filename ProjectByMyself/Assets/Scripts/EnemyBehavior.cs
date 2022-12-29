using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehavior : MonoBehaviour
{
	[SerializeField] private GameObject bulletEnemyPrefab;
    private Rigidbody2D bulletEnemyPrefabRb;
       
	public float fireRate = 1.5f;
    public bool CanShoot;
    public float speedOfBullet = 5f;
    
    private int _enemyLives = 4;
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
				Debug.Log("Enemy destroyed, score update");
			}
        }
    }

    private void Start()
    {
        bulletEnemyPrefabRb = GetComponent<Rigidbody2D>();
        fireRate = fireRate + Random.Range(0, 2f);
		InvokeRepeating("EnemyShoot", fireRate, fireRate);
	}

    public void EnemyShoot()
    {
        if (CanShoot)
        {
            GameObject newBullet = Instantiate(bulletEnemyPrefab, transform.position + new Vector3(0f, -0.5f, 0f), Quaternion.identity);
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

    private void Update()
    {
        
    }
}
