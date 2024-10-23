using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public bool isGrounded = true;
    public float _rotateSpeed;
    public Rigidbody rb;
    public Camera mainCamera;
    public float currentStamina;
    Vector3 _pos;
    Vector2 _camRot;

    private float sprintSpeed = 8f;
    private float sprintCost = 15f;
    private float maxStamina = 100f;
    private float staminaRegenRate = 10f;
    private float endStamina = 0;
    void Start()
    {
        currentStamina = maxStamina;
    }
    void FixedUpdate()
    {
        //x positie is de horizontale as input
        _pos.x = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        //y positie is de verticale as input
        _pos.z = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        //verander de positie
        transform.Translate(_pos);
    }
    private void Update()
    {
        //x as van de muis
        _camRot.x += Input.GetAxis("Mouse X") * _rotateSpeed;
        //y as van de muis
        _camRot.y += Input.GetAxis("Mouse Y") * _rotateSpeed;
        //y as van de camera vast zetten tuss -45 en 45 graden
        _camRot.y = Mathf.Clamp(_camRot.y, -45, 45);
        //zet de camera rotatie
        mainCamera.transform.rotation = Quaternion.Euler(-_camRot.y, _camRot.x, 0f);
        //zet de speler rotatie
        transform.rotation = Quaternion.Euler(0f, _camRot.x, 0f);
        //als LShift en stamina is meer dan 0
        if(Input.GetKey(KeyCode.LeftShift) && currentStamina > endStamina)
        {//checks if leftshift is pressed & if currenstamina is bigger than endstamina so above 0 and switched to sprintspeed
         //& gets cost of the currenstamina until its under 10

            moveSpeed = sprintSpeed;
            currentStamina -= sprintCost * Time.deltaTime;
            
        }
        else
        {//switches back to normal speed & calculates for the regen of the currentstamina + regenrate over time until its max(100)
            moveSpeed = 5f;
            currentStamina = Mathf.Min(currentStamina + staminaRegenRate * Time.deltaTime, maxStamina);
        }
    }
    public float GetCurrentStamina()//returns float for currentstamina
    {
        return currentStamina;
    }
    public float GetMaxStamina()//returns for maxstamina
    {
        return maxStamina;
    }
}
