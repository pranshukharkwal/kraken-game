using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hard_Enemy : MonoBehaviour {
    public Ball _ball; 
	public GameObject deathEffect;

	public float health = 4f;
    public Ball current;
	public static int EnemiesAlive = 0;

	void Start ()
	{
		EnemiesAlive++;
	}

	void OnCollisionEnter2D (Collision2D colInfo)
	{
		if (colInfo.relativeVelocity.magnitude > health)
		{
			//Die();
		}
	}

	void Die ()
	{
		Instantiate(deathEffect, transform.position, Quaternion.identity);
		// current.score++;
        // UI_Manager.UpdateScore(current.score);
		_ball.addscore();
		EnemiesAlive--;
		if (EnemiesAlive <= 0)
		    {
			Debug.Log("LEVEL WON!");}

		Destroy(gameObject);
	}

}
