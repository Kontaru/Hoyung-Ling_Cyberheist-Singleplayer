using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Entity : NetworkBehaviour {

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
