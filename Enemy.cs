using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public Ball _ball; 
	public GameObject deathEffect;

	public float health = 4f;
    public Ball current;
	public static int EnemiesAlive = 0;

	void Start ()
	{   //GetComponent<AudioSource> ().playOnAwake = false;
         
		EnemiesAlive++;
	}

	void OnCollisionEnter2D (Collision2D colInfo)
	{     
	
		if (colInfo.relativeVelocity.magnitude > health)
		{
			Die();
		}
	}

	void Die ()
	{
		 GameObject newDeathEffect = Instantiate(deathEffect, transform.position, Quaternion.identity);
		// current.score++;
        // UI_Manager.UpdateScore(current.score);
		_ball.addscore();
		EnemiesAlive--;
		if (EnemiesAlive <= 0)
		    {
			Debug.Log("LEVEL WON!");}
         Destroy(newDeathEffect, 5f);
		Destroy(gameObject);
	}

}