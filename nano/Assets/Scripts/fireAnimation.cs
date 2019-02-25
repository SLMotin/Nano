using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAnimation : MonoBehaviour{
    Vector3 defaultPosition;
    Vector3 defaultScale;

    float maxSize = 0.2f; //adiciona ou subtrai esse valor do tamanho total
    float yScale = 0f;

    void Start(){
        defaultPosition = transform.localPosition;
        defaultScale = transform.localScale;
    }

    void Update(){
        if(Input.GetAxis("Vertical") != 0f && yScale < 0.2f && yScale > -0.2f)
            yScale += maxSize * Input.GetAxis("Vertical") * Time.deltaTime;
        else{
            int sinal = yScale > 0f ? -1 : 1;
            yScale += maxSize * Time.deltaTime * sinal;
            if(sinal < 0f && yScale < 0f || sinal > 0f && yScale > 0f)
                yScale = 0f;
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