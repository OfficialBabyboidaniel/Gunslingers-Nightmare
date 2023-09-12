using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class BulletScript : MonoBehaviour
{

    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();

        //för controller
        GameObject RotatePoint = GameObject.FindGameObjectWithTag("RotatePoint");
        if (Gamepad.all[0].rightTrigger.IsPressed())
        {
            Vector3 ControllerPos = Gamepad.all[0].rightStick.value;
            if (!Gamepad.all[0].rightStick.IsPressed())
            {
                Debug.Log("right stick not being triggered when shooting");
                Vector3 direction = RotatePoint.transform.position - transform.position;
                Vector3 rotation = transform.position - RotatePoint.transform.position;
                rb.velocity = new Vector2(-direction.x, -direction.y).normalized * force;
                float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0, 0, rot + 90);
                //rb.velocity = new Vector2(RotatePoint.transform.rotation.x, RotatePoint.transform.rotation.y).normalized * force;
            }
            else
            {
                rb.velocity = new Vector2(ControllerPos.x, ControllerPos.y).normalized * force;

            }
           
        }
        //för mus
        else
        {
            mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = mousePos - transform.position;
            Vector3 rotation = transform.position - mousePos;
            rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
            float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rot + 90);
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("OnCollisionEnter2D");
        Destroy(gameObject);
    }
}
