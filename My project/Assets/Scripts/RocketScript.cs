using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketScript : MonoBehaviour
{
    public float speed = 10.0f;
    public LogicScript logic;
    public bool isLive = true;
    public Rigidbody2D rb;
    public GameObject bottomBorder;
    public ParticleSystem particleSystem;
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Game2")
        {

            var main = particleSystem.main;
            main.startSpeed = -5f; // Particles move towards the rocket
            main.gravityModifier = 1f; // Particles fall down

            var colorOverLifetime = particleSystem.colorOverLifetime;
            colorOverLifetime.enabled = true;
            Gradient gradient = new Gradient();
            gradient.SetKeys(
                new GradientColorKey[] { new GradientColorKey(Color.red, 0.0f), new GradientColorKey(Color.yellow, 0.5f), new GradientColorKey(Color.blue, 1.0f) },
                new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(1.0f, 1.0f) }
            );
            colorOverLifetime.color = gradient; // Particles change color over their lifetime

            var sizeOverLifetime = particleSystem.sizeOverLifetime;
            sizeOverLifetime.enabled = true;
            AnimationCurve curve = new AnimationCurve();
            curve.AddKey(0.0f, 1.0f);
            curve.AddKey(1.0f, 0.0f);
            sizeOverLifetime.size = new ParticleSystem.MinMaxCurve(1.0f, curve); // Particles change size over their lifetime

            logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
            rb = GetComponent<Rigidbody2D>();
            rb.drag = 1;
        }
    }


    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Game2")
        {
            if (isLive)
            {
                float moveHorizontal = Input.GetAxis("Horizontal");
                float moveVertical = Input.GetAxis("Vertical");

                Vector2 movement = new Vector2(moveHorizontal, moveVertical);

                rb.AddForce(movement * 1);

            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Border"))
        {

            rb.freezeRotation = true;
            return;
        }

        rb.freezeRotation = false;
        bottomBorder.GetComponent<BoxCollider2D>().enabled = false;
        logic.GameOver();
        rb.gravityScale = 1;
        isLive = false;
        Debug.Log("Game Over");

    }
}
