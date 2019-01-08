using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    Vector3 startPos;
    Vector3 endPos;
    Vector2 input;
    float time;
    public float TimeMove
    {
        get { return time; }
        set { time = value; }
    }

    public enum Orientation
    {
        NORTH,
        SOUTH,
        EAST,
        WEST
    }


    [SerializeField] private float speed;

    [SerializeField] private Sprite up;
    [SerializeField] private Sprite down;
    [SerializeField] private Sprite right;
    [SerializeField] private Sprite left;


    private Orientation currentOrientation = Orientation.SOUTH;
    public Orientation CurrentOrientation => currentOrientation;

    [SerializeField] private Detector detector;
    
    private List<string> inventory = new List<string>();
    public List<string> Inventory
    {
        get { return inventory; }
        set { inventory = value; }
    }
    bool isMoving = false;
    bool canMove = true;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        animator.SetFloat("Speed", speed);
        detector.GetComponentInChildren<Detector>();
        inventory = GameManager.Instance.SaveDataInstance.inventory;
        if (GameManager.Instance.SaveDataInstance.playerPosition != Vector3.zero)
        {
            currentOrientation = GameManager.Instance.SaveDataInstance.currentOrientation;
            switch (currentOrientation)
            {
                case Orientation.NORTH:
                    detector.transform.localPosition = new Vector2(0, -1);
                    //northSprite;
                    break;
                case Orientation.EAST:
                    detector.transform.localPosition = new Vector2(-1, 0);
                    //eastSprite;
                    break;
                case Orientation.SOUTH:
                    detector.transform.localPosition = new Vector2(0, 1);
                    //southSprite;
                    break;
                case Orientation.WEST:
                    detector.transform.localPosition = new Vector2(1, 0);
                    //westSprite;
                    break;
            }
            transform.position = GameManager.Instance.SaveDataInstance.playerPosition;
        }
        else
        {
            GameManager.Instance.SaveDataInstance.currentOrientation = currentOrientation;
            GameManager.Instance.SaveDataInstance.playerPosition = transform.position;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving && canMove)
        {
            input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
                input.y = 0;
            else
                input.x = 0;

            if (input != Vector2.zero)
            {

                if (input.x < 0)
                {
                    currentOrientation = Orientation.WEST;
                    detector.transform.localPosition = new Vector2(1, 0);
                    animator.SetInteger("Orientation", 4);
                }
                if (input.x > 0)
                {
                    currentOrientation = Orientation.EAST;
                    detector.transform.localPosition = new Vector2(-1, 0);
                    animator.SetInteger("Orientation", 2);

                }
                if (input.y < 0)
                {
                    currentOrientation = Orientation.SOUTH;
                    detector.transform.localPosition = new Vector2(0, 1);
                    animator.SetInteger("Orientation", 3);

                }
                if (input.y > 0)
                {
                    currentOrientation = Orientation.NORTH;
                    detector.transform.localPosition = new Vector2(0, -1);
                    animator.SetInteger("Orientation", 1);

                }

                switch (currentOrientation)
                {
                    case Orientation.NORTH:
                        

                        break;
                    case Orientation.EAST:
                        

                        //eastSprite;
                        break;
                    case Orientation.SOUTH:
                        

                        //southSprite;
                        break;
                    case Orientation.WEST:
                        


                        //westSprite;
                        break;
                }

                if (!detector.DetectWall())
                {
                    StartCoroutine(Move(transform));
                }
            }

        }


        if (Input.GetButtonDown("Interact"))
        {
            if (detector.DetectInteract())
            {
                detector.DetectInteract().Interaction();
            }
        }

        if (Input.GetButtonDown("Inventory"))
        {
            UIManager.Instance.InventoryDisplay(inventory);
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

            animator.SetBool("Move", isMoving);
        startPos = entity.position;
        time = 0;

        endPos = new Vector3(startPos.x + System.Math.Sign(input.x), startPos.y + System.Math.Sign(input.y), startPos.z);

        while (time < 1f)
        {
            time += Time.deltaTime * speed;
            entity.position = Vector3.Lerp(startPos, endPos, time);
            yield return null;
        }
        

        isMoving = false;
            animator.SetBool("Move", isMoving);
        yield return 0;
    }

    private void OnDestroy()
    {
        GameManager.Instance.SaveDataInstance.currentOrientation = currentOrientation;
        
        GameManager.Instance.SaveDataInstance.playerPosition = transform.position;
        GameManager.Instance.SaveDataInstance.inventory = inventory;
    }
}
