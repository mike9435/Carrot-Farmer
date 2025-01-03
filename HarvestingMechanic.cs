using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using TMPro;

public class HarvestingMechanic : MonoBehaviour
{
    private GameObject player;

    public GameObject soil;

    public GameObject pointer;
    private GameObject instantiatedPointer;
    private Vector3 pointerPosition;

    private GameManager gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();

        player = GameObject.Find("Player");

        pointerPosition = transform.position + new Vector3(0, 2, 0);
        instantiatedPointer = Instantiate(pointer, pointerPosition, transform.rotation, this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < 2.5)
        {
            instantiatedPointer.SetActive(true);
        }

        if (Vector3.Distance(player.transform.position, transform.position) > 2.5)
        {
            instantiatedPointer.SetActive(false);
        }
        if (Vector3.Distance(player.transform.position, transform.position) < 2.5 && Input.GetKeyDown(KeyCode.Space))
        {
            instantiatedPointer.SetActive(false);
            Instantiate(soil, transform.position, transform.rotation);
            Destroy(gameObject);
            gameManagerScript.UpdateCarrots(1);
        }
    }
}
