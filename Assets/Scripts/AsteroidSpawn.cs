using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AsteroidSpawn : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		for (int i = 0; i < 10; i++) {
			float randomX = Random.Range(-250, 250);
			float randomY = Random.Range(-250, 250);
			float asteroidIndex = Random.Range(1, 3);
		
			GameObject a = Instantiate(Resources.Load("asteroid/prefabs/asteroid-prefab" + asteroidIndex)) as GameObject;
			a.transform.position = new Vector3(randomX, randomY, 0);
		}
	}
}