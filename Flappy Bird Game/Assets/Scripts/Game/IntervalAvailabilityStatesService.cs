using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class IntervalAvailabilityStatesService
{
	public enum IntervalLockStates                                        // SERWIS COLUMNY+PLAYERA
	{
		Unlocked,
		Locked
	};
	public static IntervalLockStates IntervalLock;                              // SERWIS COLUMNY+PLAYERA
}
