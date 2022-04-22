using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkController : MonoBehaviour
{
    [Header("Chuncks")]
    [SerializeField] private Transform[] chunks;
    [Header("Chunck Movement")]
    [SerializeField] private float movementSpeed;
    [Header("Chunck Start & End Point")]
    [SerializeField] private float startPoint;
    [SerializeField] private float endPoint;

    private void Update() => MoveChunks();
    private void MoveChunks()
    {
        for (int i = 0; i < chunks.Length; i++)
        {
            chunks[i].position -= chunks[i].right * movementSpeed * Time.deltaTime;
            if (chunks[i].position.x <= endPoint) chunks[i].position = new Vector2(startPoint, chunks[i].position.y);
        }
    }
}
