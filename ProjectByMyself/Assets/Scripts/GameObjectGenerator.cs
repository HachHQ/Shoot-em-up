using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectGenerator : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float speedOfTranslate = 1f;
    private Transform GameObjGenerate;
    private Rigidbody2D enemyPrefabRB;

    public GameObject playerShipPrefab;
    public float lineCount = 3;
    public float columnCount = 4;
    public float offSetX = 1f;
    public float offSetY = 1f;
    
    
    void Awake()
    {
        GameObjGenerate = GetComponent<Transform>();

        Instantiate(playerShipPrefab, new Vector3(0f, -3f, 0f), Quaternion.identity);
        
        enemyPrefabRB = GetComponent<Rigidbody2D>();
        
        Vector3 startPos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        
        for (int i = 0; i < columnCount; i++)
        {
            for (int j = 0; j < lineCount; j++)
            {
                float posX = (offSetX * i) + startPos.x;
                float posY = -(offSetY * j) + startPos.y;
                enemyPrefab.transform.position = new Vector3(posX, posY, startPos.z);
                
                GameObject enemy = Instantiate(enemyPrefab);
                enemy.transform.SetParent(GameObjGenerate);
            }
        }
    
    }
    
    void Update()
    {
        Vector2 pos = transform.position;
        pos.x += speedOfTranslate * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -8.5f)
        {
            speedOfTranslate = Random.Range(speedOfTranslate, 2f);
        }
        else if(pos.x > 2.5f)
        {
            speedOfTranslate = -Random.Range(2f, speedOfTranslate);
		}
    }
}
