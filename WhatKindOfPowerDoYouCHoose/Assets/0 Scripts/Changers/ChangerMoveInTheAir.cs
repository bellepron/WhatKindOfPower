using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChangerMoveInTheAir : MonoBehaviour
{
    Sequence sequence;
    void Start()
    {
        sequence = DOTween.Sequence();
        sequence.Append(transform.DOMoveY(4.3f, 2));
        sequence.SetLoops(-1, LoopType.Yoyo);
    }
    void Update()
    {
        transform.Rotate(0, 30 * Time.deltaTime, 0);
    }

    void OnDestroy()
    {
        sequence.Kill();
    }
}
