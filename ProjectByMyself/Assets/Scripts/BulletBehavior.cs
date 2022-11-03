using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    private float timeToDestroy = 1f;
    void Start()
    {
        Destroy(this.gameObject, timeToDestroy);
    }

    private void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.name == "SpaceShipEnemy(Clone)")
        {
            Destroy(this.gameObject);
        }
    }
}
