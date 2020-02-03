using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
	
	Rigidbody2D rb;
	public float speed;
	public GameObject ship, bullet;
	int delay = 0;
	public int dTimer = 5;
	public int health;
	public int money;
	GameObject f;

    void Awake () {
		rb = GetComponent<Rigidbody2D> ();
		f = transform.Find ("f").gameObject;
        money = PlayerPrefs.GetInt("Money", money);
    }

	void Start () {
        
    }
	
	void Update () {

        Cursor.visible = false;
        Vector2 Cursorp = Input.mousePosition;
		Cursorp = Camera.main.ScreenToWorldPoint (Cursorp);

        if (Cursorp.x > 8.261f)
            Cursorp.x = 8.261f;
        else if (Cursorp.x < -8.261f)
            Cursorp.x = -8.261f;

        if (Cursorp.y > 4.505f)
            Cursorp.y = 4.5051f;
        else if (Cursorp.y < -4.495f)
            Cursorp.y = -4.495f;

        this.transform.position = Cursorp;
        


        if (delay > dTimer)
			Shoot ();
		delay++;
        PlayerPrefs.SetInt("Lives", health);
        PlayerPrefs.SetInt("Money", money);

    }


	void Shoot () {
		delay = 0;
		Instantiate (bullet, f.transform.position, Quaternion.identity);
	}


    public void Damage()
    {
        health--;
        
        if (health == 0) {
            PlayerPrefs.SetInt("Lives", health);
        Destroy(gameObject);
    }
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Enemy") {
			Damage ();
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "coin") {
			CoinPickUp ();
        PlayerPrefs.SetInt("Money", money);
        }

    }

	void CoinPickUp(){
		money++;
		}
}
