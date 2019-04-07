using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultRender : MonoBehaviour, IRender{
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
        Transform child = gameObject.transform.GetChild(0);
        if(child != null)
            child.gameObject.SetActive(CanRender());
        else
            Destroy(gameObject);
    }
}