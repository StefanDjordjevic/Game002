using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Camera.main.transform.LookAt(player.transform);
    }

    
}
