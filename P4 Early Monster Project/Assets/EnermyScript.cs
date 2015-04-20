using UnityEngine;
using System.Collections;

public class EnermyScript : MonoBehaviour {
	// Use this for initialization
	void Start () {

	}
	public float attack_dist; 
	public float detect_dist; 
	public float rotate_speed = 5;
	public float move_speed = 3;
	public float last_attack = 0;
	public Transform test;
	public GameObject enermy_attack= null;
	public float fire_rate = 6;
	// Update is called once per frame
	void Update () {
		GameObject main_char = GameObject.FindGameObjectWithTag("Player");
		test = main_char.transform;
		float dist_to_player = Vector3.Distance(test.position,transform.position);
		//print (dist_to_player);
		if (dist_to_player < detect_dist) {

			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(test.position - transform.position),rotate_speed*Time.deltaTime );
			if (dist_to_player > attack_dist){
				transform.position += transform.forward * move_speed * Time.deltaTime;
			}
			if (dist_to_player < attack_dist && Time.timeSinceLevelLoad - last_attack > fire_rate)  {
				last_attack = Time.timeSinceLevelLoad;
				//enermy_attack = Instantiate(Resources.Load("Monster_Shot"),transform.position,Quaternion.identity) as GameObject;
				//Instantiate(Sphere,transform.position,Quaternion.identity);
				//print (last_attack);
			}
		}
	}
}

