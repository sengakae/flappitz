using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{
    public GameObject enemy;
    public float spawnRate = 5;
    private float timer = 0;
    private float heightOffset = 22;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate) {
            timer += Time.deltaTime;
        } else {
            spawnEnemy();
            timer = 0;
        }
    }

    void spawnEnemy() {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        Instantiate(enemy, new Vector2(transform.position.x, Random.Range(lowestPoint, highestPoint)), transform.rotation);
    }
}
