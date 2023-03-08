using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CoinScript : MonoBehaviour
{


    void OnTriggerEnter(Collider col)
    {
        Destroy(gameObject);
        SceneManager.LoadScene("VictoryScreen");
    }
}
