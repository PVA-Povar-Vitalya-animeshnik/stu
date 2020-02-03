using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour {

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = new Vector2(0, -4f);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
		if (col.gameObject.tag == "Bound" || col.gameObject.tag == "Player")
        {
            Die();
        }

    }
    void Die()
    {
        Destroy(gameObject);
    }
}
