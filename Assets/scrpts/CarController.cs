using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{

    public GameObject CarGO;

    public float CurveAngle;
    public float speedcar;

    public float ScreenLimit;

    // Start is called before the first frame update
    void Start()
    {
        CarGO = GameObject.FindObjectOfType<Car>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        float GireZ = 0;
        transform.Translate(Vector2.right * Input.GetAxis("Horizontal") * speedcar * Time.deltaTime);

        GireZ = Input.GetAxis("Horizontal") * -CurveAngle;

        CarGO.transform.rotation = Quaternion.Euler(0, 0, GireZ);


    }
}
