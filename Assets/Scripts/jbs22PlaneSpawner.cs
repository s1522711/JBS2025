using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jbs22PlaneSpawner : MonoBehaviour
{
    [Header("Plane")]
    public GameObject plane;
    public List<GameObject> planeSpawnLocations;

    [Header("Speeds")]
    public int PlaneSpeedX = 500;
    public int PlaneSpeedY = 500;
    public int PlaneSpeedZ = 500;

    [Header("Delays")]
    public float planeSpawnDelay = 5f;
    public float planeSpawnCooldown = 0.5f;
    public float planeTTL = 10f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DoPlaneSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DoPlaneSpawn()
    {
        while (true) {
            // spawn a plane at each spawn location
            foreach (GameObject planeSpawnLocation in planeSpawnLocations)
            {
                GameObject newPlane = Instantiate(plane, new Vector3(0, 0, 0), Quaternion.identity);
                newPlane.transform.localScale = new Vector3(1, 1, 1);
                newPlane.transform.position = planeSpawnLocation.transform.position;
                newPlane.transform.rotation = planeSpawnLocation.transform.rotation;

                
                // Add force to the plane
                newPlane.GetComponent<Rigidbody>().AddForce(PlaneSpeedX, PlaneSpeedY, PlaneSpeedZ, ForceMode.VelocityChange);

                // add ttl script to the plane
                AudoDeleteAfterTime ttlScript = newPlane.AddComponent<AudoDeleteAfterTime>();
                ttlScript.timeToLive = planeTTL;
                

                // Wait for the next plane spawn
                yield return new WaitForSeconds(planeSpawnCooldown);
            }

            // Wait for the next plane spawn
            yield return new WaitForSeconds(planeSpawnDelay);
        }
    }
}
