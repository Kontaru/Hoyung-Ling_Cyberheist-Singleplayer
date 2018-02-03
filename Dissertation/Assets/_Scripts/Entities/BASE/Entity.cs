using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {

    #region --- Entity Types Setter ---

    public enum Entities
    {
        None,
        Player,
        Enemy,
        Pickup,
    }

    #endregion

    public Entities EntityType;
}
