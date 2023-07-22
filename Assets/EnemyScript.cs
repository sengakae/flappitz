using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float moveSpeed = 5;
    public float deadZone = -45;
    public float maxDistance = 5;
    public float pelletCooldown = 0.5f;
    public float pelletTime = 0;
    public GameObject pellet;
    public GameObject bird;
    private float initialY;
    // Start is called before the first frame update
    void Start()
    {
        initialY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        float verticalOffset = Mathf.Sin(Time.time * moveSpeed) * moveSpeed;
        transform.position = new Vector2(transform.position.x, initialY + verticalOffset);
        
        pelletTime += Time.deltaTime;
        if (pelletTime >= pelletCooldown) {
            Vector2 randomAngle = Random.insideUnitCircle.normalized;
            Vector2 spawnPosition = (Vector2)transform.position + randomAngle * 5; 
            GameObject newPellet = Instantiate(pellet, spawnPosition, transform.rotation);

            Collider2D playerCollider = bird.GetComponent<Collider2D>();

            PelletScript pelletScript = newPellet.GetComponent<PelletScript>();
            pelletScript.Initialize(randomAngle, maxDistance, playerCollider);

            pelletTime = 0;
        }

        if (transform.position.x < deadZone) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider collision) {
        if (collision.CompareTag("Pellet")) {
            Destroy(gameObject);
        }
    }
}
