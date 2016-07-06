using System;
using System.Linq;
using System.Runtime.InteropServices;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using Color = System.Drawing.Color;
using SharpDX;

namespace WatermarkDisabler
{
    class Program
    {
        static void Main(string[] args)
        {
            Hacks.RenderWatermark = false;
        }
    }
}
