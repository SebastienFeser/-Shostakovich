using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    Vector3 startPos;
    Vector3 endPos;
    float time;

    public enum Orientation
    {
        NORTH,
        SOUTH,
        RIGHT,
        LEFT
    }


    [SerializeField] private float speed;

    private Orientation currentOrientation = Orientation.SOUTH;
    public Orientation CurrentOrientation => currentOrientation;

    [SerializeField] private Detector detector;

    [SerializeField] private bool key;
    public bool Key
    {
        get { return key; }
        set { key = value; }
    }
    
    private List<string> inventory = new List<string>();
    public List<string> Inventory
    {
        get { return inventory; }
        set { inventory = value; }
    }
    bool isMoving = false;
    bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        detector.GetComponentInChildren<Detector>();
        inventory = GameManager.Instance.Inventory;
        if (GameManager.Instance.PlayerPosition != Vector3.zero)
        {
            currentOrientation = GameManager.Instance.CurrentOrientation;
            transform.position = GameManager.Instance.PlayerPosition;
            transform.rotation = GameManager.Instance.PlayerRotation;
        }
        else
        {
            GameManager.Instance.CurrentOrientation = currentOrientation;
            GameManager.Instance.PlayerPosition = transform.position;
            GameManager.Instance.PlayerRotation = transform.rotation;
            GameManager.Instance.Inventory = inventory;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Up"))
        {
            currentOrientation = Orientation.NORTH;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            if (!detector.DetectWall())
            transform.position = Vector3.Lerp(transform.position, new Vector2(transform.position.x, transform.position.y + 1), speed);
        }
        else if (Input.GetButtonDown("Down"))
        {
            currentOrientation = Orientation.SOUTH;
            transform.rotation = Quaternion.Euler(0, 0, 180);
            if (!detector.DetectWall())
                transform.position = Vector3.Lerp(transform.position, new Vector2(transform.position.x, transform.position.y - 1), speed);
        }
        else if (Input.GetButtonDown("Right"))
        {
            currentOrientation = Orientation.RIGHT;
            transform.rotation = Quaternion.Euler(0, 0, -90);
            if (!detector.DetectWall())
                transform.position = Vector3.Lerp(transform.position, new Vector2(transform.position.x + 1, transform.position.y), speed);
        }
        else if (Input.GetButtonDown("Left"))
        {
            currentOrientation = Orientation.LEFT;
            transform.rotation = Quaternion.Euler(0, 0, 90);
            if (!detector.DetectWall())
                transform.position = Vector3.Lerp(transform.position, new Vector2(transform.position.x - 1, transform.position.y), speed);
        }

        if (Input.GetButtonDown("Interact"))
        {
            if (detector.DetectInteract())
            {
                detector.DetectInteract().Interaction();
            }
        }


        if (inventory.Contains("musicSheet1") && inventory.Contains("musicSheet2") && inventory.Contains("musicSheet3") && inventory.Contains("musicSheet4"))
        {
            Application.Quit();
        }
        
        
    }

    public bool SearchInInventory(string nameObject)
    {
        return inventory.Contains(nameObject);
    }

    public void NewInventory(string nameObject)
    {
        if (!inventory.Contains(nameObject))
        {
            inventory.Add(nameObject);
        }
        else
        {
            Debug.Log("error object already exist");
        }
    }
    public IEnumerator Move(Transform entity)
        {
        isMoving = true;
        startPos = entity.position;
        time = 0;

        //endPos = new Vector3(startPos.x + System.Math.Sign(input.x));


        isMoving = false;
            yield return 0;
        }

    private void OnDestroy()
    {
        GameManager.Instance.CurrentOrientation = currentOrientation;
        
        GameManager.Instance.PlayerPosition = transform.position;
        GameManager.Instance.PlayerRotation = transform.rotation;
        GameManager.Instance.Inventory = inventory;
    }
}
