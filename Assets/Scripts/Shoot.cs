using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * 15f;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        Destroy(gameObject);
        if (collision.GetComponent<Health>() != null)
        collision.GetComponent<Health>().TakeDamage(5);

        Destroy(gameObject);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
