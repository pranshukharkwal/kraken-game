using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class UI_Manager : MonoBehaviour
 {   //[SerializeField] 
//     Text _scoretext;
    public static int scorevalue=0; 
    public static string finishtext="";
    public Text score, finished;
    // Start is called before the first frame update
    void Start()
    {   
        //_scoretext.text="Score : 0";
        //score=GetComponent<Text>();
    }
    void Update(){
        
        if(finishtext==""){
            //level.text="Level : "+level_number;
            finished.text="";
         score.text="Score : " + scorevalue;
        }
         else {score.text="";finished.text=finishtext;
         //if(SceneManager.GetActiveScene().buildIndex==2)

         }
    }
}
