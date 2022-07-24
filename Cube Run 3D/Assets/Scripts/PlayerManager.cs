using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public Leaderboard leaderboard;
    public InputField playernameInput;
    public GameObject SetNameFirstUI;

    void Start()
    {
        StartCoroutine(LoginRoutine());
        StartCoroutine(SetupRoutine());
        if (PlayerPrefs.GetString("PlayerName", "") == ""){
            StartCoroutine(FirstSetName());
        }
    }

    public void SetPlayerName(){
        FindObjectOfType<AudioManager>().Play("UI");
        if (playernameInput.text != ""){
            LootLockerSDKManager.SetPlayerName(playernameInput.text, (response)=>{
            if(response.success){
                Debug.Log("Succesfully set name");
                PlayerPrefs.SetString("PlayerName", playernameInput.text);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else {
                Debug.Log("Set Name error: " + response.Error);
            }
        });
        }
    }

    IEnumerator FirstSetName(){
        yield return new WaitForSeconds(3f);

        if (PlayerPrefs.GetString("NameSet", "false") != "true"){
            SetNameFirstUI.SetActive(true);
            PlayerPrefs.SetString("NameSet", "true");
        }
    }

    public void Menu(){
        FindObjectOfType<AudioManager>().Play("UI");
        SceneManager.LoadScene("Menu");
    }

    IEnumerator SetupRoutine(){
        yield return LoginRoutine();
        yield return leaderboard.FetchTopHighscoresRoutine();
    }

    IEnumerator LoginRoutine(){
        bool done = false;
        LootLockerSDKManager.StartGuestSession((response) => {
            if (response.success){
                Debug.Log("Player Logged In");
                PlayerPrefs.SetString("PlayerID", response.player_id.ToString());
                done = true;
            }
            else {
                Debug.Log("Player not Logged In");
                done = true;
            }
        });
        yield return new WaitWhile(()=> done == false);
    }
}
