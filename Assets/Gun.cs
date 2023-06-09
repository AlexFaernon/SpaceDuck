using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletSpawner;
    [SerializeField] private float bulletSpeed;
    public static int Count;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Fire()
    {
        var bulletObj = Instantiate(bullet, bulletSpawner.position, bulletSpawner.rotation);
        bulletObj.GetComponent<Rigidbody>().velocity = bulletSpawner.forward * bulletSpeed;
        Destroy(bulletObj, 5);
        Count++;
        audioSource.Play();
    }
}
