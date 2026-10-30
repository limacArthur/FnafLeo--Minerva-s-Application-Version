using Godot;
using System;

public static class General
{
	public static int ConvertBoolToInt(bool value)
	{
		if (value)
		{
			return 1;
		} else
		{
			return 0;
		}
	}
}
