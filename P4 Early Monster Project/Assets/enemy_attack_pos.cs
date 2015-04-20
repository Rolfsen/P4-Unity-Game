using UnityEngine;
using System.Collections;

public class enemy_attack_pos : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	public float dist_to_player;
	public float attack_dist = 30;
	public float last_attack;
	public Transform test;
	public GameObject enermy_attack= null;
	public float fire_rate = 3;
	// Update is called once per frame
	void Update () {
		GameObject main_char = GameObject.FindGameObjectWithTag("Player");
		test = main_char.transform;
		float dist_to_player = Vector3.Distance(test.position,transform.position);
		if (dist_to_player < attack_dist && Time.timeSinceLevelLoad - last_attack > fire_rate)  {
			last_attack = Time.timeSinceLevelLoad;
			enermy_attack = Instantiate(Resources.Load("Monster_Shot"),transform.position,Quaternion.identity) as GameObject;
			//Instantiate(Sphere,transform.position,Quaternion.identity);
			//print (last_attack);
		}
	
	}
}
