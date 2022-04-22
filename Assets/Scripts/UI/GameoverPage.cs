using UnityEngine;
using UnityEngine.UI;

public class GameoverPage : GameUI<GameoverPage>
{
    [SerializeField] private Button restartBtn;
    private void Start() => restartBtn.onClick.AddListener(GameManager.Instance.RestartGame);
}
