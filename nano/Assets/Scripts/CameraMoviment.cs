using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoviment : MonoBehaviour{
    void LateUpdate(){
        transform.position += new Vector3(0, 0.01f, 0);
    }
}
