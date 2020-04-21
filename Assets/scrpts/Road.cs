using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public GameObject AfterRoad;
    public GameObject BeforeRoad;

    public GameObject RoadsContainer;
    public GameObject[] RoadsContainerArray;

    public float speed;
    public bool GameStart;
    public bool GameFinished;

    public int CountRoads = 0;
    public int numSelectorRoads;

    public float RoadSize = 20f;

    public Vector3 LimitScreen;
    public bool ScreenOut;

    public GameObject MaCa;
    public Camera MaCaCo;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        RoadsContainer = GameObject.Find("RoadsContainer");
        speedRoad();
        LenghtScreens();
        SearchRoads();
        MaCa = GameObject.Find("MainCamera");
        MaCaCo = MaCa.GetComponent<Camera>();

    }

    void speedRoad()
    {
        speed = 10;
    }

    void SearchRoads()
    {
        RoadsContainerArray = GameObject.FindGameObjectsWithTag("Road");
        for (int i = 0; i < RoadsContainerArray.Length; i++)
        {
            RoadsContainerArray[i].gameObject.transform.parent = RoadsContainer.transform;
            RoadsContainerArray[i].gameObject.SetActive(false);
            RoadsContainerArray[i].gameObject.name = "CalleOFF_" + i;
            
        }
        CreateRoads();

    }

    void CreateRoads()
    {
        CountRoads++;
        numSelectorRoads = Random.Range(0, RoadsContainerArray.Length);
        GameObject Road = Instantiate(RoadsContainerArray[numSelectorRoads]);
        Road.SetActive(true);
        Road.name = "Road" + CountRoads;
        Road.transform.parent = gameObject.transform;
        PositionRoads();
    }

    void PositionRoads()
    {   //Posiciona las calles
        BeforeRoad = GameObject.Find("Road" + (CountRoads -1));
        AfterRoad = GameObject.Find("Road" + CountRoads);
        AfterRoad.transform.position = new Vector3(0 , BeforeRoad.transform.position.y + 46.5f, 0);

        ScreenOut = false;
    }


    /*
    void RoadLenght()
    {
        for( int i = 0; i < BeforeRoad.transform.childCount; i++)
        {
            if(BeforeRoad.transform.GetChild(i).gameObject.GetComponent<Piece>() != null){ 
            float PieceSize = BeforeRoad.transform.GetChild(i).gameObject.GetComponent <SpriteRenderer>().bounds.size.y;
            RoadSize = RoadSize + PieceSize;       
        }
        }
    }
    */

        void LenghtScreens()
    {   // Mide las medidas de la pantalla
        LimitScreen = new Vector3(0, MaCaCo.ScreenToWorldPoint(new Vector3(0,0,0)).y - 10,0);
    }

        // Update is called once per frame
        void Update()
        {

        if (GameStart == true && GameFinished == false)
            {   //Mueve las calles y las recorre
                transform.Translate(Vector3.down * speed * Time.deltaTime);
                if(BeforeRoad.transform.position.y + 20 < LimitScreen.y && ScreenOut == false)
            {
                ScreenOut = true;
                OcultRoad();
            }
            }
        }

        void OcultRoad()
    {
        Destroy(BeforeRoad);
        RoadSize = 0;
        BeforeRoad = null;
        CreateRoads();
    }
    
}
