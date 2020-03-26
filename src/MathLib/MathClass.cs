using System;

namespace MathLib
{
    public static class MathClass
    {
        // Zde doplňte vaše matematické funkce

        // Return first prime number after given number.
        public static long FirstPrimeNumberAfterNumber(long number){
            if (number < 2) return 2; // 2 is first prime number
            if(number % 2 == 0) number--;   // Make number odd
            bool finded = false;  
            bool findedFactor;
            while(!finded){
                findedFactor = true;
                number+=2;
                for(int i = 3;i <= Math.Sqrt(number); i += 2){    // ----TODO: Replace with our Sqrt function
                    if(number % i == 0) {
                        findedFactor = false;
                        break;
                    }
                }
                if(findedFactor){
                        finded = true;
                }
            }
            return number;    
        }
    }
}
