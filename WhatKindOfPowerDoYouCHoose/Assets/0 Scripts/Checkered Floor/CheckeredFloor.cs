using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckeredFloor : MonoBehaviour, IEndGameObserver
{
    void Start()
    {
        GameManager.Instance.AddObserver(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<SwitchWeapon>() != null)
        {
            // Game Finished
            GameManager.Instance.NotifyObservers();
        }
    }

    public void GameEnd()
    {
        Globals.isGameFinished = true; // To do : remove this
        GameManager.Instance.ActivateRestartButton();
    }
}
