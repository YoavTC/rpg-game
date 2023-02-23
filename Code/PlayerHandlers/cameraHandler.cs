using System;
using UnityEngine;

public class cameraHandler : MonoBehaviour
{
    public GameObject player;
    public float speed = 5f;
    void FixedUpdate()
    {
        //transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10); //HARSH FOLLOW
        Vector3 newPos = Vector3.Lerp(transform.position, player.transform.position, Time.deltaTime * speed); //SMOOTH FOLLOW
        newPos.z = -10;
        transform.position = newPos;
    }
    void Start()
    {
        Camera.main.orthographicSize = 5;
    }
}
