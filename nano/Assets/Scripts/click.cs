using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class click : MonoBehaviour{
    public GameObject imagem;
    void Update(){
        if(Input.GetMouseButtonDown(0)){
            float z = imagem.transform.position.z;
            imagem.transform.position = new Vector3(imagem.transform.position.x, imagem.transform.position.y, (z+1f)%2f);
        }
    }
}
