using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] GameManedger gM;
    private void OnTriggerEnter(Collider other)
    {
        gM.LoadNextLvl();
    }
}
