using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;
using System;
[DefaultExecutionOrder(-500)]
public class DoorManager : MonoBehaviour
{
    [SerializeField] private float initialTime;
    [SerializeField] private List<DoorMinigame> events;    
    [SerializeField] private int actualNumber;
    [SerializeField] private UnityEvent gameCompleted;
    [SerializeField] private UnityEvent gameFail;
    public event Action<float> UpdateTimeUI;
    public event Action stopTimeUI;
    private int actualIndex = 0;
    private bool gameover;
    public static DoorManager Instance;
    private void Awake() => Instance = this;
    private void Start()
    {
        UpdateTimeUI?.Invoke(initialTime);
        StartGame();
    }
    private void StartGame() => actualNumber = events[actualIndex].StartMinigame();    
    private void FinishGame() => events[actualIndex].FinishMinigame();
    public void GameFailed()
    {
        if (gameover) return;
        gameover = true;
        stopTimeUI?.Invoke();
        gameFail?.Invoke();
    }
    public void CompareNumber(int number, DoorType type) 
    {
        if (actualNumber != number || type != DoorType.Real) return;
        MinigameCompleted();
        NextPhase();
    }
    private void MinigameCompleted() => UpdateTimeUI?.Invoke(events[actualIndex].bonusTime);
    private void NextPhase() 
    {
        if (actualIndex >= events.Count - 1) 
        {
            GameCompleted();
            return;
        }
        FinishGame();
        actualIndex++;
        StartGame();
    }
    private void GameCompleted()
    {
        FinishGame();
        stopTimeUI?.Invoke();
        gameCompleted?.Invoke();
    }
}
