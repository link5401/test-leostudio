using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallThrow : MonoBehaviour
{
    Rigidbody rb;
    Vector3 lastVelocity;
    [SerializeField] private float ballSpeed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity =rb.velocity;
        if (Input.GetKeyDown("space"))
        {
            Throw();
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall") && transform.parent == null)
        {
            var speed = lastVelocity.magnitude;
            var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
            rb.velocity = direction * Mathf.Max(speed, 0f) ;
            Debug.Log(rb.velocity);
        }
        if(collision.gameObject.CompareTag("Enemy") && transform.parent == null){
            Destroy(collision.gameObject);
        }

    }
    private void Throw()
    {
        Transform player = transform.parent;
        rb.velocity = player.forward * ballSpeed ;
        transform.SetParent(null);
    }
}
