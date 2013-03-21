using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Lotto
{
    /// <summary>
    /// Simulate Lotto game provider "Danske Spil"
    /// Replace comment with your code
    /// </summary>
    /// <author> Steffen Skov</author>
    class DanskeSpil
    {
        // define a DELEGAT so it can sende Lotto numbers to subscribes
		public delegate void LottoPlayerHandler(int[] num);
        // Create an EVENT or a delegate instance
		public event LottoPlayerHandler newLottoNumberEvent;

        static void Main(string[] args)
        {
            DanskeSpil ds = new DanskeSpil();
            LottoPlayer pl = new LottoPlayer("Lucas", ds);
			LottoPlayer pl2 = new LottoPlayer("Ruben", ds);
            // Try to create more player with different numbers
            // When number is set remember to catch exception
            ds.Draw();
        }

        /// <summary>
        /// This method simulate drawing at DanskeSpil
        /// </summary>
        public void Draw()
        {
            Random n = new Random(DateTime.Now.Millisecond);
            int [] num = new int[7];
			//int[] num = { 1, 3, 5, 7, 9, 11, 13 };
            for (;;)
            {
                for (int i = 0; i <7; i++) num[i] = n.Next(1,36);
                // To increase the probability so only one of numbers will change
                Thread.Sleep(1000);
				Console.WriteLine(num[0] + " " + num[1] + " " + num[2] + " " + num[3] + " " + num[4] + " " + num[5] + "\n");
                // FIRE the event
				newLottoNumberEvent(num);
            }
        }
    }

}
