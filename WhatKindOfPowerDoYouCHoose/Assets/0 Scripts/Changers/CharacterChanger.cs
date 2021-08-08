using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChanger : MonoBehaviour
{
    public enum CharacterType { Stickman, Archer, Knight, GreatSworder, Wizard, Soldier }
    public CharacterType characterType = CharacterType.Archer;
    AttackTypes attackTypes;
    GameObject changeParticle;

    private void Start()
    {
        attackTypes = AttackTypes.Instance;
    }


    #region Collision With Character
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<SwitchWeapon>() != null)
        {
            SwitchWeapon.Instance.SetArsenal(characterType.ToString());

            GameEvents.m_MyEquip.RemoveAllListeners();

            if (characterType == CharacterType.Stickman)
            {
                GameEvents.m_MyEquip.AddListener(attackTypes.Stickman_Attack);
                changeParticle = SwitchWeapon.Instance.transform.GetChild(4).gameObject;
            }
            if (characterType == CharacterType.Archer)
            {
                Globals.arrowQuantity = 1;
                GameEvents.m_MyEquip.AddListener(attackTypes.Archer_Attack);
                changeParticle = SwitchWeapon.Instance.transform.GetChild(5).gameObject;
            }
            if (characterType == CharacterType.Knight)
            {
                GameEvents.m_MyEquip.AddListener(attackTypes.Knight_Attack);
                changeParticle = SwitchWeapon.Instance.transform.GetChild(6).gameObject;
            }
            if (characterType == CharacterType.GreatSworder)
            {
                GameEvents.m_MyEquip.AddListener(attackTypes.GreatSworder_Attack);
                changeParticle = SwitchWeapon.Instance.transform.GetChild(7).gameObject;
            }
            if (characterType == CharacterType.Wizard)
            {
                GameEvents.m_MyEquip.AddListener(attackTypes.Wizard_Attack);
                changeParticle = SwitchWeapon.Instance.transform.GetChild(8).gameObject;
            }
            if (characterType == CharacterType.Soldier)
            {
                GameEvents.m_MyEquip.AddListener(attackTypes.Soldier_Attack);
                changeParticle = SwitchWeapon.Instance.transform.GetChild(9).gameObject;
            }

            changeParticle.SetActive(true);
            changeParticle.GetComponent<ParticleSystem>().Play();
            Destroy(gameObject);
        }
    }
    #endregion
}
