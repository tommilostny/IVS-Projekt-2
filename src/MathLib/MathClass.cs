using System;

namespace MathLib
{
    public class MathClass
    {
        public MathClass() { }

        //Zde doplňte vaše matematické funkce
        //Return first prime number after given number.
        public long FirstPrimeNumberAfterNumber(long number){
            if(number < 1) number = 1;  //Negative numbers are not prime numbers
            if(number % 2 == 0) number--;   // Make number odd
            bool finded = false;  
            bool findedFactor;
            while(!finded){
                findedFactor = true;
                number+=2;
                for(int i = 3;i <= Math.Sqrt(number); i += 2){    // ----TODO: Replace with our Sqrt function
                    if(number % i == 0) {
                        findedFactor = true;
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
