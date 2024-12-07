using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gm_bigcity : MonoBehaviour
{
    [Header("Plane")]
    public GameObject plane;
    public GameObject planeSpawnLocation;
    public GameObject plane2SpawnLocation;
    public ParticleSystem planeExplosion;
    public int planeSpeedX = 0;
    public int planeSpeedY = 0;
    public int planeSpeedZ = 500;
    public int planeHitForceX = 0;
    public int planeHitForceY = 0;
    public int planeHitForceZ = 10;
    public int planeHitTorqueX = 0;
    public int planeHitTorqueY = 100;
    public int planeHitTorqueZ = 0;

    [Header("Sounds")]
    public AudioSource planeHitSound;
    public AudioSource plane2Sound;
    public AudioSource winSound;

    [Header("Scene")]
    public string sceneToLoad;
    public FunMode funModeObject;

    [Header("UI")]
    public Canvas YouWinTextCanvas;

    [Header("Delays")]
    public int planeSpawnDelay = 10;
    public int plane2SoundDelay = 10;
    public int plane2SpawnDelay = 10;
    public int winDelay = 10;
    public int sceneSwitchDelay = 5;

    // Start is called before the first frame update
    void Start()
    {
        YouWinTextCanvas.enabled = false;
        StartCoroutine(DoPlaneSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DoPlaneSpawn()
    {
        yield return new WaitForSeconds(planeSpawnDelay);
        GameObject newPlane = Instantiate(plane, new Vector3(0, 0, 0), Quaternion.identity);
        newPlane.transform.localScale = new Vector3(1, 1, 1);
        newPlane.transform.position = planeSpawnLocation.transform.position;
        newPlane.transform.rotation = planeSpawnLocation.transform.rotation;
        newPlane.GetComponent<Rigidbody>().AddForce(planeSpeedX, planeSpeedY, planeSpeedZ, ForceMode.VelocityChange);
        newPlane.GetComponent<PlaneHit>().hitSound = planeHitSound;
        newPlane.GetComponent<PlaneHit>().forceX = planeHitForceX;
        newPlane.GetComponent<PlaneHit>().forceY = planeHitForceY;
        newPlane.GetComponent<PlaneHit>().forceZ = planeHitForceZ;
        newPlane.GetComponent<PlaneHit>().torqueX = planeHitTorqueX;
        newPlane.GetComponent<PlaneHit>().torqueY = planeHitTorqueY;
        newPlane.GetComponent<PlaneHit>().torqueZ = planeHitTorqueZ;
        newPlane.GetComponent<PlaneHit>().explosion = planeExplosion;

        yield return new WaitForSeconds(plane2SoundDelay);
        if (plane2Sound != null)
        {
            if (!plane2Sound.isPlaying)
            {
                plane2Sound.Play();
            }
        }

        yield return new WaitForSeconds(plane2SpawnDelay);
        GameObject newPlane2 = Instantiate(plane, new Vector3(0, 0, 0), Quaternion.identity);
        newPlane2.transform.localScale = new Vector3(1, 1, 1);
        newPlane2.transform.position = plane2SpawnLocation.transform.position;
        newPlane2.transform.rotation = plane2SpawnLocation.transform.rotation;
        newPlane2.GetComponent<Rigidbody>().AddForce(planeSpeedX, planeSpeedY, planeSpeedZ, ForceMode.VelocityChange);
        newPlane2.GetComponent<PlaneHit>().hitSound = planeHitSound;
        newPlane2.GetComponent<PlaneHit>().forceX = planeHitForceX;
        newPlane2.GetComponent<PlaneHit>().forceY = planeHitForceY;
        newPlane2.GetComponent<PlaneHit>().forceZ = planeHitForceZ;
        newPlane2.GetComponent<PlaneHit>().torqueX = planeHitTorqueX;
        newPlane2.GetComponent<PlaneHit>().torqueY = planeHitTorqueY;
        newPlane2.GetComponent<PlaneHit>().torqueZ = planeHitTorqueZ;
        newPlane2.GetComponent<PlaneHit>().explosion = planeExplosion;

        yield return new WaitForSeconds(winDelay);
        YouWinTextCanvas.enabled = true;
        if (winSound != null)
        {
            if (!winSound.isPlaying)
            {
                winSound.Play();
            }
        }

        yield return new WaitForSeconds(sceneSwitchDelay);
                // if fun mode is enabled, wait for it to be disabled
        if (funModeObject != null)
        {
            while (funModeObject.funModeEnabled)
            {
                YouWinTextCanvas.GetComponentInChildren<TextMeshProUGUI>().text = "Waiting for Fun Mode to be disabled (press F)...";
                YouWinTextCanvas.GetComponentInChildren<TextMeshProUGUI>().fontSize = 20;
                yield return new WaitForSeconds(0.1f);
            }
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad);
    }
}
