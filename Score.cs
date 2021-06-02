using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Text scoreText;

    private void Update()
    {
        Debug.Log(player.position.z);
        scoreText.text = ((int)(player.position.z/2)).ToString();
    }
}
