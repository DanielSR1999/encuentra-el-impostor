using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text resultado;
    public AudioClip correcto, incorrecto;
    public List<Sprite> elementosNoIntrusos;
    public Sprite imagenIntruso;
    public List<Image> elementos;
    private void Start()
    {
        GameObject[] elementosGM= GameObject.FindGameObjectsWithTag("Elemento");
        
        for(int i=0; i<elementosGM.Length;i++)
        {
            elementos.Add(elementosGM[i].GetComponent<Image>());
        }
        EstablecerIntrusoAleatorio();
        EstablecerNoIntrusosAleatorio();
    }
    void EstablecerIntrusoAleatorio()
    {
        Debug.Log(nameof(EstablecerIntrusoAleatorio));
        int random = Random.Range(0, elementos.Count);
        elementos[random].GetComponent<ElementoIntruso>()._tipoElemento = ElementoIntruso.tipoElemento.impostor;
        elementos[random].GetComponent<Image>().sprite = imagenIntruso;
        elementos.RemoveAt(random);
    }
    void EstablecerNoIntrusosAleatorio()
    {
        Debug.Log(nameof(EstablecerNoIntrusosAleatorio));
        for (int i = 0; i < elementos.Count; i++)
        {
            elementos[i].GetComponent<ElementoIntruso>()._tipoElemento = ElementoIntruso.tipoElemento.noImpostor;
            elementos[i].GetComponent<Image>().sprite = elementosNoIntrusos[Random.Range(0, elementosNoIntrusos.Count)];
        }
    }
    public void ResultadoCorrecto()
    {
        Debug.Log(nameof(ResultadoCorrecto));
        resultado.text = "Correcto";

    }
    public void ResultadoIncorrecto()
    {
        Debug.Log(nameof(ResultadoIncorrecto));
        resultado.text = "Incorrecto";
    }
}
