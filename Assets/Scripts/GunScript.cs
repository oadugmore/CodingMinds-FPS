using UnityEngine;

public class GunScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // If the player left-clicks
        if (Input.GetButtonDown("Fire1"))
        {
            // Play gunfire sound
            GetComponent<AudioSource>().Play();

            // Play recoil animation
            GetComponent<Animation>().Play();

            // Detect object in gun's line of sight
            RaycastHit hit;
            Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit);

            // Cause damage to that object
            hit.transform.SendMessage("TakeDamage");
        }
    }
}
