using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour {

	public Rigidbody2D rb;
	public Rigidbody2D hook;
    public UI_Manager _UI_Manager;
	public float releaseTime = .15f;
	public float maxDragDistance = 2f;
	public GameObject nextBall;
    public AudioClip DestroySound,Groundhit,Hardhit;
	private bool isPressed = false;
	void Start(){
		UI_Manager.scorevalue=0;
	}
	public void addscore(){
		UI_Manager.scorevalue+=1;
	} 
	private float time = 0.0f;
    public float interpolationPeriod = 1.5f;
	void OnCollisionEnter2D (Collision2D colInfo)
	{     //Debug.Log(colInfo.gameObject.name);
		if(colInfo.gameObject.name[0]=='E')
		{GetComponent<AudioSource> ().clip = DestroySound;
		GetComponent<AudioSource>().Play();}
		else if(colInfo.gameObject.name.Contains("Ground"))
		{GetComponent<AudioSource> ().clip = Groundhit;
		GetComponent<AudioSource>().Play();}
		
		else if(colInfo.gameObject.name[0]=='H'){
			GetComponent<AudioSource> ().clip = Hardhit;
		GetComponent<AudioSource>().Play();
		}
		
	}
	void Update ()
	{  time += Time.deltaTime;
		if (isPressed)
		{
			Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			if (Vector3.Distance(mousePos, hook.position) > maxDragDistance)
				rb.position = hook.position + (mousePos - hook.position).normalized * maxDragDistance;
			else
				rb.position = mousePos;
		}
		if (time >= interpolationPeriod) {
         time = time - interpolationPeriod;
            // Implementing gravity for each side of the polygon as per the game concept
		    SpriteRenderer[] grounds = FindObjectsOfType<SpriteRenderer>();
			 Transform bestTarget = null;
             float closestDistanceSqr = Mathf.Infinity;
             Vector3 currentPosition = rb.position;
			 Vector2 closest_dir=new Vector2(0,-9.8f);
             foreach(SpriteRenderer sprites in grounds)
             { 
			     if(sprites.name[0]!='G')continue;
				 //Debug.Log(sprites.name);
                 Vector2 directionToTarget = sprites.transform.position - currentPosition;
                 float dSqrToTarget = directionToTarget.sqrMagnitude;
                 if(dSqrToTarget < closestDistanceSqr)
                 {   closest_dir=directionToTarget;
                     closestDistanceSqr = dSqrToTarget;
                     bestTarget = sprites.transform;
                 }
             }
			 Physics2D.gravity = closest_dir;
     }
	}

	void OnMouseDown ()
	{
		isPressed = true;
		rb.isKinematic = true;
	}

	void OnMouseUp ()
	{
		isPressed = false;
		rb.isKinematic = false;
		StartCoroutine(Release());
	}
	IEnumerator Release ()
	{
		yield return new WaitForSeconds(releaseTime);
		GetComponent<SpringJoint2D>().enabled = false;
		this.enabled = false;
		yield return new WaitForSeconds(8f);
			Enemy.EnemiesAlive = 0;
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}