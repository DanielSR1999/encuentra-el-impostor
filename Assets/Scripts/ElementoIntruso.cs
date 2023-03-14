using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementoIntruso : MonoBehaviour
{
    public enum tipoElemento {_null, impostor, noImpostor}
    public tipoElemento _tipoElemento;
    GameController gameController;
    AudioSource audioSource;
    private void Awake()
    {
        gameController = Camera.main.GetComponent<GameController>();
        audioSource = Camera.main.GetComponent<AudioSource>();
    }
    public void PresionarElemento()
    {
        Debug.Log(nameof(PresionarElemento));
        if(_tipoElemento==tipoElemento.impostor)
        {
            gameController.ResultadoCorrecto();
            audioSource.clip = gameController.correcto;
            audioSource.Play();
        }
        else
        {
            gameController.ResultadoIncorrecto();
            audioSource.clip = gameController.incorrecto;
            audioSource.Play();
        }
    }
}
