using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BunnyAI : MonoBehaviour
{
    Vector3 farmCenter = new Vector3(10.65999985f, 0.192000002f, 2.44000006f);

    public float bunnyStopDistance = 12;

    public GameObject request;
    bool isRequesting;
    private GameObject instantiatedRequest;
    private Vector3 requestLocation;

    private GameObject camObject;
    private Camera cam;

    private GameObject canvasObject;
    public Canvas canvas;

    public GameObject pointer;
    private GameObject instantiatedPointer;
    private Vector3 pointerPosition;

    private GameObject player;

    public TextMeshProUGUI carrotRequestText;
    private Image carrotRequestImage;
    public float carrotRequestAmount = 1;
    GameObject carrotRequestTextObject;
    GameObject carrotRequestImageObject;

    private GameManager gameManagerScript;

    public float timerRemaining = 30f;

    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(farmCenter);

        camObject = GameObject.Find("Main Camera");
        cam = camObject.GetComponent<Camera>();

        canvasObject = GameObject.Find("Canvas");
        canvas = canvasObject.GetComponent<Canvas>();

        pointerPosition = transform.position + new Vector3(0, 1, 0);
        instantiatedPointer = Instantiate(pointer, pointerPosition, transform.rotation, this.transform);

        player = GameObject.Find("Player");

        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        WaitTooLong();

        if (Vector3.Distance(player.transform.position, transform.position) < 2.5)
        {
            instantiatedPointer.SetActive(true);
        }

        if (Vector3.Distance(player.transform.position, transform.position) > 2.5)
        {
            instantiatedPointer.SetActive(false);
        }
    }
    void Move()
    {
        if (transform.position.x > farmCenter.x + bunnyStopDistance || transform.position.z > farmCenter.z + bunnyStopDistance || transform.position.x < farmCenter.x - bunnyStopDistance || transform.position.z < farmCenter.z - bunnyStopDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, farmCenter, 10 * Time.deltaTime);
            instantiatedPointer.SetActive(false);
        }
        else if (!isRequesting) 
        {
            instantiatedRequest = Instantiate(request,canvas.transform);
            isRequesting = true;
            requestLocation = cam.WorldToScreenPoint(transform.position + new Vector3(0,2.5f,0));
            instantiatedRequest.transform.position = requestLocation;
            //carrotRequestAmount = 1;
            carrotRequestTextObject = instantiatedRequest.transform.GetChild(1).gameObject;
            carrotRequestText = carrotRequestTextObject.GetComponent<TextMeshProUGUI>();
            carrotRequestText.text = "" + carrotRequestAmount;

        }
        if (Vector3.Distance(player.transform.position, transform.position) < 2.5 && Input.GetKeyDown(KeyCode.Space) && gameManagerScript.carrots >= carrotRequestAmount)
        {
            instantiatedPointer.SetActive(false);
            gameManagerScript.carrots -= carrotRequestAmount;
            gameManagerScript.carrotText.text = "" + gameManagerScript.carrots;
            gameManagerScript.bunniesFed++;
            Destroy(gameObject);
            Destroy(instantiatedRequest);
        }

    }

    void WaitTooLong()
    {
        timerRemaining -= Time.deltaTime;

        if (timerRemaining < 10)
        {
            carrotRequestImageObject = instantiatedRequest.gameObject;
            carrotRequestImage = carrotRequestImageObject.GetComponent<Image>();
            carrotRequestImage.color = Color.red;    
        }
        if (timerRemaining < 0)
        {
            Destroy(gameObject);
            Destroy(instantiatedRequest);
            gameManagerScript.missedBunnies++;
        }

    }


}
