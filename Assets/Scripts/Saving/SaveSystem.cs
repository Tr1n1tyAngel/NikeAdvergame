
using UnityEngine;
using System.IO;

public static class SaveSystem
{
    public static void SavePlayerData(GameManager gameManager)
    {
        PlayerData data = new PlayerData(gameManager);
        string json = JsonUtility.ToJson(data);
        Debug.Log("Saving data: " + json); // Debug line

        string path = Application.persistentDataPath + "/playerData.NikeAdvergameSave";
        File.WriteAllText(path, json);
        Debug.Log("Data saved to: " + path); // Debug line
    }

    public static PlayerData LoadPlayerData()
    {
        string path = Application.persistentDataPath + "/playerData.NikeAdvergameSave";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Debug.Log("Loaded data: " + json); // Debug line

            PlayerData data = JsonUtility.FromJson<PlayerData>(json);
            return data;
        }
        else
        {
            Debug.LogError("No save file available");
            return null;
        }
        
    }
}