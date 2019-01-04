using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

/*
Axe X entre 5 et -5
Axe Y entre 3 et -3
Déplacement de 0.5
 */

public class PuzzleMap : MonoBehaviour
{

    [SerializeField] GameObject axeX;
    [SerializeField] GameObject axeY;
    [SerializeField] float xWinPosition = -4.5f;
    [SerializeField] float yWinPosition = 0f;
    [SerializeField] TextMeshProUGUI victoryText;

    bool buttonHorizontal = false;
    bool buttonVertical = false;
    bool canMove = true;
    bool endstarted = false;

    [SerializeField] private string rewardObject;

    // Start is called before the first frame update
    void Start()
    {
        victoryText.color = new Color(1, 1, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {

        //Tile movement X
        if (Input.GetAxisRaw("Horizontal") > 0 && !buttonHorizontal && canMove)
        {
            buttonHorizontal = true;
            if (axeX.transform.position.x < 5)
            {
                axeX.transform.position = new Vector2(axeX.transform.position.x + 0.5f, axeX.transform.position.y);
            }
        }

        if (Input.GetAxisRaw("Horizontal") < 0 && !buttonHorizontal && canMove)
        {
            buttonHorizontal = true;
            if (axeX.transform.position.x > -5)
            {
                axeX.transform.position = new Vector2(axeX.transform.position.x - 0.5f, axeX.transform.position.y);
            }
        }

        if (Input.GetAxisRaw("Horizontal") == 0 && buttonHorizontal && canMove)
        {
            buttonHorizontal = false;
        }


        //Tile movement Y
        if (Input.GetAxisRaw("Vertical") > 0 && !buttonVertical && canMove)
        {
            buttonVertical = true;
            if (axeY.transform.position.y < 3)
            {
                axeY.transform.position = new Vector2(axeY.transform.position.x, axeY.transform.position.y + 0.5f);
            }
        }

        if (Input.GetAxisRaw("Vertical") < 0 && !buttonVertical && canMove)
        {
            buttonVertical = true;
            if (axeY.transform.position.y > -3)
            {
                axeY.transform.position = new Vector2(axeY.transform.position.x, axeY.transform.position.y - 0.5f);
            }
        }

        if (Input.GetAxisRaw("Vertical") == 0 && buttonVertical && canMove)
        {
            buttonVertical = false;
        }

        if (axeX.transform.position.x == xWinPosition && axeY.transform.position.y == yWinPosition && !endstarted)
        {
            //play unlock sound
            canMove = false;
            StartCoroutine(WinText());
            endstarted = true;
            if (!GameManager.Instance.Inventory.Contains(rewardObject))
            {
                GameManager.Instance.Inventory.Add(rewardObject);
                GameManager.Instance.Inventory.Add("musicSheet2");
                GameManager.Instance.Inventory.Add("musicSheet3");
            }
            else
            {
                Debug.Log("error object already exist");
            }

            SceneManager.LoadScene("Luca");
        }


    }

    IEnumerator WinText()
    {
        for (float i = 0; i < 1; i += 0.02f)
        {
            victoryText.color = new Color(1, 1, 1, 0 + i);
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(2f);
        //Box opened
        Debug.Log("Load Scene");
    }
}
