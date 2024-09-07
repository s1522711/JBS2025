using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneHit : MonoBehaviour
{
    [Header("Sounds")]
    public AudioSource FlyingSound;
    public AudioSource hitSound;
    private int WallHits = 0;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody>(); 
       Debug.Log("PlaneHit script started");
    }

    // Update is called once per frame
    void Update()
    {
        // if the plane hits a wall, stop pushing it
        if (WallHits > 0)
        {
            //rb.useGravity = false;
            rb.AddForce(0, 0, 10, ForceMode.VelocityChange);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // if the plane hits a wall, stop pushing it
        if (collision.gameObject.tag == "Wall")
        {
            WallHits = 1;
            Debug.Log("Hit wall");
            // rotate the plane a bit
            rb.AddTorque(0, 100, 0, ForceMode.Impulse);

            // stop the flying sound
            if (FlyingSound != null)
            {
                if (FlyingSound.isPlaying)
                {
                    FlyingSound.Stop();
                }
            }
            
            // play the hit sound with a cooldown
            if (hitSound != null)
            {
                /*
                if (!hitSound.isPlaying)
                {
                    hitSound.Play();
                }
                */
                hitSound.Play();
            }
        }
    }
}
