using TMPro;
using UnityEngine;

public class KillCounterUI : MonoBehaviour
{
    public TMP_Text killText;
    private int killCount = 0;

    void OnEnable()
    {
        KillEventManager.Instance.OnKill += UpdateKillCount;
    }

    void OnDisable()
    {
        if (KillEventManager.Instance != null)
            KillEventManager.Instance.OnKill -= UpdateKillCount;
    }

    void UpdateKillCount()
    {
        killCount++;
        killText.text = "Kills: " + killCount;
    }
}
