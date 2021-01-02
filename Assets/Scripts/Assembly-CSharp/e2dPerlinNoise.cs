public class e2dPerlinNoise
{
	public e2dPerlinNoise(int octaves, float amplitude, int frequency, float persistence)
	{
		this.mOctavesCount = octaves;
		if (frequency < 2)
		{
			frequency = 2;
		}
		if (amplitude <= 0f)
		{
			amplitude = 0.1f;
		}
		if (this.mOctavesCount < 1)
		{
			this.mOctavesCount = 1;
		}
		int num = frequency;
		float num2 = amplitude;
		this.mOctaves = new e2dPerlinOctave[this.mOctavesCount];
		for (int i = 0; i < this.mOctavesCount; i++)
		{
			this.mOctaves[i] = new e2dPerlinOctave(num2, num);
			num2 *= persistence;
			num *= 2;
		}
	}

	public void Regenerate()
	{
		for (int i = 0; i < this.mOctavesCount; i++)
		{
			this.mOctaves[i].Regenerate();
		}
	}

	public float GetValue(float x)
	{
		float num = 0f;
		for (int i = 0; i < this.mOctavesCount; i++)
		{
			num += this.mOctaves[i].GetValue(x);
		}
		return num;
	}

	private int mOctavesCount;

	private e2dPerlinOctave[] mOctaves;
}
