using UnityEngine;
using TMPro;

public class Stopwatch : MonoBehaviour
{
    private static Stopwatch instance;
    public TextMeshProUGUI timerText;  // TextMeshPro bileşenini buraya sürükle
    private float elapsedTime = 0f;
    private bool isRunning = true;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
    }
    void Start()
    {
        elapsedTime = 0f;
        isRunning = true;
    }

    void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;

            // Geçen zamanı gün:saat:dakika:saniye formatında ayarla
            int days = Mathf.FloorToInt(elapsedTime / 86400); // 1 gün = 86400 saniye
            int hours = Mathf.FloorToInt((elapsedTime % 86400) / 3600);
            int minutes = Mathf.FloorToInt((elapsedTime % 3600) / 60);
            int seconds = Mathf.FloorToInt(elapsedTime % 60);

            // TextMeshPro'ya yazdır
            timerText.text = days.ToString("00") + ":" + hours.ToString("00") + ":" + minutes.ToString("00") + ":" + seconds.ToString("00");
        }
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public void StartTimer()
    {
        isRunning = true;
    }
}
