using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapon : MonoBehaviour
{
    [System.Serializable]
    public struct Arsenal
    {
        public string characterType;
        public GameObject[] equipments;
        public RuntimeAnimatorController controller;
    }

    public static SwitchWeapon Instance;
    public Arsenal[] arsenal;
    [HideInInspector] public Animator animator;
    Detector detector;
    // public AudioClip changingSound;
    // AudioSource audioSource;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        animator = GetComponent<Animator>();
        detector = transform.GetChild(3).GetComponent<Detector>();
        // audioSource = GetComponent<AudioSource>();
        if (arsenal.Length > 0)
            SetArsenal(arsenal[0].characterType);
    }

    #region Set Arsenal
    public void SetArsenal(string name)
    {
        foreach (Arsenal hand in arsenal)
        {
            if (hand.characterType != name)
            {
                foreach (GameObject go in hand.equipments)
                {
                    go.SetActive(false);
                }
            }

            if (hand.characterType == name)
            {
                if (hand.equipments != null)
                {
                    foreach (GameObject go in hand.equipments)
                        go.SetActive(true);
                }
                animator.runtimeAnimatorController = hand.controller;

                detector.UpdateDetectorScaleAndPosition(name);
            }
        }
    }
    #endregion

    private void OnDisable()
    {
        Destroy(Instance);
    }
}