using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Cambiar_escena : MonoBehaviour
{
    public void Cambiar(string nombre_scene)
    {
        SceneManager.LoadScene(nombre_scene);
    }
}
