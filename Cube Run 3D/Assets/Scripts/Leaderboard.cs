using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Leaderboard : MonoBehaviour
{
    public int ID;
    public Text[] playerNames;
    public Text[] playerScores;
    public InputField playernameInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public IEnumerator SubmitScoreRoutine(){
        int scoreToUpload = PlayerPrefs.GetInt("Highscore", 0);
        bool done = false;
        string playerID = PlayerPrefs.GetString("PlayerID");
        LootLockerSDKManager.SubmitScore(playerID, scoreToUpload, ID, (response)=>{
            if (response.success){
                Debug.Log("Score Uploaded");
                done = true;
            }
            else {
                Debug.Log("Failed: " + response.Error);
                done = true;
            }
        });
        yield return new WaitWhile(()=> done == false);
    }

    public IEnumerator FetchTopHighscoresRoutine(){
        bool done = false;
        if (PlayerPrefs.GetString("PlayerName") != ""){
            playernameInput.placeholder.GetComponent<Text>().text = PlayerPrefs.GetString("PlayerName");
        }
        LootLockerSDKManager.GetScoreList(ID, 10, 0, (response)=>{
            if (response.success){
                
                LootLockerLeaderboardMember[] members = response.items;

                for (int i = 0; i < members.Length; i++){
                    string PlayerName = "";
                    string PlayerScore = "";
                    if (members[i].player.name != ""){
                        PlayerName += members[i].player.name;
                    }
                    else {
                        PlayerName += "Player" + members[i].player.id;
                    }
                    if (members[i].score > 999999999){
                        PlayerScore += "999999999";
                    }
                    else{
                        PlayerScore += members[i].score.ToString();
                    }
                    playerNames[i].text = PlayerName;
                    playerScores[i].text = PlayerScore;
                }
                done = true;
            }
            else {
                Debug.Log("Failed fetching: " + response.Error);
                done = true;
            }
        });
        yield return new WaitWhile(()=> done == false);
    }
}
