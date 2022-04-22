using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI<T> : SingletonMonoBehaviour<T> where T: GameUI<T>
{
    public GameObject pageRoot;
    public void Show() => pageRoot.SetActive(true);
    public void Hide() => pageRoot.SetActive(false);
}
