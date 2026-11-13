using UnityEngine;
using System.Collections.Generic;
[DefaultExecutionOrder(-500)]
public class DoorManager : MonoBehaviour
{
    [SerializeField] private GameObject doorPrefab;
    [SerializeField] private List<DoorMinigame> events;    
    [SerializeField] private int actualNumber;
    private int actualIndex = 0;
    public static DoorManager Instance;
    private void Awake() => Instance = this;
    private void Start() => events[actualIndex].StartMinigame();
    public void CompareNumber(int number) 
    {
        if (actualNumber != number) return;
        NextPhase();
    }
    private void NextPhase() 
    {
        if (actualIndex >= events.Count - 1) return;
        events[actualIndex].StartMinigame();
        actualIndex++;
        events[actualIndex].FinishMinigame();
    }
}
