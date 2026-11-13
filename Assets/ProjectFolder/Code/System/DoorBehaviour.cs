using TMPro;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    [SerializeField] private DoorType type;
    [SerializeField] private int number;
    [SerializeField] private TextMeshProUGUI text;
    private bool canStart;
    public void StartBehaviour(DoorType type, int number) 
    {
        this.type = type;
        this.number = number;
        canStart = true;

        Debug.LogWarning("Se inicializo correctamente la puerta");
    }
    public void FinishBehaviour() 
    {
        canStart = false;
        type = DoorType.Fake;
        number = -1;
    }
    private void ShowNumber() => text.SetText(number.ToString());
    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (!collision.CompareTag("Player") || !canStart) return;
        ShowNumber();
        DoorManager.Instance.CompareNumber(number, type);
    }
}
