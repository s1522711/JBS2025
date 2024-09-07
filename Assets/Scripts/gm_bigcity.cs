using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gm_bigcity : MonoBehaviour
{
    [Header("Plane")]
    public GameObject plane;
    public GameObject planeSpawnLocation;
    public int planeSpawnDelay = 10;
    public int planeSpeed = 500;

    [Header("Sounds")]
    public AudioSource planeHitSound;
    public AudioSource winSound;
    public int winDelay = 10;

    [Header("Scene")]
    public string sceneToLoad;
    public int sceneSwitchDelay = 5;
    public FunMode funModeObject;

    [Header("UI")]
    public Canvas YouWinTextCanvas;

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
        newPlane.GetComponent<Rigidbody>().AddForce(0, 0, planeSpeed, ForceMode.VelocityChange);
        newPlane.GetComponent<PlaneHit>().hitSound = planeHitSound;

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
