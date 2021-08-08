using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillAdder_Knight : MonoBehaviour
{
    public enum AddType { FireSowrd, BlackSword, ForceSword, AttackSpeed }
    [SerializeField] AddType addType;
    GameObject fireSword, blackSword;

    void Start()
    {
        if (addType == AddType.FireSowrd)
        {
            transform.GetChild(0).GetComponent<TextMesh>().text = "Fire";
        }
        if (addType == AddType.BlackSword)
        {
            transform.GetChild(0).GetComponent<TextMesh>().text = "Black";
        }
        if (addType == AddType.ForceSword)
        {
            transform.GetChild(0).GetComponent<TextMesh>().text = "Force";
        }
        if (addType == AddType.AttackSpeed)
        {
            transform.GetChild(0).GetComponent<TextMesh>().text = "Speed";
        }

        fireSword = SwitchWeapon.Instance.arsenal[2].equipments[0].transform.GetChild(5).gameObject;
        blackSword = SwitchWeapon.Instance.arsenal[2].equipments[0].transform.GetChild(6).gameObject;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<AttackTypes>() == null) return;
        if (other.GetComponent<AttackTypes>() != null)
        {
            if (Globals.sword_Index == 0)
            {
                fireSword.SetActive(false);
                blackSword.SetActive(false);
            }
            if (Globals.sword_Index == 1)
            {
                blackSword.SetActive(false);
            }
            if (Globals.sword_Index == 2)
            {
                fireSword.SetActive(false);
            }

            if (addType == AddType.FireSowrd)
            {
                Globals.sword_Index = 1;
                fireSword.SetActive(true);
            }
            if (addType == AddType.BlackSword)
            {
                Globals.sword_Index = 2;
                blackSword.SetActive(true);
            }
            if (addType == AddType.ForceSword)
            {
                // Globals.arrowLocation = "Arrows/FireArrow";
            }
            if (addType == AddType.AttackSpeed)
            {
                Globals.knight_cd /= 3;
            }
        }
    }
}
