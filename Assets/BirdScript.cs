using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public float flapStrength = 15;
    public LogicScript logic;
    public bool birdAlive = true;
    public GameObject pellet;
    public float moveSpeed = 20;
    public float maxDistance = 30;
    public GameObject enemyBird;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdAlive) {
            rigidBody.velocity = Vector2.up * flapStrength; 
        }
        if (Input.GetMouseButtonDown(0)) {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            Vector2 direction = targetPosition - transform.position;
            Vector3 spawnPosition = (Vector2)transform.position + direction.normalized * 5; 

            GameObject newPellet = Instantiate(pellet, spawnPosition, transform.rotation);

            Collider2D enemyCollider = enemyBird.GetComponent<Collider2D>();

            PelletScript pelletScript = newPellet.GetComponent<PelletScript>();
            pelletScript.Initialize(direction.normalized, maxDistance, enemyCollider);
            Destroy(newPellet, maxDistance / pelletScript.GetPelletSpeed());
        }
        if (transform.position.y <= -16.6 || transform.position.y >= 16.8) {
            logic.gameOver();
            birdAlive = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        logic.gameOver();
        birdAlive = false;
    }
}
