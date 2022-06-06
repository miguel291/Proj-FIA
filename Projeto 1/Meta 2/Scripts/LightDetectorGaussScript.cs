using UnityEngine;
using System.Collections;
using System.Linq;
using System;


public class LightDetectorGaussScript : LightDetectorScript {
	static double lim_down = 0.32;
	static double lim_up = 0.8;
	static double res_up;
	static double res_down;
		
	static double diference; 
	static float stdDev = 0.5f; 
	static float mean = 0.4f; 
	static float min_y;

	// Get gaussian output value
	public override float GetOutput1()
	{
		if(circle_infinite){
			res_up = 0.8;
			res_down = 0.0;
			diference = 0.0; 
		}else{
			diference = 0.2022; 
			res_up = lim_up * 1.618;
			res_down = 0.23;
		}
		float a = stdDev/Mathf.Sqrt(2* Mathf.PI);
		
		if(strength < lim_down || strength > lim_up){
			return (float)lim_down;
		}
		/*
		if(strength > lim_up){
			return (float)lim_up;
		}*/
		
		float response = a * Mathf.Exp(-(Mathf.Pow(strength-mean,2)/(2* Mathf.Pow(stdDev,2))));
		if(response > res_up){
			return (float)res_up;
		}
		if(response < res_down){
			return (float)res_down;
		}
		
		return (float)response;
	}
	public override float GetOutput2()
	{
		if(circle_infinite){
			res_up = 0.8;
			res_down = 0.0;
			diference = 0.0; 
		}else{
			diference = 0.2022; 
			res_up = lim_up * 1.618;
			res_down = 0.23;
		}
		double lim_down2 = lim_down-(diference*lim_down);
		double lim_up2 = lim_up;
		double res_up2 = lim_up2 * 1.618;
		double res_down2 = res_down-(diference*res_down);

		float a = stdDev/Mathf.Sqrt(2* Mathf.PI);
		
		if(strength < lim_down2 || strength > lim_up){
			return (float)lim_down2;
		}
		/*
		if(strength > lim_up2){
			return (float)lim_up2;
		}*/
		
		float response = a * Mathf.Exp(-(Mathf.Pow(strength-mean,2)/(2* Mathf.Pow(stdDev,2))));
		if(response > res_up2){
			return (float)res_up2;
		}
		if(response < res_down2){
			return (float)res_down2;
		}
		
		return (float)response;
	}


}
