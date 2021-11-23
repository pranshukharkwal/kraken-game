using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
using UnityEngine.SceneManagement;  
public class SceneChanger: MonoBehaviour {  
    public void Easy() {  
        SceneManager.LoadScene("MainLevel");  
    }
    public void Medium() {  
        SceneManager.LoadScene("MainLevel 1");  
    }
    public void Hard() {  
        SceneManager.LoadScene("MainLevel 2");  
    }
    public void StartMenu() {  
        SceneManager.LoadScene("Start Menu");  
    }
    public void Levels() {  
        SceneManager.LoadScene("Levels");  
    }
    public void Winner() {  
        SceneManager.LoadScene("Winner");  
    }
    public void Instructions() {  
        SceneManager.LoadScene("Instructions");  
    }

} 
