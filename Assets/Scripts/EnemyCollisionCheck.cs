using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionCheck : MonoBehaviour
{
    [HideInInspector] public bool isOn = false;

    private string wallTag = "Wall";
    private string dokanTag = "Dokan";
    private string blockTag = "Block";


    #region//接触判定
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == wallTag ||
            collision.tag == dokanTag ||
            collision.tag == blockTag)
        {
            isOn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == wallTag ||
            collision.tag == dokanTag ||
            collision.tag == blockTag)
        {
            isOn = false;
        }
    }
    #endregion
}
