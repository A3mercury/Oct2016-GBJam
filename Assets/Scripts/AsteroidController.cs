using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AsteroidController : MonoBehaviour {

	public PlayerController player;

	public float asteroidGravity;
	public float distanceTreshold;
	
	public Sprite[] asteroidSprites = new Sprite[9];

	private float spriteSize = 8f;
	
	// Use this for initialization
	void Start () {
			
		asteroidGravity = .0025f;
		distanceTreshold = 50f;
				
//		SpawnAsteroid(s1);
			
	}
	
	// Update is called once per frame
	void FixedUpdate () {
//		if (Vector2.Distance(player.transform.position, transform.position) < distanceTreshold) {
//			player.AddGravity(transform.position, asteroidGravity);
//		}
	}
	
	public void SpawnAsteroid(List<string> map) {
	
		Debug.Log("map.Count: " + map.Count);
		Debug.Log(map[0]);
	
		for (int i = -(map.Count / 2); i <= map.Count / 2; i++) {
			for (int j = -(map[i+map.Count/2].Length / 2); j <= map[i+map.Count/2].Length / 2; j++) {
				
				//Debug.Log("i: " + i);
				//Debug.Log("j: " + j);			
				
				if (map[i + map.Count / 2][j + map[i + map.Count / 2].Length / 2] == 'x') {
					GameObject go = new GameObject();
					SpriteRenderer ren = go.AddComponent<SpriteRenderer>() as SpriteRenderer;
					go.name = "ast-spr";
					go.transform.position = new Vector2(Mathf.Round(transform.position.x + (j * spriteSize)), Mathf.Round(transform.position.y + (i * spriteSize)));
					go.transform.parent = transform;
					BoxCollider2D bc = go.AddComponent<BoxCollider2D>();
					bc.size = new Vector2(8, 8);
					Rigidbody2D rb = go.AddComponent<Rigidbody2D>();
					rb.gravityScale = 0;
					rb.mass = 100000;
					rb.fixedAngle = true;
					
					// Check if on an edge and choose the correct sprite
					ren.sprite = asteroidSprites[4];
				}
			}
		}			
	}
}