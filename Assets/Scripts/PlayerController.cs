using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 500f;
    public int health = 5;

    private int score = 0;

    // Update is called once per frame
    void Update() {
        if (health == 0) {
            Debug.Log("Game Over!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey("d")) {
            rb.AddForce(speed * Time.deltaTime, 0, 0);
        }
        
        if (Input.GetKey("a")) {
            rb.AddForce(-speed * Time.deltaTime, 0, 0);
        }
        
        if (Input.GetKey("w")) {
            rb.AddForce(0, 0, speed * Time.deltaTime);
        }
        
        if (Input.GetKey("s")) {
            rb.AddForce(0, 0, -speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Pickup") {
            score++;
            Debug.Log($"Score: {score}");
            Object.Destroy(other.gameObject);
        }

        if (other.tag == "Trap") {
            health--;
            Debug.Log($"Health: {health}");
        }

        if (other.tag == "Goal") {
            Debug.Log("You win!");
        }
    }
}
