using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("GoodObject"))
        {
            ProgressBar.Instance.OnGoodObjectDestroyed();
        }
        else if(other.CompareTag("BadObject"))
        {
            GameManager.Instance.OnLevelFail();
        }
        Destroy(other.gameObject);
    }
}
