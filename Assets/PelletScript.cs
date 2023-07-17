using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelletScript : MonoBehaviour
{
    private Vector2 direction;
    private float moveSpeed = 2;
    private float maxDistance;
    private Collider2D enemyCollider;
    private Rigidbody2D pelletRigidbody;
    public LogicScript logic;
    public void Initialize(Vector2 dir, float distance, Collider2D enemyCol) {
        direction = dir;
        maxDistance = distance;
        enemyCollider = enemyCol;

        pelletRigidbody = GetComponent<Rigidbody2D>();
        pelletRigidbody.velocity = direction.normalized * moveSpeed;
    }

    public float GetPelletSpeed() {
        return moveSpeed;
    }
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Enemy")) {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            logic.addScore(5);
        }
    }
}
