using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : SingletonMonoBehaviour<ScoreManager>
{
    private const string AUDIO_POINT = "Point";

    [Header("UI")]
    [SerializeField] private TMP_Text scoreTxt;
    private int score = 0;

    public void IncreaseScore()
    {
        score++;
        scoreTxt.text = score.ToString();
        AudioManager.Instance.PlayAudio(AUDIO_POINT);
    }
}
