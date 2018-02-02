using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
using TMPro;

public class ActiveGun : NetworkBehaviour
{
    public Transform gunPosition;
    public Weapon weapon;
    public Weapon pickup;
    public Weapon fallback;

    public GameObject missilePrefab;
    public GameObject missileEject;
    float missileCooldown = 0;

    bool triggerPulled = false;
    bool fireMissile = false;

    public int currentAmmo;
    public int currentClipSize;

    // UI Params
    public static TextMeshProUGUI nameText;
    public static TextMeshProUGUI clipText;
    public static TextMeshProUGUI currentClipText;
    public static TextMeshProUGUI ammoText;

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        if (pickup != null)
        {
            weapon.gameObject.SetActive(false);
            weapon = pickup;
            pickup = null;
            Cmd_SpawnGun();
        }
        else if (fallback != null && weapon == null)
        {
            weapon = fallback;
            Cmd_SpawnGun();
        }
        else if (weapon == null)
        {
            return;
        }

        /*if (Application.platform == RuntimePlatform.WindowsPlayer)
            triggerPulled = Input.GetKeyDown("Space");
        else if (Application.platform == RuntimePlatform.Android)*/
        triggerPulled = CrossPlatformInputManager.GetButton("Shoot");
        weapon.shoot = triggerPulled;

        //ShootGun();

        fireMissile = CrossPlatformInputManager.GetButton("Missile");

        if(fireMissile && Time.time > missileCooldown)
        {
            missileCooldown = Time.time + 5f;
            Cmd_FireMissile();
        }

        UpdateUI();
    }

    /*
    void ShootGun()
    {
        weapon.CheckAmmo();

        if (weapon.reload || !weapon.shoot)
            StartCoroutine(weapon.Reload());

        if (weapon.shoot == true && weapon.clipEmpty == false)
        {
            if (weapon.FL_coolDown < Time.time)
            {
                Cmd_FireBullet();
                weapon.FL_coolDown = weapon.ApplyCooldown(weapon.FL_coolDown);
            }
        }
    }

    [Command]
    void Cmd_FireBullet()
    {
        var _bullet = (GameObject)Instantiate(weapon.gun.bullet,
            weapon.eject.transform.position,
            weapon.eject.transform.rotation);

        NetworkServer.Spawn(_bullet);
    }*/

    void UpdateUI()
    {
        nameText.text = weapon.gun.name;
        clipText.text = string.Format("" + weapon.gun.clipSize);
        currentClipText.text = string.Format("" + weapon.currentClipSize);
        ammoText.text = string.Format("" + weapon.currentAmmo);
    }

    public void Missile()
    {
        Cmd_FireMissile();
    }

    [Command]
    void Cmd_FireMissile()
    {
        var _bullet = (GameObject)Instantiate(missilePrefab,
            missileEject.transform.position,
            missileEject.transform.rotation);

        NetworkServer.Spawn(_bullet);
    }

    [Command]
    void Cmd_SpawnGun()
    {
        RpcSpawnGun();
        //var gun = (Weapon)Instantiate(weapon, gunPosition.position, gunPosition.rotation);

        //if (gun == null)
        //    Debug.Log("NO GUN");

        //weapon = gun;
        //weapon.transform.parent = transform;

        //NetworkServer.Spawn(weapon.gameObject);
    }

    [ClientRpc]
    void RpcSpawnGun()
    {
        var gun = (Weapon)Instantiate(weapon, gunPosition.position, gunPosition.rotation);

        if (gun == null)
            Debug.Log("NO GUN");

        weapon = gun;
        weapon.transform.parent = transform;

        NetworkServer.Spawn(weapon.gameObject);
    }
}
