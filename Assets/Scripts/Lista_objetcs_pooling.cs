using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lista_objetcs_pooling : MonoBehaviour
{
    public static List<Object_pooling> instance;
    public List<Object_pooling> lista;

    private void Awake()
    {
        instance = lista;
    }

}
