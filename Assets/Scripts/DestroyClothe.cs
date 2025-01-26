using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyClothe : MonoBehaviour
{
    Collider col;
    Rigidbody rb;
    bool isHit = false;
    public GameObject particle;
    public NewShakeScript shake;
    public AudioSource sound;

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
        Debug.Log("hit");
        if (!isHit && other.gameObject.CompareTag("Bullet"))
        {
            sound.Play();
            Destroy(other.gameObject);
            isHit = true;
            rb.AddForce(transform.up);
            shake.ShakeScreen(2f, 1f, 0.2f);
        }
        else if (isHit && other.gameObject.CompareTag("Bullet"))
        {
            sound.Play();
            Destroy(other.gameObject);
            Instantiate(particle, transform.position, Quaternion.identity);
            shake.ShakeScreen(3.5f, 1f, 0.2f);
            Destroy(gameObject);
        }
    }
}
