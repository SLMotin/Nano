using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FimFase : MonoBehaviour, IRender{
    public string nextFase;
    void Update(){
        Render();
    }

    public bool CanRender(){
        Vector2 botLeftCamera = Camera.main.ScreenToWorldPoint(new Vector3(-Screen.width/2f, -Screen.height/3f, 0));
        Vector2 topRightCamera = Camera.main.ScreenToWorldPoint(new Vector3(1.5f*Screen.width, 1.33f*Screen.height, 0));

        if(transform.position.x > botLeftCamera.x && transform.position.x < topRightCamera.x && transform.position.y > botLeftCamera.y && transform.position.y < topRightCamera.y)
            return true;
        else
            return false;
    }

    public void Render(){
        if(CanRender())
		  SceneManager.LoadScene(nextFase);
    }
}