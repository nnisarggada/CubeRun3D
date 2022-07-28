using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpdateChecker : MonoBehaviour
{
    public float currentVersion;
    public GameObject UpdateUI;

    IEnumerator Start(){

        WWW LastestVersion = new WWW ("http://nnisarg.xyz/CubeRun3D/LatestVersion.txt");
        yield return LastestVersion;
        String update = LastestVersion.text;

        if (update == ""){
            UpdateUI.SetActive(false);
        }

        if(update != Convert.ToString(currentVersion)){
            if (!Boot.UpdateUIShown){
                Boot.UpdateUIShown = true;
                UpdateUI.SetActive(true);
            }
        }

    }

    public void Okay(){
        FindObjectOfType<AudioManager>().Play("UI");
        UpdateUI.SetActive(false);
    }
}