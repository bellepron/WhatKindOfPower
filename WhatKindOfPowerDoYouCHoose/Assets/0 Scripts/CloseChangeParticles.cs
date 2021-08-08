using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseChangeParticles : MonoBehaviour
{
    void OnEnable()
    {
        StartCoroutine(Close());
    }

    IEnumerator Close()
    {
        yield return new WaitForSeconds(1.9f);
        gameObject.SetActive(false);
    }
}
