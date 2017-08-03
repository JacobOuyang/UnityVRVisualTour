using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class DynamicMovement : MonoBehaviour
{
    public GameObject player;
    public GameObject screen;
    SteamVR_Controller.Device device;
    SteamVR_TrackedObject controller;
    Vector2 touchpad;
    private float sensitivityX = 1.5F;
    private Vector3 playerPos;
    public Vector3 startPos;
    public int counter;

    // Use this for initialization
    private Texture[] textarray = new Texture[1000];
    private Texture[] textarray2 = new Texture[700];
    private Texture[] whicharray;
    // Use this for initialization
    void Start()
    {
        
        controller = gameObject.GetComponent<SteamVR_TrackedObject>();
        counter = 0;
        screen.GetComponent<Renderer>().material.EnableKeyword("_MainTex");

        textarray = Resources.LoadAll<Texture>("Textures/TestMovment");
        textarray2 = Resources.LoadAll<Texture>("Textures/Hallway");
        print(textarray.Length);
        startPos = player.transform.position;
        whicharray = textarray;
    }

    // Update is called once per frame
    void Update()
    {
        device = SteamVR_Controller.Input((int)controller.index);


        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
            player.transform.position = startPos;


        if (device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
        {
            print(whicharray[counter] + "check 1");
            //print(touchpad.y);
            touchpad = device.GetAxis(EVRButtonId.k_EButton_SteamVR_Touchpad);
           
            if (touchpad.y > 0.5 || touchpad.y < -0.5)
            {
                
                if (touchpad.y >= 0.3)
                {
                    print(textarray[counter] + "check 2");
                    
                    counter += 1;
                    screen.GetComponent<Renderer>().material.SetTexture("_MainTex", whicharray[counter]);
                    //player.transform.position = startPos;
                }
                if (touchpad.y <= -0.3 & counter !=0)
                {
                    counter -= 1;
                    print(textarray[counter] + "check 3");
                    screen.GetComponent<Renderer>().material.SetTexture("_MainTex", whicharray[counter]);
                    
                }
                if (counter >= whicharray.Length - 2 & whicharray == textarray & touchpad.y >0)
                {
                    
                    whicharray = textarray2;
                    counter = 0;
                }
                if (counter == 0 & whicharray == textarray2 & touchpad.y <0)
                {
                    whicharray = textarray;
                    counter = textarray.Length - 2;
                }
            }
            
          
            
            if (touchpad.x > 0.5 || touchpad.x < -0.5)
            {
                print(touchpad.x + "x");
                player.transform.Rotate(0, touchpad.x * sensitivityX * 0.1f, 0);
            }
           


        }

    }
}
