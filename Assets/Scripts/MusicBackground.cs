using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBackgorund : MonoBehaviour
{
    public static MusicBackgorund Instance;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
