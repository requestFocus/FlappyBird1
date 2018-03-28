using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class IntervalAvailabilityStatesService
{
	public enum IntervalLockStates                                        
	{
		Unlocked,
		Locked
	};
	public static IntervalLockStates IntervalLock;                            
}
