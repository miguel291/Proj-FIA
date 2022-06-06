using UnityEngine;
using System.Collections;
using System.Linq;
using System;

public class LightDetectorLinearScript : LightDetectorScript {

	public override float GetOutput()
	{
        //Linear
        //Quanto mais próximo o sensor de um foco de luz, maior o valor devolvido pelo sensor
        return strength;




        

        //return (float)Math.Pow(0.5,strength);

        // Infinito e círculo
        /*
        float output = (float)(Math.Pow(Math.E, -0.5 * Math.Pow((strength - 0.5) / 0.16, 2)));
        if (strength < 0.25 || strength > 0.75)
        {
            return (float)0.05;
        }
        else if (output > 0.60)
        {
            return (float)0.60;
        }
        else
        {
            return output;
        }
        */
        //Elipse
        /*float output = (float)(Math.Pow(Math.E, -0.5 * Math.Pow((strength - 0.7) / 0.16, 2)));
        if (output < 0.01)
        {
            return (float)0.05;
        }
        
        else
        {
            return (float)output;
        }*/

        //print("Gauss:" + (float)(Math.Pow(Math.E, -0.5 * Math.Pow((output - 0.5) / 0.12, 2)) * 1 / (0.12 * Math.Sqrt(2 * Math.PI))));
        //return (float)(Math.Pow(Math.E, -0.5* Math.Pow((output - 0.5) / 0.12,2)) * 1 / (0.12 * Math.Sqrt(2 * Math.PI)));
        //return (float)(Math.Pow(Math.E, -0.5 * Math.Pow((output - 0.5) / 0.12, 2)));
        //0.05 e 0.6

    }

    // YOUR CODE HERE
    public override float GetOutputv2()
     {
         if(strength < 0.25 || strength > 0.75)
         {
             return 0;
         }
         else
         {
             return strength;
         }
     }

     public override float GetOutputv3()
     {
         if (strength < 0.25 || strength > 0.75)
         {
             return (float)0.05;
         }
         else if(strength > 0.6)
         {
             return (float)0.6;
         }
         else
         {
             return strength;
         }
     }

}
