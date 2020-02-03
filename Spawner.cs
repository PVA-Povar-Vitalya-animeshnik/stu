using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public float rate = 5;
	public GameObject[] enemies;
	public int wawes;
	public int clock;

	void Start () {
		InvokeRepeating("Spawn",2,rate);
	}

	void Spawn ()
	{
			for (int i = 0; i < wawes; i++) {
				Instantiate (enemies [(int)Random.Range (0, enemies.Length)], new Vector3 (Random.Range (-8.5f, 8.5f), 6, 0), Quaternion.identity);
			}
		clock++;
		if (clock == 20) {
			clock = 0;
			wawes++;
		}
	}
}
	

