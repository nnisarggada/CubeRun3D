using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boot : MonoBehaviour
{
    public static bool UpdateUIShown;
    void Start()
    {
        UpdateUIShown = false;
        SceneManager.LoadScene("Menu");
    }
}
