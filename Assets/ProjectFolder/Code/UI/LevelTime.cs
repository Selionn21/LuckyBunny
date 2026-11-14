using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class LevelTime : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    private float currentTime;
    private bool canContinue = true;
    private void Awake() => text = GetComponent<TextMeshProUGUI>();
    private void OnEnable()
    {
        DoorManager.Instance.UpdateTimeUI += UpdateTime;
        DoorManager.Instance.stopTimeUI += StopUI;
    }
    private void OnDisable()
    {
        DoorManager.Instance.UpdateTimeUI -= UpdateTime;
        DoorManager.Instance.stopTimeUI -= StopUI;
    }
    private void Update() => RunBehaviour();
    private void RunBehaviour() 
    {
        if (!canContinue) return;

        currentTime -= Time.deltaTime;
        currentTime = Mathf.Clamp(currentTime, 0, float.MaxValue);
        text.SetText(currentTime.ToString("F2"));
        if (currentTime <= 10) 
            text.color = Color.red;
        else
            text.color = new Color32(227, 192, 121, 255);

        if (currentTime <= 0)
            DoorManager.Instance.GameFailed(); // colocar un GameManager para la derrota
    }
    private void StopUI() => canContinue = false;
    private void UpdateTime(float time) => currentTime += time;
}
