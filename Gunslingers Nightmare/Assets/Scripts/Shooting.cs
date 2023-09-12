using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Runtime.InteropServices;




public class Shooting : MonoBehaviour
{
    //import för att kunna sätta mus pekaren till en viss position
    [DllImport("user32.dll")]
    static extern bool SetCursorPos(int X, int Y);
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;

    private Vector2 lastMpositoin;

    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        lastMpositoin = Mouse.current.position.ReadValue();
    }

    // Update is called once per frame
    void Update()
    {
        

        // för controller
        if (Gamepad.all[0].rightStick.IsPressed())
        {
            Vector3 ControllerPos = Gamepad.all[0].rightStick.value;
            float ControtZ = Mathf.Atan2(ControllerPos.y, ControllerPos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, ControtZ);

            // sätta muspekaren på rotate point, gick sådär haha gjorde en annan lösning men lite fulare då muspekaren inte följer med controller input
            // Vector3 screenPos = mainCam.WorldToScreenPoint(transform.position);

            // Debug.Log(screenPos.x);
            // Debug.Log(screenPos.y);

            // SetCursorPos((int)transform.position.x, (int)transform.position.y);
            // Input.mousePosition.Set(0, 0, 0);
        }
        // för mus n keyboard
        else if (Mouse.current.position.ReadValue() != lastMpositoin || Input.GetMouseButton(0)  )
        {
            Debug.Log(Mouse.current.position.ReadValue().magnitude);
            mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

            Debug.Log(mainCam.ScreenToWorldPoint(Input.mousePosition));

            Vector3 rotation = mousePos - transform.position;

            float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0, 0, rotZ);
        }

        if ((Gamepad.all[0].rightTrigger.IsPressed() || Input.GetMouseButton(0)) && canFire)
        {
            canFire = false;
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
        }
        //Shoot cooldown
        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }
        
        lastMpositoin = Mouse.current.position.ReadValue();

    }
}
