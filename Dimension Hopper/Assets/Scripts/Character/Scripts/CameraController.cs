using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;


public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;

        if(Input.GetKey(KeyCode.A));
        {
            transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * 100, Space.World);
        }

        if(Input.GetKey(KeyCode.D)){
            transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * 100, Space.World);
        }
    }
}
