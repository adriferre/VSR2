using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class CheckEnemyInFOVRange : Node
{
    private static int _enemyLayerMask = 1 << 6;

    private Transform _transform;
    private GameObject _jugador;

    public CheckEnemyInFOVRange(Transform transform)
    {
        _transform = transform;
        _jugador = GameObject.Find("Complete XR Origin Set Up Variant(Clone)");
    }

    public override NodeState Evaluate()
    {
        object t = GetData("target");
        if (t == null)
        {
            // Calcular la direcci�n desde el enemigo al jugador
            _jugador = GameObject.Find("Complete XR Origin Set Up Variant(Clone)");
            Vector3 directionToPlayer = _jugador.transform.position - _transform.position;

            // Verificar si el jugador est� dentro del rango de visi�n
            if (directionToPlayer.magnitude < GuardBT.visionRange)
            {
                // Calcular el �ngulo entre la direcci�n hacia el jugador y la direcci�n en la que mira el enemigo
                float angleToPlayer = Vector3.Angle(_transform.forward, directionToPlayer);

                // Verificar si el jugador est� dentro del �ngulo de visi�n
                if (angleToPlayer < GuardBT.visionAngle / 2)
                {
                    Ray ray = new Ray(_transform.position, directionToPlayer);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit, GuardBT.visionRange))
                    {
                        // Verificar si el raycast golpea al jugador
                        if (hit.transform.CompareTag("Player"))
                        {
                            // El jugador est� dentro de la l�nea de visi�n del enemigo
                            Debug.Log("Jugador detectado");
                            parent.parent.SetData("target", _jugador.transform);
                            state = NodeState.SUCCESS;
                            return state;

                        }
                    }
                }
            }
            state = NodeState.FAILURE;
            return state;
        }

        state = NodeState.SUCCESS;
        return state;
    }

}
