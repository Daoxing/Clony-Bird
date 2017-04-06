using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BirdMovement : MonoBehaviour {
	//Vector3 velocity=Vector3.zero;
	public Vector2 jumpForce = new Vector2(0, 300f);
	Rigidbody2D rb;
	bool isDead=false;
	bool isFlapping=false;
	Animator animator;
	int Score=0;
	int HighestScore=0;
	float cooldown=5;
	public GameObject ScoreBoardUIText;
	Text ScoreBoard;
	// Use this for initialization
	void Start () {
		SetScreenSize ();
		rb = GetComponent<Rigidbody2D>();
		if(rb==null){
			Debug.LogError("No Rigidbody2D!!!");
		}
		animator = GetComponentInChildren<Animator> ();
		if(animator==null){
			Debug.LogError("No Animator!!!");
		}
		ScoreBoard=ScoreBoardUIText.GetComponent<Text> ();
		if(ScoreBoard==null){
			Debug.LogError("No Score Board!!!");
		}
		HighestScore = PlayerPrefs.GetInt ("HighestScore",0);
	}
	
	// Update is called once per frame
	void Update () {
		//set GUI
		if(Score>HighestScore){
			HighestScore=Score;
		}
		ScoreBoard.text = "Score:"+Score+"\nHighest:"+HighestScore;


		if (isDead) {
			cooldown-=Time.deltaTime;
			if(cooldown<0){
				//Time.timeScale=0;
				if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0)) {
					Application.LoadLevel(Application.loadedLevel);
					}
			}
		} else {
			if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0)) {
				// Jump
				isFlapping = true;
			}
		}

	}

	void FixedUpdate(){
		if(isDead)
			return;
		rb.AddForce (Vector2.right*0.1f);
		if(isFlapping){
			animator.SetTrigger ("doflap");
			rb.AddForce(Vector2.up*150f);
			isFlapping=false;
		}

		if (rb.velocity.y < 0) {
			float angle = Mathf.Lerp (0, -90, -rb.velocity.y / 2f);
			transform.rotation = Quaternion.Euler (0, 0, angle);
		} else {
			transform.rotation = Quaternion.Euler (0, 0, 0);
		}
	}

	void OnCollisionEnter2D(Collision2D c){
		Debug.Log ("Collision!!!");
		isDead = true;
		animator.SetTrigger ("death");
	}

	void OnTriggerEnter2D(Collider2D c){
		if(c.tag=="scoreBox"){
			Score++;
		}
	}

	void OnDestroy(){
		PlayerPrefs.SetInt("HighestScore",HighestScore);
	}


	void SetScreenSize(){
		/*// set the desired aspect ratio (the values in this example are
		// hard-coded for 16:9, but you could make them into public
		// variables instead so you can set them at design time)
		float targetaspect = 16.0f / 9.0f;
		
		// determine the game window's current aspect ratio
		float windowaspect = (float)Screen.width / (float)Screen.height;
		
		// current viewport height should be scaled by this amount
		float scaleheight = windowaspect / targetaspect;
		
		// obtain camera component so we can modify its viewport
		Camera camera = GetComponent<Camera>();
		
		// if scaled height is less than current height, add letterbox
		if (scaleheight < 1.0f)
		{
			Rect rect = camera.rect;
			
			rect.width = 1.0f;
			rect.height = scaleheight;
			rect.x = 0;
			rect.y = (1.0f - scaleheight) / 2.0f;
			
			camera.rect = rect;
		}
		else // add pillarbox
		{
			float scalewidth = 1.0f / scaleheight;
			
			Rect rect = camera.rect;
			
			rect.width = scalewidth;
			rect.height = 1.0f;
			rect.x = (1.0f - scalewidth) / 2.0f;
			rect.y = 0;
			
			camera.rect = rect;
		}

		*/
	}

}
