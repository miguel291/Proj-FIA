using UnityEngine;
using System.Collections;
using System.Linq;
using System;

public class CarDetectorScript : MonoBehaviour {

	public float angle = 360;
	public bool ApplyThresholds, ApplyLimits;
	public float MinX, MaxX, MinY, MaxY;
    private bool useAngle = true;

	public float minDistance;
	public float output;
	public int numObjects;

	void Start()
	{
		output = 0;
		numObjects = 0;

		if (angle > 360)
		{
			useAngle = false;
		}
	}

	void Update()
	{
		minDistance = 0;
		GameObject[] cars = null;       //Arraylist de carros
		if (useAngle)
		{
			cars = GetVisibleCars();	//Só devolve os carros no ângulo de visão
		}
		else
		{
			cars = GetAllCars();		//Devolve todos os carros
		}
		GameObject closestCar = null;

		//Encontra o carro mais próximo e calcula a distância a que está
		foreach (GameObject car in cars)
		{
			//print (1 / (transform.position - light.transform.position).sqrMagnitude);
			float carDistance = (transform.position - car.transform.position).sqrMagnitude;
			print("carDistance:" + carDistance);
			if (carDistance < minDistance || minDistance == 0)
            {
                minDistance = carDistance;
				closestCar = car;
            }
			//Debug.DrawLine (transform.position, light.transform.position, Color.red);
		}
		// A velocidade é proporcional à distância do carro mais próximo
		output = (float)0.010*minDistance;
		if(output > 20)
        {
			output = 20;
        }
		//output = 1 / (minDistance + 1);

	}

	public virtual float GetOutput1() { throw new NotImplementedException(); }
	public virtual float GetOutput2() { throw new NotImplementedException(); }

	// Returns all "CarToFollow" tagged objects. The sensor angle is not taken into account.
	GameObject[] GetAllCars()
	{
		return GameObject.FindGameObjectsWithTag("CarToFollow");
	}

	// Returns all "CarToFollow" tagged objects that are within the view angle of the Sensor. 
	// Only considers the angle over the y axis. Does not consider objects blocking the view.
	GameObject[] GetVisibleCars()
	{
		ArrayList visibleCars = new ArrayList();
		float halfAngle = angle / 2.0f;
		//Só considera os objetos com a Tag "CarToFollow"
		GameObject[] cars = GameObject.FindGameObjectsWithTag("CarToFollow");

		foreach (GameObject car in cars)
		{
			Vector3 toVector = (car.transform.position - transform.position);
			Vector3 forward = transform.forward;
			toVector.y = 0;
			forward.y = 0;
			float angleToTarget = Vector3.Angle(forward, toVector);

			if (angleToTarget <= halfAngle)
			{
				visibleCars.Add(car);
			}
		}

		return (GameObject[])visibleCars.ToArray(typeof(GameObject));
	}


}
