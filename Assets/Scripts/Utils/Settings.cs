using System;
using UnityEngine;

namespace Settings
{
    public static class ControlButtons
    {
        public static bool ENABLED = true;

        public static bool LEFT 
        { 
            get
            {
                return Input.GetKeyDown(PCControlButtons.LEFT);
            } 
        }

        public static bool RIGHT
        {
            get
            {
                return Input.GetKeyDown(PCControlButtons.RIGHT);
            }
        }

        public static bool RUNHOLD
        {
            get
            {
                return Input.GetKey(PCControlButtons.RUN);
            }
        }

        public static bool JUMPandUP
        {
            get
            {
                return Input.GetKeyDown(PCControlButtons.JUMPandUP);
            }
        }
        public static bool INVENTORYandDOWN
        {
            get
            {
                return Input.GetKeyDown(PCControlButtons.INVENTORYandDOWN);
            }
        }
        public static bool SWITCHSPELL
        {
            get
            {
                return Input.GetKeyDown(PCControlButtons.SWITCHSPELL);
            }
        }
        public static bool USESPELL
        {
            get
            {
                return Input.GetKeyDown(PCControlButtons.USESPELL);
            }
        }
        public static bool USESPELLHOLD
        {
            get
            {
                return Input.GetKey(PCControlButtons.USESPELL);
            }
        }
        public static bool INTERACT
        {
            get
            {
                return Input.GetKeyDown(PCControlButtons.INTERACT);
            }
        }

        public static int xAxisRaw
        {
            get
            {
                return ENABLED ? PCControlButtons.xAxisRaw : 0;
            }
        }

        public static int yAxisRaw
        {
            get
            {
                return ENABLED ? PCControlButtons.yAxisRaw : 0;
            }
        }
    }

    public static class PCControlButtons
    {
        public static KeyCode LEFT = KeyCode.A;
        public static KeyCode RIGHT = KeyCode.D;
        public static KeyCode RUN = KeyCode.LeftShift;

        public static KeyCode JUMPandUP = KeyCode.W;

        public static KeyCode INVENTORYandDOWN = KeyCode.S;

        public static KeyCode SWITCHSPELL = KeyCode.Q;

        public static KeyCode USESPELL = KeyCode.Space;

        public static KeyCode INTERACT = KeyCode.E;

        public static int xAxisRaw
        {
            get
            {
                return -Convert.ToInt32(Input.GetKey(LEFT)) + Convert.ToInt32(Input.GetKey(RIGHT));
            }
        }

        public static int yAxisRaw
        {
            get
            {
                return -Convert.ToInt32(Input.GetKey(INVENTORYandDOWN)) + Convert.ToInt32(Input.GetKey(JUMPandUP));
            }
        }
    }
}