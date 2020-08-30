using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DigitalRuby.RainMaker
{
	public class RainController : MonoBehaviour
	{
		
		public bool raining = false;
		
		public BaseRainScript rain;
		
		void Update()
		{	
			if (raining == false) {
				if (Random.Range(1, 15000) == 1) {
					
					raining = true;
					rain.RainIntensity = Random.Range(0.1f, 1.0f);
					
				}
			}
			
			if (raining == true) {
				if (Random.Range(1, 9000) == 1) {
					
					raining = false;
					rain.RainIntensity = 0.0f;
					
				}
			}
		}
	}
}
