using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;

    private Vector2 direction;
    Rigidbody2D rb;

    [SerializeField] private float maxForce;
    [SerializeField] private Vector2 velocity;
    [SerializeField] private float maxSpeed;
    [SerializeField] private Vector2 acceleration;
    [SerializeField] private float mass;


    //f = a * m

    //a = f / m

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.position = transform.position;
    }
    private void Update()
    {
        direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    void FixedUpdate()
    {
        ApplyForce(direction);

        acceleration = Vector2.ClampMagnitude(acceleration, maxForce);
        acceleration /= mass;

        velocity = Vector2.ClampMagnitude(velocity + acceleration, maxSpeed);
        rb.position += velocity * Time.fixedDeltaTime;


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
        Vector2 requestedDirection = new Vector2(Input.GetAxis("Horizontal"), 0);

        if (requestedDirection != Vector2.zero)
            positionTarget = position + requestedDirection.normalized * max_desired_velocity;
        else
            positionTarget = position;

        Vector2 desiredVelocity = (positionTarget - position).normalized * max_desired_velocity;
        return desiredVelocity - velocity;
    }

}
