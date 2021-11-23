using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish_Point : MonoBehaviour {
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
	{   StartCoroutine(Die());
	}

	IEnumerator Die()
	{
		Instantiate(deathEffect, transform.position, Quaternion.identity);
		// current.score++;
        // UI_Manager.UpdateScore(current.score);
		// _ball.addscore();
		// EnemiesAlive--;
		// if (EnemiesAlive <= 0)
		//     {
		// 	Debug.Log("LEVEL WON!");}
		UI_Manager.finishtext="Level Completed";
		//Destroy(gameObject);
		yield return new WaitForSeconds(2f);
		UI_Manager.finishtext="";
		Enemy.EnemiesAlive = 0;
		//if(SceneManager.GetActiveScene().buildIndex<2)
		//UI_Manager.recentscore=recent_score;
		SceneManager.LoadScene("Winner");
		//else UI_Manager.finishtext="Game Completed";
	}

}
