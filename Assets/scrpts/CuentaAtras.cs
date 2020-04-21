using UnityEngine;
using System.Collections;

public class CuentaAtras : MonoBehaviour {

	public GameObject motorCarreteraGO;
	public Road motorCarreteraScript;
	public Sprite[] numeros;

	public GameObject contadorNumerosGO;
	public SpriteRenderer contadorNumerosComp;

	public GameObject controladorcocheGO;
	public GameObject cocheGO;


	// Use this for initialization
	void Start () 
	{
		InicioComponentes();
	}

	void InicioComponentes()
	{
		motorCarreteraGO = GameObject.Find("Road");
		motorCarreteraScript = motorCarreteraGO.GetComponent<Road>();

		contadorNumerosGO = GameObject.Find("ContadorNumeros");
		contadorNumerosComp = contadorNumerosGO.GetComponent<SpriteRenderer>();

		cocheGO = GameObject.Find("Coche");
		controladorcocheGO = GameObject.Find("ControladorCoche");

		InicioCuentaAtras();

	}
	
	void InicioCuentaAtras()
	{
		StartCoroutine(Contando());
	}

	IEnumerator Contando()
	{
		controladorcocheGO.GetComponent<AudioSource>().Play();
		yield return new WaitForSeconds (2);

		contadorNumerosComp.sprite = numeros[1];
		this.gameObject.GetComponent<AudioSource>().Play();
		yield return new WaitForSeconds(1);

		contadorNumerosComp.sprite = numeros[2];
		this.gameObject.GetComponent<AudioSource>().Play();
		yield return new WaitForSeconds(1);

		contadorNumerosComp.sprite = numeros[3];
		motorCarreteraScript.GameStart = true;
		contadorNumerosGO.GetComponent<AudioSource>().Play();
		cocheGO.GetComponent<AudioSource>().Play();
		yield return new WaitForSeconds(2);

		contadorNumerosGO.SetActive(false);
	}
}
