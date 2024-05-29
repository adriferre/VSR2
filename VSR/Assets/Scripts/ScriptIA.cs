using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UIElements;

public class ScriptIA : MonoBehaviour
{
    public Transform _transform;
    GameObject enemigo;
    GameObject alejarse;
    bool alcanzado;

    // Start is called before the first frame update
    void Start()
    {
        enemigo = GameObject.Find("CubePosicion");
        alejarse = GameObject.Find("CubePosicion2");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (alcanzado)
        {
            if (Vector3.Distance(_transform.position, enemigo.transform.position) < 4f)
            {
                Vector3 directionAway = _transform.position - enemigo.transform.position;
                directionAway.Normalize();
                //float posicionY = _transform.position.y;
                float posicionY = 0.35f;
                float rotacionX = 0f;
                _transform.LookAt(enemigo.transform);
                _transform.position += directionAway * 2f * Time.deltaTime;
                _transform.position = new Vector3(_transform.position.x, posicionY, _transform.position.z);
                //Añadir aqui
                _transform.rotation.SetLookRotation(enemigo.transform.position);
                Vector3 rotationEuler = _transform.rotation.eulerAngles;
                rotationEuler.x = rotacionX;
                _transform.rotation = Quaternion.Euler(rotationEuler);
                // Mover el objeto en la dirección opuesta
            }
            else
            {
                alcanzado = false;
            }
        } else
        {
            if (Vector3.Distance(_transform.position, enemigo.transform.position) > 1f)
            {
                //Mueve hacia el objetivo
                _transform.position = Vector3.MoveTowards(
                    _transform.position, enemigo.transform.position, 2f * Time.deltaTime);
                //float posicionY = _transform.position.y;
                //float rotacionX = _transform.rotation.x;
                float posicionY = 0.35f;
                float rotacionX = 0f;
                _transform.LookAt(enemigo.transform);
                _transform.position = new Vector3(_transform.position.x, posicionY, _transform.position.z);
                //Añadir aqui
                _transform.rotation.SetLookRotation(enemigo.transform.position);
                Vector3 rotationEuler = _transform.rotation.eulerAngles;
                rotationEuler.x = rotacionX;
                _transform.rotation = Quaternion.Euler(rotationEuler);
            }
            else
            {
                alcanzado = true;
            }
        }
        
    }
}
