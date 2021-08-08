using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillAdder_Wizard : MonoBehaviour
{
    public enum AddType { FireMagic, BlackMagic, ElectricMagic, AttackSpeed }
    [SerializeField] AddType addType;
    void Start()
    {
        if (addType == AddType.FireMagic)
        {
            transform.GetChild(0).GetComponent<TextMesh>().text = "Fire";
        }
        if (addType == AddType.BlackMagic)
        {
            transform.GetChild(0).GetComponent<TextMesh>().text = "Black";
        }
        if (addType == AddType.ElectricMagic)
        {
            transform.GetChild(0).GetComponent<TextMesh>().text = "Electric";
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

            if (addType == AddType.FireMagic)
            {
                Globals.magicLocation = "Magics/FireMagic";
            }
            if (addType == AddType.BlackMagic)
            {
                Globals.magicLocation = "Magics/BlackMagic";
            }
            if (addType == AddType.ElectricMagic)
            {
                Globals.magicLocation = "Magics/ElectricMagic";
            }
            if (addType == AddType.AttackSpeed)
            {
                Globals.archer_cd /= 3;
            }
        }
    }
}
