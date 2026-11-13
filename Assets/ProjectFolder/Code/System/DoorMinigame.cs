using System;
using UnityEngine;
[Serializable]
public class DoorMinigame
{
    [HideInInspector] public string name = "MiniGame";
    public int bonusTime;
    public int maxNumber;
    public int luckyNumber;
    public GameObject limit;
    public DoorBehaviour[] doors;
    public int StartMinigame() 
    {
        luckyNumber = UnityEngine.Random.Range(0, maxNumber);
        int randomDoor = UnityEngine.Random.Range(0, doors.Length);

        if(limit != null)
        limit.SetActive(true);

        for (int i = 0; i < doors.Length; i++) 
        {
            if (i == randomDoor) 
            {
                doors[i].StartBehaviour(DoorType.Real, luckyNumber);
                continue;
            }
            int randomWrongNumber = GetRandomWrongNumber();
            doors[i].StartBehaviour(DoorType.Fake, randomWrongNumber);
        }

        return luckyNumber;
    }
    private int GetRandomWrongNumber() 
    {
        int randomWrongNumber = UnityEngine.Random.Range(0, maxNumber);
        while (randomWrongNumber == luckyNumber) 
            randomWrongNumber = UnityEngine.Random.Range(0, maxNumber);

        return randomWrongNumber;        
    }
    public void FinishMinigame() 
    {
        if(limit != null)
        limit.SetActive(false);

        foreach (var door in doors)
            door.FinishBehaviour();
    }
}
