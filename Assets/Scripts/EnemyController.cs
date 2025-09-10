using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float rotationSpeed = 10.0f;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var directionToPlayer = Vector3.Normalize(player.transform.position - transform.position);
        if (Vector3.Dot(transform.TransformDirection(Vector3.up), directionToPlayer) > 0 )
        {
            //transform.rotation = Quaternion.Slerp();
        }
    }
}
