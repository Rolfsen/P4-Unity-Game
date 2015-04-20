using UnityEngine;
using System.Collections;

public class Enemy_attack : MonoBehaviour {
	public Vector3 targetDir;
	public float init_time;
	public bool rot_check;
	public float damage = 10;
	public Transform test;
	public float rotate_speed = 5;
	public float move_speed = 3;
	// Use this for initialization
	void Start () {
		GameObject main_char = GameObject.FindGameObjectWithTag("Player");
		test = main_char.transform;
		Vector3 targetDir = test.position - transform.position;
		init_time = Time.timeSinceLevelLoad;
		rot_check = false;


	
	}

	// Update is called once per frame
	void Update () {
		/*transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(test.position - transform.position),rotate_speed*Time.deltaTime );
		transform.position += Vector3.forward * move_speed * Time.deltaTime;*/
		if (rot_check == false) {
			//Time.timeSinceLevelLoad - init_time < 0.2
			rot_check = true;
			targetDir = test.position - transform.position;
		}
		float step = move_speed * Time.deltaTime;
		Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
		transform.rotation = Quaternion.LookRotation (newDir);
		if (Time.timeSinceLevelLoad - init_time > 1) {
			transform.position += transform.forward * move_speed * Time.deltaTime;
		}

		if (Time.timeSinceLevelLoad - init_time > 10) {
			DestroyObject(gameObject);
		}
	}
	void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.tag == "Player") {
			DestroyObject(gameObject);
		}
		if (collision.gameObject.tag == "terrain") {
			DestroyObject(gameObject);
		}
		}
	}

