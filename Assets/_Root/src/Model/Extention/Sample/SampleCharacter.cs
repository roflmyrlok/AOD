namespace Model
{
	using System;

	public class SampleCharacter : Character<ISampleView>
	{
		SampleCharacter()
		{
			TypedView.ShowSampleAction();
		}
	}
}