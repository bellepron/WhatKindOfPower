using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTypes : MonoBehaviour    // Arrowdan harita devamına ekleme sayısı 1'e iner.
{
    public static AttackTypes Instance;
    Detector detector;
    SwitchWeapon switchWeapon;
    float angle_Y;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        detector = transform.GetChild(3).GetComponent<Detector>();
        switchWeapon = GetComponent<SwitchWeapon>();
    }

    #region Equips
    public void Stickman_Attack()
    {
        Debug.Log("Stickman attack called");
    }
    public void Archer_Attack()
    {
        Archer_();
        StartCoroutine(DelayedArcher(angle_Y));
    }
    void Archer_()
    {
        detector.coolDown = Globals.archer_cd;
        Debug.Log("Archer attack called");
        switchWeapon.animator.SetTrigger("attack");
        angle_Y = detector.targetPosition.x - transform.position.x;
        transform.rotation = Quaternion.Euler(new Vector3(0, angle_Y, 0));
    }
    public void Knight_Attack()
    {
        detector.coolDown = Globals.knight_cd;
        Debug.Log("Knight attack called");
        switchWeapon.animator.SetTrigger("attack");
        float angle_Y = detector.targetPosition.x - transform.position.x;
        StartCoroutine(DelayedKnight(angle_Y));
    }
    public void GreatSworder_Attack()
    {
        detector.coolDown = Globals.greatSworder_cd;
        Debug.Log("Great Sworder attack called");
        switchWeapon.animator.SetTrigger("attack");
        float angle_Y = detector.targetPosition.x - transform.position.x;
        StartCoroutine(DelayedGreatSworder(angle_Y));
    }
    public void Wizard_Attack()
    {
        Wizard_();
        StartCoroutine(DelayedWizard(angle_Y));
    }
    void Wizard_()
    {
        detector.coolDown = Globals.wizard_cd;
        Debug.Log("Wizard attack called");
        switchWeapon.animator.SetTrigger("attack");
        float angle_Y = detector.targetPosition.x - transform.position.x;
        transform.rotation = Quaternion.Euler(new Vector3(0, angle_Y, 0));
    }
    public void Soldier_Attack()
    {
        detector.coolDown = Globals.soldier_cd;
        Debug.Log("Soldier attack called");
        switchWeapon.animator.SetTrigger("attack");
        float angle_Y = detector.targetPosition.x - transform.position.x;
        transform.rotation = Quaternion.Euler(new Vector3(0, angle_Y, 0));
        StartCoroutine(DelayedSoldier(angle_Y));
    }

    #endregion

    IEnumerator DelayedArcher(float angleY)
    {
        yield return new WaitForSeconds(0.4f);
        float angle_Y = detector.targetPosition.x - transform.position.x;
        ArrowQuantity(angleY);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }
    IEnumerator DelayedKnight(float angleY)
    {
        yield return new WaitForSeconds(0.4f);
        float angle_Y = detector.targetPosition.x - transform.position.x;
        GameObject swordEffect = Instantiate(Resources.Load("Sword Effect"), transform.position + new Vector3(0, 4, 5), Quaternion.Euler(new Vector3(-6, angleY, 0))) as GameObject;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }
    IEnumerator DelayedGreatSworder(float angleY)
    {
        yield return new WaitForSeconds(0.4f);
        float angle_Y = detector.targetPosition.x - transform.position.x;
        GameObject swordEffect = Instantiate(Resources.Load("GreatSword Effect"), transform.position + new Vector3(0, 4, 5), Quaternion.Euler(new Vector3(-6, angleY, 0))) as GameObject;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }
    IEnumerator DelayedWizard(float angleY)
    {
        yield return new WaitForSeconds(0.4f);
        float angle_Y = detector.targetPosition.x - (transform.position.x + 1.4f);
        GameObject arrow = Instantiate(Resources.Load(Globals.magicLocation), transform.position + new Vector3(1.4f, 5, 2), Quaternion.Euler(-4, angleY, 0)) as GameObject;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }
    IEnumerator DelayedSoldier(float angleY)
    {
        yield return new WaitForSeconds(0.05f);
        float angle_Y = detector.targetPosition.x - (transform.position.x + 1.4f);
        GameObject arrow = Instantiate(Resources.Load("Bullet"), transform.position + new Vector3(1.4f, 5, 3), Quaternion.Euler(-3, angleY, 0)) as GameObject;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }


    private void OnDisable()
    {
        Destroy(Instance);
    }


    #region Archer Arrow Quantity ~~~~~~~~~~~~~

    void ArrowQuantity(float angleY)
    {
        if (Globals.arrowQuantity == 1)
        {
            GameObject arrow0;
            arrow0 = Instantiate(Resources.Load(Globals.arrowLocation), transform.position + new Vector3(0, 4, 0), Quaternion.Euler(new Vector3(-6, angleY, 0))) as GameObject;
        }
        if (Globals.arrowQuantity == 2)
        {
            GameObject arrow0;
            GameObject arrow1;
            arrow0 = Instantiate(Resources.Load(Globals.arrowLocation), transform.position + new Vector3(0, 4, 0), Quaternion.Euler(new Vector3(-6, angleY + 1, 0))) as GameObject;
            arrow1 = Instantiate(Resources.Load(Globals.arrowLocation), transform.position + new Vector3(0, 4, 0), Quaternion.Euler(new Vector3(-6, angleY - 1, 0))) as GameObject;
        }
        if (Globals.arrowQuantity == 3)
        {
            GameObject arrow0;
            GameObject arrow1;
            GameObject arrow2;
            arrow0 = Instantiate(Resources.Load(Globals.arrowLocation), transform.position + new Vector3(0, 4, 0), Quaternion.Euler(new Vector3(-6, angleY, 0))) as GameObject;
            arrow1 = Instantiate(Resources.Load(Globals.arrowLocation), transform.position + new Vector3(0, 4, 0), Quaternion.Euler(new Vector3(-6, angleY + 1, 0))) as GameObject;
            arrow2 = Instantiate(Resources.Load(Globals.arrowLocation), transform.position + new Vector3(0, 4, 0), Quaternion.Euler(new Vector3(-6, angleY - 1, 0))) as GameObject;
        }
        if (Globals.arrowQuantity == 4)
        {
            GameObject arrow0;
            GameObject arrow1;
            GameObject arrow2;
            GameObject arrow3;
            arrow0 = Instantiate(Resources.Load(Globals.arrowLocation), transform.position + new Vector3(0, 4, 0), Quaternion.Euler(new Vector3(-6, angleY + 0.5f, 0))) as GameObject;
            arrow1 = Instantiate(Resources.Load(Globals.arrowLocation), transform.position + new Vector3(0, 4, 0), Quaternion.Euler(new Vector3(-6, angleY + 1.5f, 0))) as GameObject;
            arrow2 = Instantiate(Resources.Load(Globals.arrowLocation), transform.position + new Vector3(0, 4, 0), Quaternion.Euler(new Vector3(-6, angleY - 1.5f, 0))) as GameObject;
            arrow3 = Instantiate(Resources.Load(Globals.arrowLocation), transform.position + new Vector3(0, 4, 0), Quaternion.Euler(new Vector3(-6, angleY - 0.5f, 0))) as GameObject;
        }
    }

    #endregion

}
