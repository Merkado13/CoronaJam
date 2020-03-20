using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Vector3 initPos;
    private Vector3 direction;
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float maxDistance;

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
        float distanceTravelled = Vector3.Distance(transform.position, initPos);
        if (distanceTravelled < maxDistance)
        {
            
            //transform.Translate(direction);
            rb.MovePosition(rb.position + new Vector2(direction.x, direction.y) * speed * Time.fixedDeltaTime);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init(Vector2 initPos, Vector2 direction)
    {
        this.initPos = initPos;
        this.direction = direction;
        Debug.Log("Bullet: " + direction);
    }

    //poner la animación 
    private void OnDestroy()
    {
        
    }
}
