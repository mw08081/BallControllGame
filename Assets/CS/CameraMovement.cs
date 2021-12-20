/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject Player;
    Vector3 dest;
    Vector3 val = new Vector3(0, 5, -5);

    void Start()
    {
        dest = Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        dest = Player.transform.position + val;
        transform.position = Vector3.Lerp(transform.position, dest, 0.1f);
    }
}
*/

using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Transform playerTransform;
    Vector3 offset;

    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - playerTransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = playerTransform.position + offset;
        
    }
}
