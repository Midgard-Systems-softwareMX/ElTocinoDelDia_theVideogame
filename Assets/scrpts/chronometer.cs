using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chronometer : MonoBehaviour
{
    public GameObject RoadsMotorGO;
    public Road RoadScript;

    public float Timer;
    public float Lenght;
    public Text txtTime;
    public Text txtPoints;

    // Start is called before the first frame update
    void Start()
    {
        RoadsMotorGO = GameObject.Find("RoadMotor");
        RoadScript = RoadsMotorGO.GetComponent<Road>();

        txtTime.text = "0:00";
        txtPoints.text = "0";

        Timer = 120;
    }

    // Update is called once per frame
    void Update()
    {
        if(RoadScript.GameStart == true && RoadScript.GameFinished== false) { 
        CaluculateTimeAndLenght();
        }

        if(Timer <= 0 && RoadScript.GameFinished == false)
        {
            RoadScript.GameFinished = true;
        }
    }

    void CaluculateTimeAndLenght()
    {   //cast cambiar el tipo de dato
        Lenght += Time.deltaTime * RoadScript.speed;
        txtPoints.text = ((int)Lenght).ToString();

        Timer -= Time.deltaTime;
        int minutes = (int)Timer / 60;
        int seconds = (int)Timer % 60;
        txtTime.text = minutes.ToString() + ":" + seconds.ToString().PadLeft(2,'0');
    }
}
