using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class IntervalAvailabilityStatesService
{
	/*
	 * dzięki temu enumowi prędkość pojawiania się kolumn nie zwiększa się dwukrotnie, kiedy warunek jest spełniony do momentu zdobycia kolejnego punktu
	 */ 

	public enum IntervalLockStates                                        
	{
		Unlocked,
		Locked
	};
	public static IntervalLockStates IntervalLock;                            
}
