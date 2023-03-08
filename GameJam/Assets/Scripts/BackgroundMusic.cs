using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private static BackgroundMusic bgm;
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
