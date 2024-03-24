using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class LoadGameRankScript : MonoBehaviour
{
    public Text bestPlayerName;
    private static int bestScore;
    private static string bestPlayer;

    private void Awake()
    {
        LoadGameRank();
    }

    private void SetBestPlayer()
    {
        if(bestPlayer == null && bestScore == 0) 
        {
            bestPlayerName.text = "";
        }
        else
        {
            bestPlayerName.text = $"bestScore - { bestPlayer}:{bestScore}";
        }  
    }

    public void LoadGameRank()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestScore = data.bestScore;
            bestPlayer = data.bestPlayer;
            SetBestPlayer();
        }
    }

    [System.Serializable]
    class SaveData
    {
        public int bestScore;
        public string bestPlayer;
    }
}
