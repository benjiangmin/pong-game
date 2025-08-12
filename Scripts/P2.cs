using UnityEngine;
using UnityEngine.InputSystem;

public class P2 : MonoBehaviour
{
    public float playerSpeed = 5f;
    [SerializeField] private float upperBounds;
    [SerializeField] private float lowerBounds;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleBoundries();
    }

    private void HandleMovement()
    {
        if (Keyboard.current.upArrowKey.isPressed)
        {
            transform.Translate(Vector3.up * playerSpeed * Time.deltaTime);
        }
        else if (Keyboard.current.downArrowKey.isPressed)
        {
            transform.Translate(Vector3.down * playerSpeed * Time.deltaTime);
        }
    }

    private void HandleBoundries()
    {
        if (transform.position.y > upperBounds)
        {
            Vector3 newPos = new Vector3(transform.position.x, upperBounds, 0f);
            transform.position = newPos;
        }
        else if (transform.position.y < lowerBounds)
        {
            Vector3 newPos = new Vector3(transform.position.x, lowerBounds, 0f);
            transform.position = newPos;
        }
    }
}
