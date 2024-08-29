using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontrol : MonoBehaviour
{
    [SerializeField] GameObject thingstofollow;

    // Update is called once per frame
    void LateUpdate() {
    
        transform.position = thingstofollow.transform.position + new Vector3 (0,0,-10);
    }
}
