using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float maxForce = 9.2f;
    [SerializeField] private float maxSpeed = 2.8f;
    [SerializeField] private float mass = 3f;
    [SerializeField] private Vector2 velocity;
    [SerializeField] private Vector2 acceleration;

    Rigidbody2D rb;

    //f = a * m

    //a = f / m

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.position = transform.position;
    }
    private void Update()
    {
        ApplyForce(Move(rb.position, rb.velocity));
    }

    void FixedUpdate()
    {
        acceleration = Vector2.ClampMagnitude(acceleration, maxForce);
        acceleration /= mass;

        rb.velocity = Vector2.ClampMagnitude(rb.velocity + acceleration, maxSpeed);
        rb.position += rb.velocity * Time.fixedDeltaTime;


        transform.position = rb.position;
    }

    public void ApplyForce(Vector2 force)
    {
        acceleration += force;
    }

    private Vector2 positionTarget;
    private float max_desired_velocity = 5;

    Vector2 Move(Vector2 position, Vector2 velocity)
    {
        Vector2 requestedDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (requestedDirection != Vector2.zero)
            positionTarget = position + requestedDirection.normalized * max_desired_velocity;
        else
            positionTarget = position;

        Vector2 desiredVelocity = (positionTarget - position).normalized * max_desired_velocity;
        return desiredVelocity - velocity;
    }

}
