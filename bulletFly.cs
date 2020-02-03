using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletFly : MonoBehaviour {

	Rigidbody2D rb;
	public float a = 1f;
	public float speed;

	void Awake () {
		rb = GetComponent<Rigidbody2D> ();
    }

	void Update () {
		rb.velocity = new Vector2 (0, speed * a);
	}

	void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "Enemy" && a>0)
        {
            col.gameObject.GetComponent<Enemy>().Damage();
            Die();
        }
        else if (col.gameObject.tag == "Player" && a < 0)
        {
            col.gameObject.GetComponent<player>().Damage();
            Die();
        }
        else if (col.gameObject.tag == "Bound")
        {
            Die();
        }
    }
	void Die(){
		Destroy (gameObject);
	}

    public void ChangeDir() {
        a *= -1f;
    }
}




