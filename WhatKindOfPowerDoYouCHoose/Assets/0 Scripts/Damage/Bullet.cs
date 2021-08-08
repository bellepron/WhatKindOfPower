using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] int damage = 15;
    [SerializeField] float speed = 150;
    string effType = "MiscBGravity";

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<EnemyHealthController>() != null)
        {
            other.gameObject.GetComponent<EnemyHealthController>().GetDamage(damage, effType);
            Destroy(gameObject);
        }
    }
}
