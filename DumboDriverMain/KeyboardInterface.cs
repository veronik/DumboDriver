using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumboDriver
{
    public class KeyboardInterface : IUserController
    {
        public void ProcessInput()
        {
            if (Console.KeyAvailable)
            {
                var keyInfo = Console.ReadKey(true);
                if (keyInfo.Key.Equals(ConsoleKey.LeftArrow))
                {
                    if (this.OnLeftPressed != null)
                    {
                        this.OnLeftPressed(this, new EventArgs());
                    }
                }

                if (keyInfo.Key.Equals(ConsoleKey.RightArrow))
                {
                    if (this.OnRightPressed != null)
                    {
                        this.OnRightPressed(this, new EventArgs());
                    }
                }
            }
        }

        public event EventHandler OnLeftPressed;

        public event EventHandler OnRightPressed;
    }
}
