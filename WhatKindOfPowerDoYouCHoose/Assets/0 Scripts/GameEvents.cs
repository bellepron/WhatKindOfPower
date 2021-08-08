using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEvents : MonoBehaviour
{
    public static UnityEvent m_MyEquip;

    void Start()
    {
        m_MyEquip = new UnityEvent();
    }
}