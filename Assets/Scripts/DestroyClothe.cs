using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyClothe : MonoBehaviour
{
    Collider col;
    Rigidbody rb;
    bool isHit = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!isHit && other.gameObject.CompareTag("Bullet"))
        {
            isHit = true;
            rb.AddForce(transform.up);
        }
        else if (isHit && other.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}
