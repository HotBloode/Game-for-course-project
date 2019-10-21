using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
    private float camSpeedX;
    private float camSpeedY;
    public float zoomSpeed; 
    public float mouseSensitivity; //чувствительность мыши при вращении камеры  

    private Transform _myTransform; //здесь кэширую свойство transform камеры

    // Use this for initialization
    void Start()
    {
        _myTransform = transform;
        camSpeedX = 70.0f;
        camSpeedY = 50.0f;
        zoomSpeed = 5000.0f;
        mouseSensitivity = 150.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //преобразуем скорость по фреймам в скорость по времени
        float speedModX = camSpeedX * Time.deltaTime;
        float speedModY = camSpeedY * Time.deltaTime;
        float zoomMod = zoomSpeed * Time.deltaTime;
        float sensMod = mouseSensitivity * Time.deltaTime;

        //движение камеры влево-вправо
        //при управлении клавишами стрелками
        _myTransform.Translate(Vector3.right * Input.GetAxis("Horizontal") * speedModX, Space.Self);
        _myTransform.Translate(Vector3.up * Input.GetAxis("Vertical") * speedModY, Space.Self);

        //при управлении мышью (достижение края экрана)
        //if (Input.mousePosition.x <= 0) _myTransform.Translate(Vector3.right * -1 * speedModX, Space.Self);
        //if (Input.mousePosition.x >= Screen.width) _myTransform.Translate(Vector3.right * 1 * speedModX, Space.Self);


       
        //if (Input.mousePosition.y <= 50) _myTransform.Translate(Vector3.up * -1 * speedModY, Space.Self);
        //if (Input.mousePosition.y >= Screen.height - 50) _myTransform.Translate(Vector3.up * 1 * speedModY, Space.Self);
      


   


        //приближение-удаление
        _myTransform.Translate(Vector3.forward * Input.GetAxis("Mouse ScrollWheel") * zoomMod, Space.Self);

        //поворот камеры
        if (Input.GetMouseButton(1))
        {
            _myTransform.Rotate(-Input.GetAxis("Mouse Y") * sensMod, 0, 0, Space.Self);
            _myTransform.Rotate(0, Input.GetAxis("Mouse X") * sensMod, 0, Space.World);
        }
    }
}
