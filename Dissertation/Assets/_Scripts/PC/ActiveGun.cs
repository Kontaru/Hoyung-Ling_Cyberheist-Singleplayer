using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActiveGun : MonoBehaviour
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
        if (pickup != null)
        {
            weapon.gameObject.SetActive(false);
            weapon = pickup;
            pickup = null;
            SpawnGun();
        }
        else if (fallback != null && weapon == null)
        {
            weapon = fallback;
            SpawnGun();
        }
        else if (weapon == null)
        {
            return;
        }


        triggerPulled = Input.GetKey(GameManager.instance.KC_Shoot);
        weapon.shoot = triggerPulled;

        fireMissile = Input.GetKey(GameManager.instance.KC_Missile);

        if(fireMissile && Time.time > missileCooldown)
        {
            missileCooldown = Time.time + 5f;
            FireMissile();
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

    void FireMissile()
    {
        Instantiate(missilePrefab,
            missileEject.transform.position,
            missileEject.transform.rotation);
    }

    void SpawnGun()
    {
        var gun = (Weapon)Instantiate(weapon, gunPosition.position, gunPosition.rotation);

        if (gun == null)
            Debug.Log("NO GUN");

        weapon = gun;
        weapon.transform.parent = transform;
    }
}
