using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantingMechanic : MonoBehaviour
{
    private GameObject player;
    public GameObject pointer;
    public GameObject soilWithSeeds;

    private GameObject instantiatedPointer;

    private Vector3 pointerPosition;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        pointerPosition = transform.position + new Vector3(0, 2, 0);
        instantiatedPointer=Instantiate(pointer, pointerPosition, transform.rotation,this.transform);
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

        if (Vector3.Distance(player.transform.position,transform.position) < 2.5 && Input.GetKeyDown(KeyCode.Space))
        {
            instantiatedPointer.SetActive(false);
            Instantiate(soilWithSeeds,transform.position,transform.rotation);
            Destroy(gameObject);
        }
    }
}
