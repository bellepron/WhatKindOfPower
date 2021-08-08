using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillAdder_Archer : MonoBehaviour
{
    public enum AddType { TripleShot, BlackShot, FireShot, AttackSpeed }
    [SerializeField] AddType addType;
    void Start()
    {
        if (addType == AddType.TripleShot)
        {
            transform.GetChild(0).GetComponent<TextMesh>().text = "Extra";
        }
        if (addType == AddType.BlackShot)
        {
            transform.GetChild(0).GetComponent<TextMesh>().text = "Black";
        }
        if (addType == AddType.FireShot)
        {
            transform.GetChild(0).GetComponent<TextMesh>().text = "Fire";
        }
        if (addType == AddType.AttackSpeed)
        {
            transform.GetChild(0).GetComponent<TextMesh>().text = "Speed";
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<AttackTypes>() == null) return;
        if (other.GetComponent<AttackTypes>() != null)
        {
            //GameEvents.m_MyEquip.RemoveAllListeners();

            if (addType == AddType.TripleShot)
            {
                Globals.arrowQuantity++;
                Debug.Log(Globals.arrowQuantity);
            }
            if (addType == AddType.BlackShot)
            {
                Globals.arrowLocation = "Arrows/BlackArrow";
            }
            if (addType == AddType.FireShot)
            {
                Globals.arrowLocation = "Arrows/FireArrow";
            }
            if (addType == AddType.AttackSpeed)
            {
                Globals.archer_cd /= 3;
            }
        }
    }
}
