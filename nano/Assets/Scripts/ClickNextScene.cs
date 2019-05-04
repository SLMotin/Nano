using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickNextScene : MonoBehaviour{
    void Update(){
        if(Input.touchCount > 0 || Input.anyKey)
		    SceneManager.LoadScene("Menu Inicial");
    }
}
