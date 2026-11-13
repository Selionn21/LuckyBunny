using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class LevelTime : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    private float currentTime;    
    private void Awake() => text = GetComponent<TextMeshProUGUI>();
    private void OnEnable() => DoorManager.Instance.UpdateTimeUI += UpdateTime;
    private void OnDisable() => DoorManager.Instance.UpdateTimeUI -= UpdateTime;
    private void Update() => RunBehaviour();
    private void RunBehaviour() 
    {
        currentTime -= Time.deltaTime;
        currentTime = Mathf.Clamp(currentTime, 0, float.MaxValue);
        text.SetText(currentTime.ToString("F2"));
        if (currentTime <= 10) 
            text.color = Color.red;
        else
            text.color = Color.black;

        if (currentTime <= 0)
            DoorManager.Instance.GameFailed(); // colocar un GameManager para la derrota
    }
    private void UpdateTime(float time) => currentTime += time;
}
