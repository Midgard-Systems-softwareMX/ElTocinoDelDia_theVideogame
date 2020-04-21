using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{

    public GameObject RoadMotorGo;
    public Road RoadMotorScript;
    public Sprite[] Readynum;

    public GameObject CountNumGO;
    public SpriteRenderer CountNumComp;

    public GameObject CarControllerGo;
    public GameObject CarGo;

    // Start is called before the first frame update
    void Start()
    {
        IniatComp();
        countdown();
    }

    void IniatComp()
    {
        RoadMotorGo = GameObject.Find("RoadMotor");
        RoadMotorScript = RoadMotorGo.GetComponent<Road>();

        CountNumGO = GameObject.Find("CountReadynum");
        CountNumComp = CountNumGO.GetComponent<SpriteRenderer>();

        CarGo = GameObject.Find("Coche");
        CarControllerGo = GameObject.Find("CarController");
    }

    void countdown()
    {
        StartCoroutine(Counter());
    }

    IEnumerator Counter()
    {
        CarControllerGo.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(3);


        CountNumComp.sprite = Readynum[1];
        RoadMotorScript.GameStart = true;
        yield return new WaitForSeconds(.5f);

        CountNumGO.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
