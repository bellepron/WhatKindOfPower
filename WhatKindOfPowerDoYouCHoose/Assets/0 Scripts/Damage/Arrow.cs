using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] int damage = 34;
    [SerializeField] float speed = 100;
    string effType = "MiscBGravity";

    void Start()
    {
        if (transform.name == "FireArrow(Clone)")
        {
            effType = "MiscBGravityFire";
            damage = 50;
        }
        if (transform.name == "BlackArrow(Clone)")
        {
            effType = "MiscBGravityBlack";
            damage = 50;
        }
        StartCoroutine(DestroyThis());
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
        transform.Rotate(5 * Time.deltaTime, 0, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<EnemyHealthController>() != null)
        {
            other.gameObject.GetComponent<EnemyHealthController>().GetDamage(damage, effType);
            Destroy(gameObject);
        }
    }

    IEnumerator DestroyThis()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
