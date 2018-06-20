
public class CurrentGameStateService
{
	public enum GameStates
	{
		GamePlay,
		SummarySuccess,
		SummaryFailure
	};
	public GameStates CurrentGameState;
}
