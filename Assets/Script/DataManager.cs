using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

using System.Runtime.Serialization.Formatters.Binary;

public class DataManager : MonoBehaviour
{

    private static DataManager _Instance = null;

    public static DataManager instance { get { return _Instance; } }

    public int playerHP = 3;
    public string currentScene = "Level 1";
    private void Awake()
    {
        _Instance = this;
    }
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        Load();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SaveData()
    {
        SaveData saveData = new SaveData();
        saveData.sceneName = currentScene;
        saveData.playerHP = playerHP;

        FileStream fileStream = File.Create(Application.persistentDataPath + "/save.dat");

        Debug.Log("저장 파일 생성");

        BinaryFormatter binaryFormatter = new BinaryFormatter();
        binaryFormatter.Serialize(fileStream, saveData);

        fileStream.Close();
    }

    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/save.dat"))
        {
            FileStream fileStream = File.Open(Application.persistentDataPath + "/save.dat", FileMode.Open);

            if(fileStream != null && fileStream.Length > 0)
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                SaveData saveData = (SaveData)binaryFormatter.Deserialize(fileStream);
                playerHP = saveData.playerHP;
                UIMAnager.instance.PlayerHP();
                currentScene = saveData.sceneName;

                fileStream.Close();
            }
        }
    }
}
