﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace projectcsharp
{
    /// <summary>
    /// Klasse for når du trykker på piltatastene. Klassen har en struct som har tre egenskaper(Key, isPressed, isToggled). 
    /// Disse eiendommene er satt når GetKeyState blir kalt. Key egenskapen er for selve tasten, hvilken tast som blir trykket.
    /// isPressed er om den er trykket(true/false) og isToggled er om den er av eller på(true/false), men det gjelder mest for capslock, numlock osv. 
    /// Det spørs om du skal bruke caps eller ikke.
    /// http://sanity-free.org/17/obtaining_key_state_info_in_dotnet_csharp_getkeystate_implementation.html
    /// </summary>
    public class KeyEvent
    {
        private KeyEvent() { }

        [DllImport("user32")]//forteller kompilatoren hvilken DLL den skal referer til
        private static extern short GetKeyState(int vKey); //Kaller på metode som eksisterer i en DLL

        /// <summary>
        /// Kontruktør
        /// </summary>
        /// <param name="key">Tast</param>
        /// <returns>Tasten, om den er trykket, av/på</returns>
        public static KeyEventInfo GetKeyState(Keys key)
        {
            short keyState = GetKeyState((int)key);
            byte[] bits = BitConverter.GetBytes(keyState);
            bool toggled = bits[0] > 0, pressed = bits[1] > 0;
            return new KeyEventInfo(key, pressed, toggled);
        }
    }

    /// <summary>
    /// Struct klasse
    /// </summary>
    public struct KeyEventInfo
    {
        Keys _key; //tasten
        bool _isPressed, _isToggled; //boolske variabler for taste trykk og av/på

        /// <summary>
        /// Konstruktør 
        /// </summary>
        /// <param name="key">Key/Piltast</param>
        /// <param name="ispressed">Om den er trykket</param>
        /// <param name="istoggled">Om den er på/av(gjelder f.eks caps lock osv)</param>
        public KeyEventInfo(Keys key, bool ispressed, bool istoggled)
        {
            _key = key;
            _isPressed = ispressed;
            _isToggled = istoggled;
        }
        public static KeyEventInfo Default
        {
            get
            {
                return new KeyEventInfo(Keys.None, false, false);
            }
        }
        public Keys Key
        {
            get { return _key; }
        }
        public bool IsPressed
        {
            get { return _isPressed; }
        }
        public bool IsToggled
        {
            get { return _isToggled; }
        }
    }
}

