using UnityEngine;
using System.Collections;

public class CarBehaviour2a : CarBehaviour {
	
	void LateUpdate()
	{
		// YOUR CODE HERE
		float leftSensor = 0, rightSensor = 0;

		//Read sensor values
		if (DetectLights)
        {
			//Comportamento agressivo em relação à luz
			//Sensor esquerdo ligado à roda direita e sensor direiro ligado à roda esquerda
			rightSensor = LeftLD.GetOutput();
			leftSensor = RightLD.GetOutput();						
			print("Left:" + leftSensor + "   Right:" + rightSensor);
		}

		if (DetectCars)
        {
			leftSensor = LeftCD.GetOutput();
			rightSensor = RightCD.GetOutput();
			print("Left:" + leftSensor + "   Right:" + rightSensor);
		}


		//Calculate target motor values
		//Velocidade de cada roda proporcional ao valor do sensor
		m_LeftWheelSpeed = leftSensor * MaxSpeed;
		m_RightWheelSpeed = rightSensor * MaxSpeed;




		/*
		if (DetectCars)
        {
			m_LeftWheelSpeed = leftSensor * MaxSpeed;
			m_RightWheelSpeed = rightSensor * MaxSpeed;
		}
        else
        {
			//Experimental stuff
			if (m_Rigidbody.position.magnitude < 23)
			{
				m_LeftWheelSpeed = MaxSpeed;
				m_RightWheelSpeed = MaxSpeed;
			}
			else
			{
				m_LeftWheelSpeed = MaxSpeed/4;
				m_RightWheelSpeed = 0;
			}
		}
        */
	}
}
