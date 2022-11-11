using System;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    
    public Animator animator;
    public float speedOfBullet = 15.0f;
    public float speedOfShip = 1000.0f;
    
    private Rigidbody2D _bodyShipRB;
    private float _deltaX;
    private float _deltaY;
    
    private void Start()
    {
        _bodyShipRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        _deltaX = Input.GetAxis("Horizontal");
        _deltaY = Input.GetAxis("Vertical");

        _bodyShipRB.velocity = (Vector2.right * _deltaX * speedOfShip * Time.fixedDeltaTime) + (Vector2.up * _deltaY * speedOfShip * Time.fixedDeltaTime); 
        
        animator.SetFloat("Speed", Mathf.Abs(_deltaX) + Mathf.Abs(_deltaY));
    }

    private void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject newBullet = Instantiate(_bulletPrefab, transform.position + new Vector3(0f, 1f,0), Quaternion.identity);
            Rigidbody2D newBulletRB = newBullet.GetComponent<Rigidbody2D>();
            newBulletRB.velocity = Vector2.up * speedOfBullet;
        }
    }
}
