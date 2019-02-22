using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireAnimation : MonoBehaviour{
    Vector3 defaultPosition;
    Vector3 defaultScale;

    float maxSize = 0.2f; //adiciona ou subtrai esse valor do tamanho total
    float yScale = 0f;

    void Start(){
        defaultPosition = transform.localPosition;
        defaultScale = transform.localScale;
        Debug.Log(defaultScale.y);
    }

    void Update(){
        if(Input.GetAxis("Vertical") != 0f && yScale < 0.2f && yScale > -0.2f)
            yScale += maxSize * Input.GetAxis("Vertical") * Time.deltaTime;
        else{
            if(yScale > 0f){
                yScale -= maxSize * Time.deltaTime;
                if(yScale < 0f)
                    yScale = 0f;
            }
            else{
                yScale += maxSize * Time.deltaTime;
                if(yScale > 0f)
                    yScale = 0f;
            }
        }

        transform.localScale = new Vector3(
            defaultScale.x,
            defaultScale.y + yScale,
            defaultScale.z
        );

        transform.localPosition = new Vector3(
            defaultPosition.x,
            defaultPosition.y + yScale * -2f,
            defaultPosition.z
        );
    }
}