using System;
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
    /// Disse eiendommene er satt når GetKeyState blir kalt.
    /// http://sanity-free.org/17/obtaining_key_state_info_in_dotnet_csharp_getkeystate_implementation.html
    /// </summary>
    public class KeyEvent
    {
        private KeyEvent() { }
        [DllImport("user32")]
        private static extern short GetKeyState(int vKey);

        public static KeyStateInfo GetKeyState(Keys key)
        {
            short keyState = GetKeyState((int)key);
            byte[] bits = BitConverter.GetBytes(keyState);
            bool toggled = bits[0] > 0, pressed = bits[1] > 0;
            return new KeyStateInfo(key, pressed, toggled);
        }
    }

    /// <summary>
    /// Struct klasse
    /// </summary>
    public struct KeyStateInfo
    {
        Keys _key;
        bool _isPressed, _isToggled;

        /// <summary>
        /// Konstruktør 
        /// </summary>
        /// <param name="key">Key/Piltast</param>
        /// <param name="ispressed">Om den er trykket</param>
        /// <param name="istoggled">Om den er på/av</param>
        public KeyStateInfo(Keys key, bool ispressed, bool istoggled)
        {
            _key = key;
            _isPressed = ispressed;
            _isToggled = istoggled;
        }
        public static KeyStateInfo Default
        {
            get
            {
                return new KeyStateInfo(Keys.None,false,false);
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

