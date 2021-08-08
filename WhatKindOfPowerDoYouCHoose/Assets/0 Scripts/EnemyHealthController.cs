using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    Hydra hydra;
    [SerializeField] int health = 100;
    [SerializeField] ParticleSystem fire;
    [SerializeField] ParticleSystem black;

    void Start()
    {
        hydra = GetComponent<Hydra>();
    }

    void Update()
    {

    }

    public void GetDamage(int damage, string effType)
    {
        if (effType == "MiscBGravityFire")
            fire.Play();
        if (effType == "MiscBGravityBlack")
            black.Play();

        if (health > damage)
        {
            health -= damage;
            GameObject hitEff = Instantiate(Resources.Load(effType), transform.position + new Vector3(0, 7, -3), Quaternion.Euler(-90, 0, 0)) as GameObject;
            Destroy(hitEff, 3f);
        }
        else
        {
            health = 0;
        }

        if (health == 0)
        {
            hydra.Dead();
        }
    }
}
