using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Gun gun;
    public GameObject eject;
    public LayerMask obstacleMask;

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

    [Header("Audio")]
    public string reloadSound;

    void Start()
    {
        currentClipSize = gun.clipSize;
        currentAmmo = gun.maxAmmo;
    }

    void Update()
    {
        CheckAmmo();

        if (reload || !shoot)
            StartCoroutine(Reload());

        if (shoot == true && clipEmpty == false)
        {
            if (FL_coolDown < Time.time)
            {
                FireBullet();
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
        Destroy(gameObject);
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

    void FireBullet()
    {
        var fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit coll;
        // Raycast to check if the view from the target to player runs into an obsticle, if not adding the target to the list of targets
        if (Physics.Raycast(eject.transform.position, fwd, out coll))
        {
            GameObject hit = coll.transform.gameObject;

            hit.SendMessage("TakeDamage", gun.damage, SendMessageOptions.DontRequireReceiver);
        }

        Instantiate(gun.bullet,
            eject.transform.position,
            eject.transform.rotation);

    }
}
