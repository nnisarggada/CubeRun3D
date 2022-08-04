using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class UpdateChecker : MonoBehaviour
{
    public float currentVersion;
    public GameObject UpdateUI;

    IEnumerator Start(){

        UnityWebRequest LastestVersion = UnityWebRequest.Get("http://nnisarg.xyz/CubeRun3D/LatestVersion.txt");
        yield return LastestVersion.SendWebRequest();
        String update = LastestVersion.downloadHandler.text;

        if (LastestVersion.error != null){
            UpdateUI.SetActive(false);
        }
        else {
            if(update != Convert.ToString(currentVersion)){
            if (!Boot.UpdateUIShown){
                Boot.UpdateUIShown = true;
                UpdateUI.SetActive(true);
                }
            }
        }
    }

    public void Okay(){
        FindObjectOfType<AudioManager>().Play("UI");
        UpdateUI.SetActive(false);
    }
}