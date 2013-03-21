using System;
using System.Collections.Generic;
using System.Text;

namespace Lotto
{
	/// <summary>
	/// Represent a Lotto Player
	/// </summary>
	/// <author> Steffen Skov</author>
	class LottoPlayer
	{
		DanskeSpil ds;
		private string name = null;
		public LottoPlayer(string name, DanskeSpil ds)
		{
			this.name = name;
			this.ds = ds;
			RandomNumbers();
			// Subscribe the Lotto drawing by DanskeSpil
			ds.newLottoNumberEvent += new DanskeSpil.LottoPlayerHandler(CheckMyNum);
			ds.newLottoNumberEvent2 += new DanskeSpil.LottoPlayerHandler2(RandomNumbers);
		}
		private static Random n = new Random(DateTime.Now.Millisecond);
		private int[] myNum = new int[7];
		private void RandomNumbers()
		{
			for (int i = 0; i < 7; i++) myNum[i] = n.Next(1, 36);
		}
		/// <summary>
		/// My Lotto nummers
		/// 7 numbers between 1 and 36
		/// </summary>
		public int[] MyNum
		{
			get { return myNum; }
			set
			{
				if (LegalNumbers(value) == true)
					myNum = value;
				else
					throw new Exception("Wrong numbers");
			}
		}

		/// <summary>
		/// Check for legal Lotto numbers
		/// </summary>
		/// <param name="n"></param>
		/// <returns></returns>
		private bool LegalNumbers(int[] n)
		{
			bool legal = true;
			if (n.Length == 7)
			{
				for (int i = 0; i < 7; i++)
					if (n[i] > 37 || n[i] < 0)
						legal = false;
			}
			else
				legal = false;
			return legal;
		}

		/// <summary>
		/// Event handler method
		/// </summary>
		/// <param name="n">Lotto numbers</param>
		public void CheckMyNum(int[] n)
		{
			bool luck = true;
			for (int i = 0; i < 7; i++)
			{
				if (n[i] != myNum[i]) luck = false;
			}
			if (luck == true)
				Console.WriteLine(name + ", now you are Millionaire." + " Your numbers were: " + myNum[0] + " " + myNum[1] + " " + myNum[2] + " " + myNum[3] + " " + myNum[4] + " " + myNum[5]);
			else
				Console.WriteLine(name + ", it is a bad day, try again." + " Your numbers were: " + myNum[0] + " " + myNum[1] + " " + myNum[2] + " " + myNum[3] + " " + myNum[4] + " " + myNum[5]);
		}
	}

}
