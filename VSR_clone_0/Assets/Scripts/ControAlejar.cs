using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControAlejar : MonoBehaviour
{
    public Transform cuboTransform; // La referencia a la cámara
    private Vector3 initialPosition; // La posición inicial del cubo
    private Quaternion initialRotation; // La rotación inicial del cubo
    // Start is called before the first frame update
    void Start()
    {
        // Guardar la posición y rotación iniciales del cubo
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        // Mantener la posición "y" y la rotación del cubo
        transform.position = new Vector3(cuboTransform.position.x, initialPosition.y, cuboTransform.position.z);
        transform.rotation = initialRotation;
    }
}
