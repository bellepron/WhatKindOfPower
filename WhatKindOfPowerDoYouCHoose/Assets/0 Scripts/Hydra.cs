using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hydra : MonoBehaviour, IShootable, IEndGameObserver
{
    GameObject hydra, head, body;
    Rigidbody headRigidbody;
    CapsuleCollider hydraCollider;
    [HideInInspector] public float speed = 2;

    void Start()
    {
        hydra = transform.GetChild(0).gameObject;
        head = transform.GetChild(2).gameObject;
        body = transform.GetChild(3).gameObject;
        headRigidbody = transform.GetChild(2).gameObject.GetComponent<Rigidbody>();
        hydraCollider = GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        if (Globals.isGameActive)
        {
            transform.position -= new Vector3(0, 0, speed * Time.deltaTime);
        }
    }

    public void Dead()
    {
        hydraCollider.enabled = false;
        hydra.SetActive(false);
        head.SetActive(true);
        body.SetActive(true);

        headRigidbody.AddForce(new Vector3(1, 2, 2).normalized * 10, ForceMode.Impulse);
        StartCoroutine(RotateHead());

        StartCoroutine(Reborn_Pooling());
    }
    IEnumerator Reborn_Pooling()
    {
        yield return new WaitForSeconds(3f);
        Reborn_Pooling(); hydraCollider.enabled = true;
        hydra.SetActive(true);
        head.SetActive(false);
        body.SetActive(false);

        FindObjectOfType<SpawnManager>().DespawnEnemy_Hydra(transform);
    }

    IEnumerator RotateHead()
    {
        Vector3 rot_vector = new Vector3(Random.Range(-50, -80), Random.Range(50, 80), Random.Range(20, 40));

        while (true)
        {
            head.transform.Rotate(rot_vector * Time.deltaTime);
            yield return null;
        }
    }

    public void GameEnd()
    {
        // StopAllCoroutines();
    }
}