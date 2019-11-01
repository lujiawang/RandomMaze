using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSuccess : MonoBehaviour
{
    public Text WinText;

    private bool freeze = false;
    private Vector3 currentPos;
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("EndCube"))
        {
            col.gameObject.SetActive(false);
            WinText.text = "YOU WIN!";
            freeze = true;
            currentPos = transform.position;
        }
    }
    void Update()
    {
        if (freeze)
            transform.position = currentPos;
    }
}
