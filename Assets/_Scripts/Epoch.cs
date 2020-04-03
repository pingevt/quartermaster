using UnityEngine;
using System.Collections;
using System;

public static class Epoch  {

	private static DateTime epochStart = new DateTime(2020, 1, 1, 0, 0, 0, DateTimeKind.Utc);

	public static double Current()
	{
		double currentEpochTime = (DateTime.UtcNow - epochStart).TotalSeconds;

		return currentEpochTime;
	}

	public static double SecondsElapsed(double t1)
	{
		double difference = Current() - t1;
		return difference;

//		return Mathf.Abs(difference);
	}

	public static double SecondsElapsed(double t1, double t2)
	{
		double difference = t1 - t2;
		return difference;

//		return Mathf.Abs(difference);
	}

}