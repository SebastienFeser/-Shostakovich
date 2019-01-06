using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public enum DialogState
    {
        NONE,
        CONTINUE,
        FINISH,
    }


    [SerializeField] private GameObject dialogWindow;
    [SerializeField] private GameObject letter;
    public GameObject Letter
    {
        get { return letter; }
        set { letter = value; }
    }
    
    [SerializeField] private static UIManager instance;
    public static UIManager Instance => instance;

    private DialogState currentDialogState = DialogState.NONE;
    public DialogState CurrentDialogState => currentDialogState;
    private int indexDialog = 0;
    private string[] currentDialog; 
    [SerializeField] private PlayerTest scriptPlayer;
    private List<string[]> waitingDialogList = new List<string[]>();
    public List<string[]> WaitingDialogList
    {
        get { return waitingDialogList; }
        set { waitingDialogList = value; }
    }


    void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        instance = this;
        scriptPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerTest>();
        scriptPlayer.enabled = false;
        scriptPlayer.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact") && !scriptPlayer.enabled)
        {
            InteractionTest();
        }
    }

    public void InteractionTest()
    {
        switch (currentDialogState)
        {
            case (DialogState.CONTINUE):
            {
                if (currentDialog[indexDialog] == "$letter$")
                {
                    UIManager.Instance.Letter.SetActive(true);
                }

                ShowDialog(currentDialog);
                
                break;
            }
            case (DialogState.FINISH):
            {
                dialogWindow.SetActive(false);
                currentDialogState = DialogState.NONE;
                scriptPlayer.enabled = true;
                if (waitingDialogList.Count > 0)
                {
                    ShowDialog(waitingDialogList[0]);
                    waitingDialogList.RemoveAt(0);
                }

                break;

            }
        }
    }


    public void ShowDialog(string[] text)
    {
        scriptPlayer.enabled = false;
        dialogWindow.SetActive(true);
        dialogWindow.GetComponentInChildren<TextMeshProUGUI>().text = text[indexDialog];
        indexDialog++;
        if (text.Length > indexDialog)
        {
            currentDialog = text;
            currentDialogState = DialogState.CONTINUE;
        }
        else
        {
            indexDialog = 0;
            currentDialog = null;
            currentDialogState = DialogState.FINISH;
        }
    }
}
