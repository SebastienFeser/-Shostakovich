using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[Serializable]
public class SaveData
{
    public bool doveFlee = false;
    public Caretaker.CaretakerState currentState;
    public Vector3 playerPosition;
    


    public PlayerTest.Orientation currentOrientation;

    public bool exteriorPosition = true;

    public int currentMap = -1;


    public List<string> inventory = new List<string>();
}


public class GameManager : MonoBehaviour
{

    private string fileName;
    private string saveDataJson;


    private SaveData saveDataInstance;
    public SaveData SaveDataInstance
    {
        get { return saveDataInstance; }
        set { saveDataInstance = value; }
    }

    

    [SerializeField] private static GameManager instance;
    public static GameManager Instance => instance;

    void Awake()
    {
        saveDataInstance = new SaveData();
        fileName = Application.streamingAssetsPath + "/SaveData.json";
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            Load();
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Save();
        }
    }

    void Save()
    {
        
        if (File.Exists(fileName))
        {
            saveDataJson = JsonUtility.ToJson(saveDataInstance);
            StreamWriter sw = File.CreateText(fileName);
            sw.Write(saveDataJson);
            sw.Close();
        }
        Debug.Log(saveDataJson);
    }

    private void OnDestroy()
    {
        Save();
    }


    void Load()
    {
        if (File.Exists(fileName))
        {
            saveDataJson = File.ReadAllText(fileName);
            JsonUtility.FromJsonOverwrite(saveDataJson, saveDataInstance);
        }
    }
    
}
