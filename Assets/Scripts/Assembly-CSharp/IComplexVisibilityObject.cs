using System.Collections.Generic;

public interface IComplexVisibilityObject
{
	List<ComplexVisibilityManager.Condition> ShowConditions { get; }

	List<ComplexVisibilityManager.Condition> HideConditions { get; }

	void OnStateChanged(bool newState);
}
