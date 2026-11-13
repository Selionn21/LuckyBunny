using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;
[DefaultExecutionOrder(-500)]
public class DoorManager : MonoBehaviour
{
    [SerializeField] private List<DoorMinigame> events;    
    [SerializeField] private int actualNumber;
    [SerializeField] private UnityEvent gameCompleted;
    private int actualIndex = 0;
    public static DoorManager Instance;
    private void Awake() => Instance = this;
    private void Start() => StartGame();
    private void StartGame() => actualNumber = events[actualIndex].StartMinigame();    
    private void FinishGame() => events[actualIndex].FinishMinigame();
    public void CompareNumber(int number, DoorType type) 
    {
        if (actualNumber != number || type != DoorType.Real) return;
        NextPhase();
    }
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
        gameCompleted?.Invoke();
    }
}
