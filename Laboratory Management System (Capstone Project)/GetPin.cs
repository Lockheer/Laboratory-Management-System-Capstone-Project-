using System;

namespace Laboratory_Management_System__Capstone_Project_
{
    internal class GetPin
    {
        public string Pin() 
        {
            string pin = "";
            int[] pinArray = new int[6];
            Random random = new Random();

            for (int i = 0;i < pinArray.Length;i++)
            {
                pinArray[i] = random.Next(9);
                if (i == 0)
                {
                    pin = pinArray[i].ToString();
                }
                else
                {
                    pin += pinArray[i].ToString();
                }

            }

            return pin;
        }
    }
}
