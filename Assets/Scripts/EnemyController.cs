using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject player;
    public float baseOrbitSpeed = 0.5f;
    public float orbitSpeedMultiplier = 0.5f;
    private float orbitAngle;
    public float minOrbitDistance = 2f;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 offset = transform.position - player.transform.position;
        orbitAngle = Mathf.Atan2(offset.z, offset.x);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 directionToPlayer = player.transform.position - transform.position;

        float distanceToPlayer = directionToPlayer.magnitude;
        distanceToPlayer = Mathf.Max(distanceToPlayer, minOrbitDistance);

        float orbitSpeed = baseOrbitSpeed + distanceToPlayer * orbitSpeedMultiplier;
        orbitAngle += orbitSpeed * Time.deltaTime;

        float x = player.transform.position.x + Mathf.Cos(orbitAngle) * distanceToPlayer;
        float z = player.transform.position.z + Mathf.Sin(orbitAngle) * distanceToPlayer;
        transform.position = new Vector3(x, transform.position.y, z);

        float targetAngle = Mathf.Atan2(directionToPlayer.x, directionToPlayer.z) * Mathf.Rad2Deg;
        Vector3 currentRotation = transform.eulerAngles;
        currentRotation.y += Mathf.DeltaAngle(currentRotation.y, targetAngle - 90f);
        transform.eulerAngles = currentRotation;
    }
}
