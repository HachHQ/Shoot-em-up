using System;
using TreeEditor;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;

    public Animator animator;
    public float speedOfBullet = 15.0f;
    public float speedOfShip = 1000.0f;
    public float forceOfBullet = 100f;
	public float delayStart = 0;
    public float delayFin = 10f;

	private Rigidbody2D _bodyShipRB;

    
    private float horizontalBounds = 8.16f;
    private float verticalBounds = 4.36f;
    private float _deltaX;
    private float _deltaY;
    private int _health = 5;

    public int Health
    {
       get 
       { 
            return _health; 
       }
        set
        {
            _health = value;

            if (_health <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "BulletEnemy(Clone)")
        {
            Health -= 1;
            Destroy(collision.gameObject);
        }
    }

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



        if (_bodyShipRB.position.x >= horizontalBounds)
        {
            _bodyShipRB.position = new Vector2(horizontalBounds, _bodyShipRB.position.y);
        }
		if (_bodyShipRB.position.x <= -horizontalBounds)
		{
			_bodyShipRB.position = new Vector2(-horizontalBounds, _bodyShipRB.position.y);
		}
		if (_bodyShipRB.position.y >= verticalBounds)
		{
			_bodyShipRB.position = new Vector2(_bodyShipRB.position.x, verticalBounds);
		}
		if (_bodyShipRB.position.y <= -verticalBounds)
		{
			_bodyShipRB.position = new Vector2(_bodyShipRB.position.x, -verticalBounds);
		}
	}

    private void Update()
    {
		if (Input.GetMouseButton(0) && delayStart > delayFin)
        {
			Shoot();
		}
        delayStart +=  1;
    }

    void Shoot()
    {
        float angle = -10f;

        int countOfProjectiles = 3;

        for (int i = 0; i < countOfProjectiles; i++)
        {
		    GameObject newBullet = Instantiate(_bulletPrefab, transform.position + new Vector3(0f, 1f, 0), Quaternion.identity);
			Rigidbody2D newBulletRB = newBullet.GetComponent<Rigidbody2D>();
			newBulletRB.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
			Vector3 dir = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.up;
			newBulletRB.AddForce(dir * 300f);
			angle += 10f;
		}
    }   
}
