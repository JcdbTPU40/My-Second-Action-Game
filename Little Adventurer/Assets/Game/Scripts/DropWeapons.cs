using System.Collections.Generic;
using UnityEngine;

public class DropWeapons : MonoBehaviour
{
    public List<GameObject> Weapons;

    public void DropSwords()
    {
        foreach (GameObject weapon in Weapons)
        {
            if (weapon != null)
            {
                weapon.AddComponent<Rigidbody>();
                weapon.AddComponent<BoxCollider>();
                weapon.transform.parent = null;
            }
        }
    }
}
