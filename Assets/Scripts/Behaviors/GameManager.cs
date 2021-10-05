using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton

    public static GameManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Only one instance of GameManager should be present in the scene!");
            return;
        }

        instance = this;
    }

    #endregion
}
