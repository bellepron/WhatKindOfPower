using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] GameObject startButton;
    [SerializeField] GameObject restartButton;
    [SerializeField] GameObject nextLevelButton;
    [SerializeField] GameObject winText;
    [SerializeField] GameObject loseText;
    // [SerializeField] GameObject endGamePanel;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        endGameObservers = new List<IEndGameObserver>();
    }

    void Start()
    {
        startButton.SetActive(true);
        // chooseButtons.SetActive(false);
        winText.SetActive(false);
        loseText.SetActive(false);
        // Globals.isFinished = false; // Gerekti.
        // Debug.Log(Globals.isFinished);
        restartButton.SetActive(false);
        nextLevelButton.SetActive(false);
        // // evnironments[Globals.levelIndex].SetActive(true); 
        // endGamePanel.SetActive(false);
        // Globals.levelIndex = SceneManager.GetActiveScene().buildIndex;

    }

    public void StartButton()
    {
        startButton.SetActive(false);
        Globals.isGameActive = true;
        InputHandler.Instance.actor.GetComponent<Animator>().SetTrigger("start");
        GetComponent<GameSceneController>().Spawn_SpawnManager();
    }
    public void ActivateRestartButton()
    {
        restartButton.SetActive(true);
    }
    public void RestartButton()
    {
        Globals.isGameActive = false;
        Globals.isGameFinished = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void NextLevel()
    {
        RestartButton();
        // if (Globals.levelIndex == SceneManager.sceneCountInBuildSettings - 1)
        //     Globals.levelIndex = 0;
        // else if (Globals.levelIndex < SceneManager.sceneCountInBuildSettings - 1)
        //     Globals.levelIndex = SceneManager.GetActiveScene().buildIndex + 1;

        // Globals.isGameActive = false; Globals.isFinished = false; Globals.winOrLose = false; Globals.scissorsIndex = 0; Globals.pointMultiplier = 0; Globals.coin_Point = 0;

        // SceneManager.LoadScene(Globals.levelIndex);
    }





    #region TEST ~ğ~ğ~ğ~ğ~ğ
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            NotifyObservers();
        }
    }
    #endregion





    #region Observer Funcs
    private List<IEndGameObserver> endGameObservers;

    // void Awake()
    // {
    //     endGameObservers = new List<IEndGameObserver>();
    // }

    public void AddObserver(IEndGameObserver observer)
    {
        endGameObservers.Add(observer);
    }

    public void RemoveObserver(IEndGameObserver observer)
    {
        endGameObservers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (IEndGameObserver observer in endGameObservers.ToArray())
        {
            if (endGameObservers.Contains(observer))
                observer.GameEnd();
        }
    }
    #endregion

}
