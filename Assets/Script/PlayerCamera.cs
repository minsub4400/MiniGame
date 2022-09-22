using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
   // [SerializeField]
   // private float rotCamXAxisSpeed = 5;
   // [SerializeField]
   // private float rotCamYAxisSpeed = 3;

   // private float limitMinx = -80; // 카메라x축 회전범위 최소 
   // private float limitMaxx = 50;  // 카메라y축 회전범위 최소 
   // private float eulerAngleX;
   // private float eulerAngleY;  

   // // Start is called before the first frame update
   //public void UpdateRotate(float mouseX,float mouseY)
   // {
   //     eulerAngleY += mouseX * rotCamYAxisSpeed;
   //     eulerAngleX -= mouseY * rotCamXAxisSpeed;

   //     eulerAngleX = ClampAngle(eulerAngleX, limitMinx, limitMaxx);

   //     transform.rotation = Quaternion.Euler(eulerAngleX,eulerAngleY, 0);
   // }

   //private float ClampAngle(float angle,float min,float max)
   // {
   //     if (angle < -360) angle += 360;
   //     if (angle >  360) angle -= 360; 
   //     return Mathf.Clamp(angle, min, max);
   // }
}
