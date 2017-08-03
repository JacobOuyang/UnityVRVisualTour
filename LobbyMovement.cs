using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LobbyMovement: MonoBehaviour
{
    public GameObject player;
    public GameObject screen;
    SteamVR_Controller.Device device;
    SteamVR_TrackedObject controller;
    Vector2 touchpad;
    
    private Vector3 playerPos;
    public Vector3 startPos;
    public int vertical;
    public int horizontal;

    // Use this for initialization
    private Texture[] lobbyforwardmiddle = new Texture[1000];
    private Texture[] LobbyLeft = new Texture[1000];
    private Texture[] LobbyLeftLeft = new Texture[1000];
    private Texture[] lobbyMiddle = new Texture[1000];
    private Texture[] lobbyRight = new Texture[1000];
    private List<Texture[]> whicharray = new List<Texture[]>();
    // Use this for initialization
    void Start()
    {

        controller = gameObject.GetComponent<SteamVR_TrackedObject>();
        vertical = 0;
        horizontal = 1;
        screen.GetComponent<Renderer>().material.EnableKeyword("_MainTex");

        lobbyforwardmiddle = Resources.LoadAll<Texture>("Textures/Lobby/lobbyforwardmiddle");
        LobbyLeft = Resources.LoadAll<Texture>("Textures/Lobby/LobbyLeft");
        LobbyLeftLeft = Resources.LoadAll<Texture>("Textures/Lobby/LobbyLeftLeft");
        lobbyMiddle = Resources.LoadAll<Texture>("Textures/Lobby/lobbyMiddle");
        lobbyRight = Resources.LoadAll<Texture>("Textures/Lobby/lobbyRight");
        print("loading complete");
        startPos = player.transform.position;
        whicharray.Add(LobbyLeft);
        whicharray.Add(lobbyMiddle);
        whicharray.Add(lobbyRight);
        whicharray.Add(lobbyforwardmiddle);
        whicharray.Add(LobbyLeftLeft);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //print(whicharray[horizontal][vertical]);
        screen.GetComponent<Renderer>().material.SetTexture("_MainTex", whicharray[horizontal][vertical]);
        
        device = SteamVR_Controller.Input((int)controller.index);



        if (device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
        {
           // print(whicharray[counter] + "check 1");
            //print(touchpad.y);
            touchpad = device.GetAxis(EVRButtonId.k_EButton_SteamVR_Touchpad);
            if (touchpad.x >= 0.5 || touchpad.x <= -0.5 || touchpad.y >= 0.5 || touchpad.y <= -0.5)
            {
                if (touchpad.x > 0.5f & device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
                {
                    if (horizontal <=2 & horizontal >0)
                        horizontal -= 1;
                        print(horizontal);
                    
                }
                if (touchpad.x < -0.5f & device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
                {
                    if (horizontal == 2 & vertical >= 300)
                    {
                        horizontal = 4;
                        vertical = 0;
                    }
                    if (horizontal >= 0 & horizontal < 2)
                        horizontal += 1;
                    
                }

                if (touchpad.y > 0.5f)
                {
                    print("vertical");
                    
                    if (vertical < whicharray[horizontal].Length - 2)
                    {
                        print("forward");
                        vertical += 1;
                        screen.GetComponent<Renderer>().material.SetTexture("_MainTex", whicharray[horizontal][vertical]);
                        print(whicharray[horizontal].Length - 2);
                    }
                  
                    if (vertical == whicharray[horizontal].Length - 2 & horizontal < 2)
                    {
                        print("change");
                        horizontal = 3;
                        vertical = 0;
                    }
                }
                if (touchpad.y < -0.5)
                {
                    print(vertical);
                    if (vertical > 0)
                        vertical -= 1;
                    if (vertical ==0 & horizontal >2)
                    {
                        print("change");
                        horizontal -= 2;
                        vertical = whicharray[horizontal].Length - 2;
                    }
                }
                     
            }

        }

    }
}
