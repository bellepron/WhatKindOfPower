using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class InputHandler : MonoBehaviour, IEndGameObserver
{
    // Init
    public static InputHandler Instance;

    public GameObject actor; Rigidbody rb; CapsuleCollider col;

    // Control
    private float m_previousX;
    public float deltaX = 0;
    public float sensivity = 20f;

    // Move Forward
    public float runSpeed = 10f;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        rb = actor.GetComponent<Rigidbody>();
        col = actor.GetComponent<CapsuleCollider>();
        SwitchWeapon.Instance.animator.Rebind();
        GameManager.Instance.AddObserver(this);
    }

    void Update()
    {
        if (Globals.isGameActive)
        {
            transform.position = actor.transform.position;

            Control();

            if (!Globals.isGameFinished) MoveForward(runSpeed);

            // if (Globals.isGameFinished && !danceTriggered)
            // {
            //     danceTriggered = true;
            //     SwitchWeapon.Instance.animator.SetTrigger("dance");
            // }
        }
    }

    #region Control
    private void Control()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_previousX = Input.mousePosition.x;
            deltaX = 0;
        }

        if (Input.GetMouseButton(0))
        {
            deltaX = (Input.mousePosition.x - m_previousX) * 5;

            if (deltaX < 0)
                actor.transform.position -= new Vector3(sensivity * Time.deltaTime, 0, 0);
            if (deltaX > 0)
                actor.transform.position += new Vector3(sensivity * Time.deltaTime, 0, 0);
        }

        if (Input.GetMouseButtonUp(0))
        {
            deltaX = 0;
        }
    }
    #endregion

    #region Move Forward
    public void MoveForward(float _runSpeed)
    {
        // actor.transform.position += new Vector3(0, 0, _runSpeed * Time.deltaTime);
        actor.transform.Translate(0, 0, _runSpeed * Time.deltaTime);
    }
    #endregion



    // private void OnDisable()
    // {
    //     Destroy(Instance);
    // }

    public void GameEnd()
    {
        SwitchWeapon.Instance.animator.SetTrigger("dance");
        GameManager.Instance.RemoveObserver(this);
    }
}
