using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool doveFlee = false;
    public bool DoveFlee
    {
        get { return doveFlee; }
        set { doveFlee = value; }
    }

    private Caretaker.CaretakerState currentState;
    public Caretaker.CaretakerState CurrentState
    {
        get { return currentState; }
        set { currentState = value; }
    }
    private Vector3 playerPosition;
    public Vector3 PlayerPosition
    {
        get { return playerPosition; }
        set { playerPosition = value; }
    }

    private Quaternion playerRotation;
    public Quaternion PlayerRotation
    {
        get { return playerRotation; }
        set { playerRotation = value; }
    }


    private PlayerTest.Orientation currentOrientation;
    public PlayerTest.Orientation CurrentOrientation
    {
        get { return currentOrientation; }
        set { currentOrientation = value; }
    }

    private bool exteriorPosition = true;
    public bool ExteriorPosition
    {
        get { return exteriorPosition; }
        set { exteriorPosition = value; }
    }

    private int currentMap = -1;
    public int CurrentMap
    {
        get { return currentMap; }
        set { currentMap = value; }
    }

    private List<string> inventory = new List<string>();
    public List<string> Inventory
    {
        get { return inventory; }
        set { inventory = value; }
    }



    [SerializeField] private static GameManager instance;
    public static GameManager Instance => instance;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
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
        
    }
    
}
