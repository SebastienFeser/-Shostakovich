using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField] private GameObject inventory;

    [SerializeField] private GameObject[] inventoryslot;
    [SerializeField] private Sprite KeyRoom1;
    [SerializeField] private Sprite KeyRoom2;
    [SerializeField] private Sprite KeyRoom3;
    [SerializeField] private Sprite musicSheet1;
    [SerializeField] private Sprite musicSheet2;
    [SerializeField] private Sprite musicSheet3;

    [SerializeField] private Animator endAnimator;

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
                if (currentDialog[indexDialog] == "$end$")
                {
                    End();
                }
                else
                {

                    if (currentDialog[indexDialog] == "$letter$")
                    {
                        UIManager.Instance.Letter.SetActive(true);
                    }


                    ShowDialog(currentDialog);
                }

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

    public void InventoryDisplay(List<string> playerInventory)
    {
        if (inventory.activeSelf)
        {
            inventory.SetActive(false);
            for (int i = 0; i < inventoryslot.Length; i++)
            {
                inventoryslot[i].SetActive(false);
            }
        }
        else
        {
            inventory.SetActive(true);
            foreach (var objectInventory in playerInventory)
            {
                Sprite spriteImage = null;
                if (objectInventory == "KeyRoom1")
                {
                    spriteImage = KeyRoom1;
                } else
                if (objectInventory == "KeyRoom2")
                {
                    spriteImage = KeyRoom2;
                }
                else
                if(objectInventory == "KeyRoom3")
                {
                    spriteImage = KeyRoom3;
                } else
                if (objectInventory == "musicSheet1")
                {
                    spriteImage = musicSheet1;
                }
                else
                if (objectInventory == "musicSheet2")
                {
                    spriteImage = musicSheet2;
                }
                else
                if(objectInventory == "musicSheet3")
                {
                    spriteImage = musicSheet3;
                }

                if (spriteImage)
                {
                    for (int i = 0; i < inventoryslot.Length; i++)
                    {
                        if (!inventoryslot[i].activeSelf)
                        {
                            inventoryslot[i].SetActive(true);
                            inventoryslot[i].GetComponent<Image>().sprite = spriteImage;
                            break;
                        }
                    }
                }
                else
                {
                    Debug.Log("Error Image Non assigné");
                }
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

    private void End()
    {
        endAnimator.SetBool("End", true);
    }
}
