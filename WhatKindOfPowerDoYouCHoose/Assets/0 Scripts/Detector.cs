using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    BoxCollider detectorCollider;
    public Vector3 targetPosition;

    public float coolDown = 0.5f;

    void Start()
    {
        detectorCollider = GetComponent<BoxCollider>();
    }

    void Update()
    {

    }

    public void UpdateDetectorScaleAndPosition(string typeName)
    {
        if (typeName == "Stickman")
        {
            transform.localPosition = new Vector3(0, 3, 2.5f);
            transform.localScale = new Vector3(5, 1, 5);
        }
        if (typeName == "Archer")
        {
            transform.localPosition = new Vector3(0, 3, 20);
            transform.localScale = new Vector3(20, 1, 40);
        }
        if (typeName == "Knight")
        {
            transform.localPosition = new Vector3(0, 3, 4);
            transform.localScale = new Vector3(8, 1, 8);
        }
        if (typeName == "GreatSworder")
        {
            transform.localPosition = new Vector3(0, 3, 5);
            transform.localScale = new Vector3(10, 1, 10);
        }
        if (typeName == "Wizard")
        {
            transform.localPosition = new Vector3(0, 3, 20);
            transform.localScale = new Vector3(20, 1, 40);
        }
        if (typeName == "Soldier")
        {
            transform.localPosition = new Vector3(0, 3, 30);
            transform.localScale = new Vector3(20, 1, 60);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<IShootable>() != null)
        {
            targetPosition = other.transform.position;
            GameEvents.m_MyEquip.Invoke();
            StartCoroutine(Cooling());
            // other.gameObject.GetComponent<Hydra>().Dead();
        }
    }

    IEnumerator Cooling()
    {
        detectorCollider.enabled = false;
        yield return new WaitForSeconds(coolDown);
        detectorCollider.enabled = true;
    }
}
