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

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("Collision entered: " + collision.gameObject.name);
        Debug.Log("Enemy collider: " + enemyCollider.gameObject.name);
        if (collision == enemyCollider) {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
