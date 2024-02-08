using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float offsetZ = 5f;
    [SerializeField] float smoothing = 8f;

    Transform playerPosition;

    void Start()
    {
        playerPosition = FindAnyObjectByType<PlayerController>().transform;
    }

    void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer() 
    {
        Vector3 targetPosition = new Vector3(playerPosition.position.x, transform.position.y, playerPosition.position.z - offsetZ);
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
    }
}
