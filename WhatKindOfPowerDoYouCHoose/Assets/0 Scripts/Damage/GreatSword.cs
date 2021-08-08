using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreatSword : MonoBehaviour
{
    [SerializeField] int damage = 100;
    string effType = "MiscBGravity";

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(transform.name);
        if (Globals.greatSword_Index == 0)
            effType = "MiscBGravity";
        if (Globals.greatSword_Index == 1)
            effType = "MiscBGravityFire";
        if (Globals.greatSword_Index == 2)
            effType = "MiscBGravityBlack";
        if (other.GetComponent<EnemyHealthController>() != null)
        {
            other.GetComponent<EnemyHealthController>().GetDamage(damage, effType);
            gameObject.GetComponent<SphereCollider>().enabled = false;
        }
    }
}
