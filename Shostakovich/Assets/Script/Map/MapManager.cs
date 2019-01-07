using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject exterior;
    [SerializeField] private GameObject[] room;
    private int currentMap = -1;

    private bool exteriorPosition = true;
    public bool ExteriorPosition => exteriorPosition;

    private static MapManager instance;
    public static MapManager Instance => instance;
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



    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.SaveDataInstance.currentMap != -1)
        {
            currentMap = GameManager.Instance.SaveDataInstance.currentMap;
        }

        exteriorPosition = GameManager.Instance.SaveDataInstance.exteriorPosition;
        if (GameManager.Instance.SaveDataInstance.exteriorPosition)
        {
            wall.SetActive(true);
            exterior.SetActive(true);
            currentMap = -1;
        } else
        {
            wall.SetActive(false);
            exterior.SetActive(false);
            room[currentMap].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TransitionInterior(int roomIndex)
    {
        wall.SetActive(false);
        exterior.SetActive(false);
        room[roomIndex].SetActive(true);
        exteriorPosition = false;
        currentMap = roomIndex;
    }
    public void TransitionExterior()
    {
        wall.SetActive(true);
        exterior.SetActive(true);
        room[currentMap].SetActive(false);
        exteriorPosition = true;
        currentMap = -1;

    }

    private void OnDestroy()
    {
        GameManager.Instance.SaveDataInstance.exteriorPosition = exteriorPosition;
        GameManager.Instance.SaveDataInstance.currentMap = currentMap;

    }
}
