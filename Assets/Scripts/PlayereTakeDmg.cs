using System.Collections;
using UnityEngine;

public class PlayereTakeDmg : MonoBehaviour
{
    public GameObject Bubble;
    public HeartSystem HeartSystem;
    Collider col;

    private void Start()
    {
        col = GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            HeartSystem.TakeDamage();
            StartCoroutine(Imune());
        }
    }

    IEnumerator Imune()
    {   
        Bubble.SetActive(true);
        col.enabled = false;
        yield return new WaitForSeconds(2f);
        col.enabled = true;
        Bubble.SetActive(false);
    }
}
