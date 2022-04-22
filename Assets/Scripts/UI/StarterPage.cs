using UnityEngine;
using UnityEngine.UI;

public class StarterPage : GameUI<StarterPage>
{
    [SerializeField] private Button startBtn;
    private void Start() => startBtn.onClick.AddListener(GameManager.Instance.StartGame);
}
