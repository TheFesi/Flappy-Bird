using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : SingletonMonoBehaviour<BirdController>
{
    private const string TAG_GROUND = "Ground";
    private const string TAG_OBSTACLE = "Obstacle";
    private const string TAG_POINT = "Point";
    private const string AUDIO_WING = "Wing";

    [SerializeField] [Range(0f,5f)] private float forceUpValue;
    [SerializeField] private float maxY;
    private float forceMultiply = 100f;
    private Rigidbody2D rb;
    private enum EPlayerStates { Alive, Dead }
    private EPlayerStates currentPlayerState = EPlayerStates.Alive;

    protected override void Awake()
    {
        base.Awake();
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && currentPlayerState == EPlayerStates.Alive) PushUp();
    }
    private void PushUp()
    {
        rb.AddForce(new Vector2(0, forceUpValue * forceMultiply));
        AudioManager.Instance.PlayAudio(AUDIO_WING);
    }
    public void StartMovement() => rb.gravityScale = 1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (currentPlayerState == EPlayerStates.Dead) return;
        if (collision.gameObject.tag == TAG_GROUND || collision.gameObject.tag == TAG_OBSTACLE) 
        {
            currentPlayerState = EPlayerStates.Dead;
            GameManager.Instance.GameOver(); 
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == TAG_POINT && currentPlayerState == EPlayerStates.Alive)
            ScoreManager.Instance.IncreaseScore();
    }
}
