using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] int damage = 100;
    string effType;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EnemyHealthController>() != null)
        {
            if (Globals.sword_Index == 0)
                effType = "MiscBGravity";
            if (Globals.sword_Index == 1)
                effType = "MiscBGravityFire";
            if (Globals.sword_Index == 2)
                effType = "MiscBGravityBlack";
            other.GetComponent<EnemyHealthController>().GetDamage(damage, effType);
            gameObject.GetComponent<SphereCollider>().enabled = false;
        }
    }
}
