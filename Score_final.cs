using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class Score_final : MonoBehaviour
 {   //[SerializeField] 
//     Text _scoretext;
    public static int recent_score=0;
    public TextMeshProUGUI recentscore;
    // Start is called before the first frame update
    void Start()
    {   
        //_scoretext.text="Score : 0";
        //score=GetComponent<Text>();
    }
    void Update(){
        
        recent_score=UI_Manager.scorevalue;
        recentscore.text="Score : "+recent_score;
    }
    // public  void UpdateScore(int playerScore)
    // {
    //     _scoretext.text="Score : " +playerScore.ToString();
    // }
}
