using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Weapon : NetworkBehaviour {

    public Gun gun;
    public GameObject eject;

    [Header("Player Actions")]
    public bool reload;
    public bool shoot;

    [Header("Empty?")]
    public bool empty = false;
    public bool clipEmpty = true;

    [Header("Ammo Params")]
    public int currentAmmo;
    public int currentClipSize;

    public float FL_coolDown = 0;

    void Start()
    {
        currentClipSize = gun.clipSize;
        currentAmmo = gun.maxAmmo;
    }

    void Update()
    {
        if (!hasAuthority) return;

        
        CheckAmmo();

        if(reload || !shoot)
            StartCoroutine(Reload());

        if (shoot == true && clipEmpty == false)
        {
            if (FL_coolDown < Time.time)
            {
                Cmd_FireBullet();
                FL_coolDown = ApplyCooldown(FL_coolDown);
            }
        }
    }

    public void CheckAmmo()
    {
        clipEmpty = true;

        if (currentAmmo <= 0) NoAmmo();
        else if (currentClipSize <= 0) reload = true;
        else clipEmpty = false;
    }

    public IEnumerator Reload()
    {
        clipEmpty = true;
        yield return new WaitForSeconds(gun.reloadTime);
        if (reload || !shoot)
        {
            int difference = currentAmmo - gun.clipSize;
            if (difference >= 0)
                currentClipSize = gun.clipSize;
            else
                currentClipSize = gun.clipSize + difference;

            reload = false;
            clipEmpty = false;
        }
    }

    void NoAmmo()
    {
        currentAmmo = 0;
        gameObject.SetActive(false);
    }

    public float ApplyCooldown(float coolDown)
    {
        coolDown = Time.time + 60f / gun.fireRate;

        currentClipSize--;
        currentAmmo--;

        if (gun.infiniteClip)
            currentClipSize++;
        if (gun.infiniteAmmo)
            currentAmmo++;

        return coolDown;
    }

    [Command]
    void Cmd_FireBullet()
    {
        var _bullet = (GameObject)Instantiate(gun.bullet,
            eject.transform.position,
            eject.transform.rotation);

        NetworkServer.Spawn(_bullet);
    }
}
