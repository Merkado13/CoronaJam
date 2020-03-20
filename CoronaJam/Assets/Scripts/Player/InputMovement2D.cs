using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMovement2D : MonoBehaviour
{

    [SerializeField] private float maxSpeed;
    [SerializeField] private float speed;
    [SerializeField] private float acc;
    [SerializeField] private float deacc;
    private Vector2 movementVelocity;

    private Vector2 lastMoveDirection = new Vector2(0,0);

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movementVelocity * Time.fixedDeltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Stop()
    {
        movementVelocity = new Vector2(0,0);
    }

    public void Movement()
    {
        Vector2 inputMovement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 moveDirection = inputMovement.normalized;

        if (inputMovement.magnitude != 0)
        {
            speed = ApproachComponent(speed, maxSpeed, acc);
            lastMoveDirection = moveDirection;
        }
        else
        {
            speed = ApproachComponent(speed, 0, deacc);
            moveDirection = lastMoveDirection;
        }
        movementVelocity = moveDirection * speed;
    }

    private float ApproachComponent(float comp, float goal, float step)
    {
        if (comp < goal)
            return Mathf.Min(comp + step, goal);
        else
            return Mathf.Max(comp - step, goal);
    }

}
