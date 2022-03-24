using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolFire : MonoBehaviour
{
    public GameObject blackPistol;
    public bool isFiring = false;
    public GameObject bulletFlash;
    public AudioSource pistolShot;
    public static float distanceFromTarget;
    public float toTarget;



    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (isFiring == false)
            {
                StartCoroutine(FireThePistol());
            }
        }
    }

    IEnumerator FireThePistol()
    {
        isFiring = true;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            toTarget = hit.distance;
            distanceFromTarget = hit.distance;
        }
        blackPistol.GetComponent<Animator>().Play("FirePistol");
        pistolShot.Play();
        bulletFlash.SetActive(true);
        yield return new WaitForSeconds(0.03f);
        bulletFlash.SetActive(false);
        yield return new WaitForSeconds(0.22f);
        blackPistol.GetComponent<Animator>().Play("New State");
        isFiring = false;
    }
}