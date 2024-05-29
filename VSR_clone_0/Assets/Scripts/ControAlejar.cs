using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControAlejar : MonoBehaviour
{
    public Transform cuboTransform; // La referencia a la c�mara
    private Vector3 initialPosition; // La posici�n inicial del cubo
    private Quaternion initialRotation; // La rotaci�n inicial del cubo
    // Start is called before the first frame update
    void Start()
    {
        // Guardar la posici�n y rotaci�n iniciales del cubo
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        // Mantener la posici�n "y" y la rotaci�n del cubo
        transform.position = new Vector3(cuboTransform.position.x, initialPosition.y, cuboTransform.position.z);
        transform.rotation = initialRotation;
    }
}
