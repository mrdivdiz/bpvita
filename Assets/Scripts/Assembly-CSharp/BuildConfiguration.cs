using System;

[Serializable]
public class BuildConfiguration
{
	public bool EnableRovioNews { get; set; }

	public bool EnableAds { get; set; }

	public bool EnableFlurry { get; set; }

	public bool EnableCheats { get; set; }

	public bool LessCheats { get; set; }

	public bool EnableTrialModeSimulation { get; set; }

	public bool EnableIAP { get; set; }

	public string IapProvider { get; set; }

	public string SkynestBackend { get; set; }

	public string SkynestPaymentProvider { get; set; }

	public string SvnRevision { get; set; }

	public string ApplicationVersion { get; set; }

	public string CustomerId { get; set; }

	public bool BuildTypeChina { get; set; }

	public bool BuildTypeAppUp { get; set; }

	public bool BuildTypeHD { get; set; }

	public bool BuildTypeContentLimited { get; set; }

	public bool DevelopmentBuild { get; set; }

	public bool ScriptDebugging { get; set; }
}
