using UnityEngine.SceneManagement;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    private const string AUDIO_DIE = "Die";

    private void Start() => StarterPage.Instance.Show();
    public void StartGame()
    {
        BirdController.Instance.StartMovement();
        ObstacleSpawner.Instance.StartSpawning();
        StarterPage.Instance.Hide();
        GameHUD.Instance.Show();
    }
    public void RestartGame() => SceneManager.LoadSceneAsync(0);
    public void GameOver() 
    {
        AudioManager.Instance.PlayAudio(AUDIO_DIE);
        GameoverPage.Instance.Show(); 
    }
}
