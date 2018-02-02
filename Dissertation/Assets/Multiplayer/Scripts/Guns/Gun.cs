using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Gun")]
public class Gun : ScriptableObject {

    public new string name;
    public string description;

    [Header("Bullet Params")]
    public GameObject bullet;
    public float damage;
    public float fireRate;

    [Header("Gun Params")]
    public float reloadTime;

    public int maxAmmo;
    public int clipSize;

    public bool infiniteClip = false;
    public bool infiniteAmmo = false;

}
