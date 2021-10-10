using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [Header("UI components")]
    public GameObject GameOverUIContainer;
    public Text RestartText;

    [Header("Events")]
    public PlayerEvents PlayerEvents;
    public GameEvents GameEvents;
    public InputControlsSystem InputControlsSystem;

    [Header("Restart Text Animation")]
    public float BlinkStepInSeconds = 0.5f;

    private void Start()
    {
        PlayerEvents.PlayerDied += Open;
        InputControlsSystem.MenuStartEvent += Restart;
    }

    private IEnumerator RestartTextAnimation()
    {
        for (;;)
        {
            Color newColor = RestartText.color;
            newColor.a = newColor.a == 0 ? 1 : 0;
            RestartText.color = newColor;

            yield return new WaitForSeconds(BlinkStepInSeconds);
        }
    }

    private void Open()
    {
        GameOverUIContainer.SetActive(true);
        StartCoroutine(RestartTextAnimation());
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameOverUIContainer.SetActive(false);
        StopAllCoroutines();
        GameEvents.InvokeGameStarted();
    }
}
