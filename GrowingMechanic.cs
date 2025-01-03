using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrowingMechanic : MonoBehaviour
{
    public float timeRemaining = 0.0f;

    public Slider slider;
    private GameObject canvasObject;
    public Canvas canvas;

    public GameObject soilWithCarrots;

    private Slider instantiatedSlider;
    private GameObject camObject;
    private Camera cam;
    private Vector3 sliderLocation;

    // Start is called before the first frame update
    void Start()
    {
        camObject = GameObject.Find("Main Camera");
        cam = camObject.GetComponent<Camera>();

        canvasObject = GameObject.Find("Canvas");
        canvas = canvasObject.GetComponent<Canvas>();

        instantiatedSlider = Instantiate(slider,canvas.transform);
    }

    // Update is called once per frame
    void Update()
    {
        sliderLocation = cam.WorldToScreenPoint(transform.position);
        instantiatedSlider.transform.position = sliderLocation;

        if (timeRemaining < 10)
        {
            timeRemaining += Time.deltaTime;
            instantiatedSlider.value = timeRemaining;
        }
        else
        {
            Instantiate(soilWithCarrots, transform.position, transform.rotation);
            Destroy(instantiatedSlider.gameObject);
            Destroy(gameObject);
        }
    }
}
