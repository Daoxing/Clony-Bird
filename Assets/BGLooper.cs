using UnityEngine;
using System.Collections;

public class BGLooper : MonoBehaviour {
	int numBGPanels=6;
	float minPipeHeight=-0.14f;
	float maxPipeHeight=0.37f;
	// Use this for initialization
	void Start () {
		GameObject[] pipes = GameObject.FindGameObjectsWithTag ("Pipe");
		foreach(GameObject pipe in pipes){
			Vector3 pos=pipe.transform.position;
			pos.y=Random.Range(minPipeHeight,maxPipeHeight);
			pipe.transform.position=pos;
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D c){
		float widthOfBGObject = ((BoxCollider2D)c).size.x-0.02f;
		Vector3 pos = c.transform.position;
		pos.x = pos.x + widthOfBGObject *numBGPanels;
		c.transform.position = pos;
		if(c.tag=="Pipe"){
			pos= c.transform.position;
			pos.y=Random.Range(minPipeHeight,maxPipeHeight);
			c.transform.position=pos;
		}
	}
}
