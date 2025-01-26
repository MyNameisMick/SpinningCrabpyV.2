using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    GameObject bulletDecal;

    float speed = 50f;
    float timeToDestroy = 3f;

    public Vector3 target { get; set; }
    public bool hit { get; set; }

    private void OnEnable()
    {
        Destroy(gameObject, timeToDestroy);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        
        if (!hit && Vector3.Distance(transform.position, target) < .01f)
        {
            Destroy(gameObject, 3f);
        }
    }

    //private void OnCollisionEnter(Collision other)
    //{
    //    ContactPoint contact = other.GetContact(0);
    //    //GameObject.Instantiate(bulletDecal, contact.point + contact.normal * .0001f, Quaternion.LookRotation(contact.normal));
    //    Destroy(gameObject);
    //}
}
