using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class PunchSpeed : MonoBehaviour
{
    [Tooltip("Actions to check")]
    public InputAction action = null;
    public SettingSO settings;
    public TextMeshProUGUI speedText;

    [Tooltip("Rigidbody")]
    private Rigidbody handControllerRigidbody;

    float punchSpeed = 0f;

    private bool runOut = false;

    public GameObject handController; // Reference to your hand controller object
    private Vector3 punchStartPos; // Store the starting position of the punch
    private float punchStartTime;  // Store the time when the punch starts
    private bool isPunching = false; // Flag to track punch motion


    void Start()
    {
        handControllerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Check for trigger button press (same as previous method)
        if (runOut)
        {
            
            // Calculate punch speed based on hand controller's velocity
            punchSpeed = handControllerRigidbody.velocity.magnitude;
            speedText.text = punchSpeed.ToString();
            // Do something with the punch speed (same as previous method)
            Debug.Log("Punch Speed: " + punchSpeed + " m/s");



        }


        // Check if punch is ongoing
        if (isPunching)
        {
            // Cast a raycast from the hand controller
            RaycastHit hit;
            if (Physics.Raycast(handController.transform.position, handController.transform.forward, out hit))
            {
                // Calculate punch distance
                float punchDistance = Vector3.Distance(punchStartPos, hit.point);

                // Calculate elapsed time
                float elapsedTime = Time.time - punchStartTime;

                // Calculate punch speed (meters per second)
                float punchSpeed = punchDistance / elapsedTime;

                // Do something with the punch speed (e.g., display on screen, trigger events)
                Debug.Log("Punch Speed: " + punchSpeed + " m/s");
                speedText.text = punchSpeed.ToString();

                isPunching = false; // Reset punch state
            }
        }
    }



    private void Awake()
    {
        action.started += Pressed;
        action.canceled += Released;
    }

    private void OnDestroy()
    {
        action.started -= Pressed;
        action.canceled -= Released;
    }

    private void OnEnable()
    {
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }

    private void Pressed(InputAction.CallbackContext context)
    {
        runOut = true;

        punchStartPos = handController.transform.position;
        punchStartTime = Time.time;
        isPunching = true;
    }

    private void Released(InputAction.CallbackContext context)
    {
        runOut = false;
    }

}

