using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour
{
    [SerializeField] int damage = 50;
    [SerializeField] float speed = 80;
    string effType = "MiscBGravity";

    void Start()
    {
        if (transform.name == "FireMagic(Clone)")
        {
            effType = "MiscBGravityFire";
            damage = 50;
        }
        if (transform.name == "BlackMagic(Clone)")
        {
            effType = "MiscBGravityBlack";
            damage = 50;
        }
        if (transform.name == "ElectricMagic(Clone)")
        {
            effType = "MiscBGravityElectric";
            damage = 50;
        }
        StartCoroutine(DestroyThis());
    }
    
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
        IEnumerator DestroyThis()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
