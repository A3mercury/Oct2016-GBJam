using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AsteroidController : MonoBehaviour {

	public PlayerController player;

	public float asteroidGravity;
	public float distanceTreshold;

	private Vector2 asteroidSize;
	
	public Sprite[] asteroidSprites = new Sprite[9];

	private float spriteSize = 8f;
	
	
	// Use this for initialization
	void Start () {
	
		asteroidSize = new Vector2(3, 3);
		
		asteroidGravity = .0025f;
		distanceTreshold = 10f;
		
		SpawnAsteroid();
			
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Vector2.Distance(player.transform.position, transform.position) < distanceTreshold) {
			player.AddGravity(transform.position, asteroidGravity);
		}
	}
	
	void SpawnAsteroid() {

		for (var i = -1; i <= 1; i++) {
			for (var j = -1; j <= 1; j++) {
				// get midpoint of asteroid size vector
				int midX = Mathf.RoundToInt(asteroidSize.x / 2);
				int midY = Mathf.RoundToInt(asteroidSize.y / 2);
				
				GameObject go = new GameObject();
				SpriteRenderer ren = go.AddComponent<SpriteRenderer>() as SpriteRenderer;
				ren.sprite = asteroidSprites[4];
				go.name = "ast-spr";
				go.transform.position = new Vector2(transform.position.x + (i * spriteSize), transform.position.y + (j * spriteSize));
				go.transform.parent = transform;
				go.AddComponent<BoxCollider2D>();
				Rigidbody2D rb = go.AddComponent<Rigidbody2D>();
				rb.gravityScale = 0;
				rb.mass = 10000;
				rb.fixedAngle = true;
			}
		}
						
	}
}
