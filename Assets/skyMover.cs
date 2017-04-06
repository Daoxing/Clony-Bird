using UnityEngine;
using System.Collections;

public class skyMover : MonoBehaviour {
	Rigidbody2D player;
	// Use this for initialization
	void Start () {
		GameObject player_go = GameObject.FindGameObjectWithTag ("Player");
		if(player_go==null){
			Debug.LogError("Could not find the object with tag Player!!!");
			return;
		}
		player = player_go.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float vel = player.velocity.x * 0.9f;
		transform.position = transform.position+Vector3.right*vel*Time.deltaTime;
	}
}
