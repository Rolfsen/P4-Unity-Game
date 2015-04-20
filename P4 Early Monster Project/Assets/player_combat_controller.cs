using UnityEngine;
using System.Collections;

public class player_combat_controller : MonoBehaviour {
	public int hp;
	// Use this for initialization
	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.tag == "enemyattack") {
			Destroy(col.gameObject);
			hp -= 30;
			print (hp);
		}
		
	}
	void Start()
	{
		hp = 100;

	}

	void Update()
	{
		if (hp <= 0) {
			DestroyObject(gameObject);
			print ("game over");
		}
	}
}
