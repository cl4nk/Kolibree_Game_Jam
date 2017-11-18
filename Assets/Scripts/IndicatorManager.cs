using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorManager : MonoBehaviour {

    public GameObject tooth_bottom_left_interior;
    public GameObject tooth_bottom_left_exterior;
    public GameObject tooth_bottom_left_top;

    public GameObject tooth_bottom_right_interior;
    public GameObject tooth_bottom_right_exterior;
    public GameObject tooth_bottom_right_top;

    public GameObject tooth_top_left_interior;
    public GameObject tooth_top_left_exterior;
    public GameObject tooth_top_left_bottom;

    public GameObject tooth_top_right_interior;
    public GameObject tooth_top_right_exterior;
    public GameObject tooth_top_right_bottom;

    public GameObject tooth_bottom_front_interior;
    public GameObject tooth_bottom_front_exterior;

    public GameObject tooth_top_front_interior;
    public GameObject tooth_top_front_exterior;

    public bool active_tooth_bottom_left_interior;
    public bool active_tooth_bottom_left_exterior;
    public bool active_tooth_bottom_left_top;

    public bool active_tooth_bottom_right_interior;
    public bool active_tooth_bottom_right_exterior;
    public bool active_tooth_bottom_right_top;

    public bool active_tooth_top_left_interior;
    public bool active_tooth_top_left_exterior;
    public bool active_tooth_top_left_bottom;

    public bool active_tooth_top_right_interior;
    public bool active_tooth_top_right_exterior;
    public bool active_tooth_top_right_bottom;

    public bool active_tooth_bottom_front_interior;
    public bool active_tooth_bottom_front_exterior;

    public bool active_tooth_top_front_interior;
    public bool active_tooth_top_front_exterior;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update () {

        ActiveOrDesactiveTooth(tooth_bottom_left_interior, active_tooth_bottom_left_interior);
        ActiveOrDesactiveTooth(tooth_bottom_left_exterior, active_tooth_bottom_left_exterior);
        ActiveOrDesactiveTooth(tooth_bottom_left_top, active_tooth_bottom_left_top);

        ActiveOrDesactiveTooth(tooth_bottom_right_interior, active_tooth_bottom_right_interior);
        ActiveOrDesactiveTooth(tooth_bottom_right_exterior, active_tooth_bottom_right_exterior);
        ActiveOrDesactiveTooth(tooth_bottom_right_top, active_tooth_bottom_right_top);

        ActiveOrDesactiveTooth(tooth_top_left_interior, active_tooth_top_left_interior);
        ActiveOrDesactiveTooth(tooth_top_left_exterior, active_tooth_top_left_exterior);
        ActiveOrDesactiveTooth(tooth_top_left_bottom, active_tooth_top_left_bottom);

        ActiveOrDesactiveTooth(tooth_top_right_interior, active_tooth_top_right_interior);
        ActiveOrDesactiveTooth(tooth_top_right_exterior, active_tooth_top_right_exterior);
        ActiveOrDesactiveTooth(tooth_top_right_bottom, active_tooth_top_right_bottom);

        ActiveOrDesactiveTooth(tooth_bottom_front_interior, active_tooth_bottom_front_interior);
        ActiveOrDesactiveTooth(tooth_bottom_front_exterior, active_tooth_bottom_front_exterior);

        ActiveOrDesactiveTooth(tooth_top_front_interior, active_tooth_top_front_interior);
        ActiveOrDesactiveTooth(tooth_top_front_exterior, active_tooth_top_front_exterior);
    }


    void AllDesactive()
    {
        active_tooth_bottom_left_interior = false;
        active_tooth_bottom_left_exterior = false;
        active_tooth_bottom_left_top = false;

        active_tooth_bottom_right_interior = false;
        active_tooth_bottom_right_exterior = false;
        active_tooth_bottom_right_top = false;

        active_tooth_top_left_interior = false;
        active_tooth_top_left_exterior = false;
        active_tooth_top_left_bottom = false;

        active_tooth_top_right_interior = false;
        active_tooth_top_right_exterior = false;
        active_tooth_top_right_bottom = false;

        active_tooth_bottom_front_interior = false;
        active_tooth_bottom_front_exterior = false;

        active_tooth_top_front_interior = false;
        active_tooth_top_front_exterior = false;
}

    void ActiveOrDesactiveTooth(GameObject pTooth, bool pBool)
    {
        if (pBool) pTooth.SetActive(true);
        else pTooth.SetActive(false);
    }
}
