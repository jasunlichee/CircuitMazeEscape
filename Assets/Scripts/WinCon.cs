using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCon : MonoBehaviour
{
    public GameObject timer;
    public GameObject player;

    public GameObject updater1;
    public GameObject updater2;
    public GameObject updater3;
    public GameObject updater4;

    public GameManager gameManager;
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.wonGame();

            int moves = updater1.GetComponent<WireUpdater>().getCounter() + updater2.GetComponent<WireUpdater>().getCounter() + updater3.GetComponent<WireUpdater>().getCounter() + updater4.GetComponent<WireUpdater>().getCounter();

            PlayerPrefs.SetInt("TimeLeft", timer.GetComponent<CountdownTimer>().getTime());
            PlayerPrefs.SetInt("Moves", moves + 1);
        }
    }
}
