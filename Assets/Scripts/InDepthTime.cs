using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InDepthTime : MonoBehaviour
{
    public LightCycle time;
	
	public int day = 1;
	public int month = 3;
	public int year = 1;
	
	public int season = 1;
	
    void Update()
    {
        if (time._time >= 125 && time._time <= 125.009) {
			
			day += 1;
			
		}
		
		if (day >= 30 && time._time >= 125 && time._time <= 125.009) {
			
			day = 1;
			month += 1;
			
		}
		
		if (month == 12 && day >= 30) {
			
			day = 1;
			month = 1;
			year +=1 ;
			
		}
		
		if (month == 3) {
			
			season = 1;
			
		}
		
		if (month == 6) {
			
			season = 2;
			
		}
		
		if (month == 10) {
			
			season = 3;
			
		}
		
		if (month == 12) {
			
			season = 4;
			
		}
    }
}
