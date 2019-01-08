using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject continueButton;

    // Start is called before the first frame update
    void Start()
    {
        if (!File.Exists(Application.streamingAssetsPath + "/SaveData.json"))
        {
            continueButton.GetComponent<Button>().interactable = false;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ContinueButton()
    {
        SceneManager.LoadScene("Luca");
    }

    public void NewGameButton()
    {
         StreamWriter sw = File.CreateText(Application.streamingAssetsPath + "/SaveData.json");
         sw.Write("");
         sw.Close();
        SceneManager.LoadScene("Luca");
    }
}
