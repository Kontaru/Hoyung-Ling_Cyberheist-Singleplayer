using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class UIElement
{
    public Image Sprite;
    Color enable;
    Color disable;
    Color shadow;

    public void SetStates()
    {
        enable = Sprite.color;
        disable = Sprite.color;
        shadow = Sprite.color;

        disable.a = 0;
        shadow = new Color32(120, 120, 120, 255);
    }

    public void Enable()
    {
        Sprite.color = enable;
    }

    public void Disable()
    {
        Sprite.color = disable;
    }

    public void Shadow()
    {
        Sprite.color = shadow;
    }
}

public class PC_UI : MonoBehaviour
{

    PC_Health CC_Health;

    public UIElement[] Health;
    public UIElement[] Attacks;
    public UIElement[] Dashes;

    // Use this for initialization
    void Start()
    {
        foreach (UIElement element in Health)
        {
            element.SetStates();
        }

        foreach (UIElement element in Attacks)
        {
            element.SetStates();
        }

        foreach (UIElement element in Dashes)
        {
            element.SetStates();
        }

        CC_Health = GetComponent<PC_Health>();
    }

    // Update is called once per frame
    //void Update()
    //{
    //    HealthUpdate();
    //    AttackUpdate();
    //    DashUpdate();
    //}

    //void HealthUpdate()
    //{
    //    if (CC_Health.health == 4)
    //    {
    //        Health[3].Enable();
    //        Health[2].Enable();
    //        Health[1].Enable();
    //        Health[0].Enable();
    //    }
    //    else if (CC_Health.health == 3)
    //    {
    //        Health[3].Disable();
    //        Health[2].Enable();
    //        Health[1].Enable();
    //        Health[0].Enable();
    //    }
    //    else if (CC_Health.health == 2)
    //    {
    //        Health[3].Disable();
    //        Health[2].Disable();
    //        Health[1].Enable();
    //        Health[0].Enable();
    //    }
    //    else if (CC_Health.health == 1)
    //    {
    //        Health[3].Disable();
    //        Health[2].Disable();
    //        Health[1].Disable();
    //        Health[0].Enable();
    //    }
    //    else if (CC_Health.health == 0)
    //    {
    //        Health[3].Disable();
    //        Health[2].Disable();
    //        Health[1].Disable();
    //        Health[0].Disable();
    //    }
    //}

    //void AttackUpdate()
    //{
    //    if (CC_Melee.swingcount() == 3)
    //    {
    //        Attacks[2].Enable();
    //        Attacks[1].Enable();
    //        Attacks[0].Enable();
    //    }
    //    else if (CC_Melee.swingcount() == 2)
    //    {
    //        Attacks[2].Shadow();
    //        Attacks[1].Enable();
    //        Attacks[0].Enable();
    //    }
    //    else if (CC_Melee.swingcount() == 1)
    //    {
    //        Attacks[2].Shadow();
    //        Attacks[1].Shadow();
    //        Attacks[0].Enable();
    //    }
    //    else if (CC_Melee.swingcount() == 0)
    //    {
    //        Attacks[2].Shadow();
    //        Attacks[1].Shadow();
    //        Attacks[0].Shadow();
    //    }
    //}

    //void DashUpdate()
    //{
    //    if (CC_Move.dashcount() == 2)
    //    {
    //        Dashes[1].Enable();
    //        Dashes[0].Enable();
    //    }
    //    else if (CC_Move.dashcount() == 1)
    //    {
    //        Dashes[1].Shadow();
    //        Dashes[0].Enable();
    //    }
    //    else if (CC_Move.dashcount() == 0)
    //    {
    //        Dashes[1].Shadow();
    //        Dashes[0].Shadow();
    //    }
    //}
}
