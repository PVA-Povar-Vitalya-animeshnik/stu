using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public GameObject bullet;
	public float speed = 2;
	public bool canShoot;
    Rigidbody2D rb;
	public GameObject coin;
    public float firerate;
    public float healh;

    void Awake () {
		rb = GetComponent<Rigidbody2D> ();
    }

	void Start () {
        if (canShoot == true) {
            InvokeRepeating("Shoot", Random.Range(-0.25f, 0.25f)*firerate+ firerate, Random.Range(-0.25f, 0.25f) * firerate + firerate);
        }
	}
		
	void Update () {
		rb.velocity = new Vector2 (0, - speed);
    }

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Player") {
			Die ();
		}
		if (col.gameObject.tag == "Bound") {
            this.transform.position = new Vector3(this.transform.position.x, 6, 0);
		}
	}

    public void Damage()
    {
        healh--;
        if (healh == 0)
            Die();
    }

    public void Die(){
		Instantiate (coin, this.transform.position, Quaternion.identity);
		Destroy (gameObject);
	}

    void Shoot() {
        GameObject temp = (GameObject)Instantiate(bullet, transform.position+new Vector3(0, -0.8f,0), Quaternion.identity);
        temp.GetComponent<bulletFly>().ChangeDir();
    }


}

