using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
public class musicManager: MonoBehaviour {  
    public AudioSource click;
    void Start() {}  
    // Update is called once per frame      
    void Update() {}  
    public void PlayMusic() {  
        click.Play();  
        Debug.Log("play");  
    }
}  
