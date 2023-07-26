using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RatSelection : MonoBehaviour
{
    // Rats List & Declaring Rat Prefab
    [Header("Rats List")]
    public GameObject[] ratPrefabs;
    public GameObject rat,
                      ratStatus;

    // Unique Rat Rotation
    [Header("Rats Rotation")]
    public float yPosRat1 = -0.257f;
    public float yPosRat2 = -0.463f;

    // Buttons list
    [Header("Buttons")]
    public Button next,
                  previous,
                  play;

    // Which List of Rat
    [Header("List Order")]
    [SerializeField] private int ratID = 0;

    // Get Score from Game Manager
    public GameManager gameManager;

    void Start()
    {
        // Instantiate Starter Rat
        rat = Instantiate(ratPrefabs[ratID], new Vector3(0, yPosRat1, 0), Quaternion.Euler(-90, -45, 0));
        previous.interactable = false;
        
       gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

    }

    public void NextRat()
    {
        ratID++;

        #region Rat 2 Lock & Unlock
        if (ratID == 1 && gameManager.highScore <= 99)
        {
            Destroy(rat);
            rat = Instantiate(ratPrefabs[ratID], new Vector3(0, 0, 0), Quaternion.Euler(0, -45, 0));
            previous.interactable = true;
            play.interactable = false;
            ratStatus.SetActive(true);

        }
        else if (ratID == 1 && gameManager.highScore >= 100)
        {
            Destroy(rat);
            rat = Instantiate(ratPrefabs[3], new Vector3(0, 0, 0), Quaternion.Euler(0, -45, 0));
            previous.interactable = true;
        }
        #endregion

        #region Rat 3 Lock & Unlock
        if (ratID == 2 && gameManager.highScore <= 999)
        {
            Destroy(rat);
            rat = Instantiate(ratPrefabs[ratID], new Vector3(0, yPosRat2, 0), Quaternion.Euler(0, 145, 0));
            next.interactable = false;
            play.interactable = false;
            ratStatus.SetActive(true);
        }
        else if(ratID == 2 && gameManager.highScore >= 1000)
        {
            Destroy(rat);
            rat = Instantiate(ratPrefabs[4], new Vector3(0, yPosRat2, 0), Quaternion.Euler(0, 145, 0));
            next.interactable = false;
        }
        #endregion

    }

    public void PreviousRat()
    {
        ratID--;

        if (ratID == 0)
        {
            Destroy(rat);
            rat = Instantiate(ratPrefabs[ratID], new Vector3(0, yPosRat1, 0), Quaternion.Euler(-90, -45, 0));
            previous.interactable = false;
            play.interactable = true;
            ratStatus.SetActive(false);

        }

        #region Back to Rat 2
        if (ratID == 1 && gameManager.highScore <= 99)
        {
            Destroy(rat);
            rat = Instantiate(ratPrefabs[ratID], new Vector3(0, 0, 0), Quaternion.Euler(0, -45, 0));
            next.interactable = true;

        }
        else if (ratID == 1 && gameManager.highScore >= 100)
        {
            Destroy(rat);
            rat = Instantiate(ratPrefabs[3], new Vector3(0, 0, 0), Quaternion.Euler(0, -45, 0));
            next.interactable = true;
            play.interactable = true;
            ratStatus.SetActive(false);
        }
        #endregion
    }


}
