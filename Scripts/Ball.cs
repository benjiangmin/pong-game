using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float ballSpeed = 5f;
    //Let true = left, and let the game start with the left player recieving.

    private bool startDirection = true;
    private Rigidbody2D rb;
    private AudioSource audioSource;
    [SerializeField] AudioClip vineBoom;
    [SerializeField] AudioClip dyingSound;
    [SerializeField] private ScoreManager scoreManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(ResetBall());
    }

    void FixedUpdate()
    {
        //Ensure the ball moves at a constant speed.
        rb.linearVelocity = rb.linearVelocity.normalized * ballSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //VINE BOOOMMMM
        audioSource.PlayOneShot(vineBoom);

        //Randomize y velocity on collisions.
        float yVelocity = Random.Range(-3f, 3f);
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, yVelocity);

        //Increase speed with each collision.
        ballSpeed += 0.5f;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //WAAHHHH
        audioSource.PlayOneShot(dyingSound);

        if (collision.gameObject.CompareTag("Left"))
        {
            scoreManager.AddScore(2);
            startDirection = true;
        }
        else if (collision.gameObject.CompareTag("Right"))
        {
            scoreManager.AddScore(1);
            startDirection = false;
        }

        StartCoroutine(ResetBall());
    }

    private IEnumerator ResetBall()
    {
        rb.linearVelocity = Vector2.zero;
        transform.position = Vector3.zero;
        ballSpeed = 5f;

        yield return new WaitForSeconds(2);
        if (startDirection)
        {
            rb.AddForce(Vector2.left);
        }
        else
        {
            rb.AddForce(Vector2.right);
        }

    }
}
