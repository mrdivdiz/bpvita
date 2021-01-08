using System;
using System.Collections.Generic;
using UnityEngine;

public class Contraption : WPFMonoBehaviour
{
    public ContraptionDataset DataSet
    {
        get
        {
            return this.m_contraptionDataSet;
        }
    }

    public List<BasePart> Parts
    {
        get
        {
            return this.m_parts;
        }
    }

    public bool HasSuperMagnet
    {
        get
        {
            return this.m_hasSuperMagnet;
        }
        set
        {
            if (this.m_hasSuperMagnet != value)
            {
                this.m_hasSuperMagnet = value;
                if (this.m_hasSuperMagnet)
                {
                    Singleton<AudioManager>.Instance.Play2dEffect(WPFMonoBehaviour.gameData.commonAudioCollection.SuperMagnetApplied);
                }
                foreach (BasePart basePart in this.m_parts)
                {
                    if (basePart.m_partType == BasePart.PartType.Pig)
                    {
                        SuperMagnet component = basePart.GetComponent<SuperMagnet>();
                        if (this.m_hasSuperMagnet && component == null)
                        {
                            basePart.gameObject.AddComponent<SuperMagnet>();
                        }
                        else if (!this.m_hasSuperMagnet && component != null)
                        {
                            UnityEngine.Object.Destroy(component);
                        }
                    }
                }
            }
        }
    }

    public bool HasNightVision
    {
        get
        {
            return this.m_hasNightVision;
        }
        set
        {
            if (this.m_hasNightVision != value)
            {
                this.m_hasNightVision = value;
                if (this.m_hasNightVision)
                {
                    Singleton<AudioManager>.Instance.Play2dEffect(WPFMonoBehaviour.gameData.commonAudioCollection.toggleNightVision);
                }
                this.ApplyNightVisionGoggles();
            }
        }
    }

    public bool HasSuperGlue
    {
        get
        {
            return this.m_currentGlue != Glue.Type.None;
        }
    }

    public bool HasAlienGlue
    {
        get
        {
            return this.m_currentGlue == Glue.Type.Alien;
        }
    }

    public bool HasRegularGlue
    {
        get
        {
            return this.m_currentGlue == Glue.Type.Regular;
        }
    }

    public bool HasTurboCharge
    {
        get
        {
            return this.m_hasTurboCharge;
        }
        set
        {
            if (this.m_hasTurboCharge != value)
            {
                this.m_hasTurboCharge = value;
                if (this.m_hasTurboCharge)
                {
                    this.ApplyTurboCharge();
                }
                else
                {
                    this.ResetTurboCharge();
                }
            }
        }
    }

    public bool HasGluedParts
    {
        get
        {
            return this.m_currentGlue != Glue.Type.None && Glue.ContraptionHasGluedParts(this);
        }
    }

    public bool IsRunning
    {
        get
        {
            return this.m_running;
        }
    }

    public bool HasEngine
    {
        get
        {
            return this.m_enginesAmount > 0;
        }
    }

    public Glue.Type CurrentGlue
    {
        get
        {
            return this.m_currentGlue;
        }
    }

    public bool ConnectedToGearbox(BasePart part)
    {
        int connectedComponent = part.ConnectedComponent;
        return this.m_connectedComponents[connectedComponent].hasGearbox;
    }

    public Gearbox GetGearbox(BasePart part)
    {
        int connectedComponent = part.ConnectedComponent;
        return this.m_connectedComponents[connectedComponent].gearbox;
    }

    public void SetCameraTarget(BasePart target)
    {
        this.m_cameraTarget = target;
    }

    public void SetBroken()
    {
        this.m_broken = true;
    }

    public void ChangeOneShotPartAmount(BasePart.PartType type, BasePart.Direction direction, int change)
    {
        int[] array;
        if (this.m_oneShotPartAmount.TryGetValue(type, out array))
        {
            array[(int)direction] += change;
        }
        else if (change > 0)
        {
            array = new int[8];
            array[(int)direction] = change;
            this.m_oneShotPartAmount[type] = array;
        }
    }

    private static byte[] GetBytesFromString(string str)
    {
        byte[] array = new byte[str.Length * 2];
        Buffer.BlockCopy(str.ToCharArray(), 0, array, 0, array.Length);
        return array;
    }

    public void ChangePoweredPartAmount(BasePart.PartType type, BasePart.Direction direction, int change)
    {
        int[] array;
        if (this.m_poweredPartAmount.TryGetValue(type, out array))
        {
            array[(int)direction] += change;
        }
        else if (change > 0)
        {
            array = new int[8];
            array[(int)direction] = change;
            this.m_poweredPartAmount[type] = array;
        }
    }

    public void ChangePushablePartAmount(BasePart.PartType type, BasePart.Direction direction, int change)
    {
        int[] array;
        if (this.m_pushablePartAmount.TryGetValue(type, out array))
        {
            array[(int)direction] += change;
        }
        else if (change > 0)
        {
            array = new int[8];
            array[(int)direction] = change;
            this.m_pushablePartAmount[type] = array;
        }
    }

    public bool HasActiveParts(BasePart.PartType type, BasePart.Direction direction)
    {
        return this.HasOneShotParts(type, direction) || this.HasPoweredParts(type, direction) || this.HasPushableParts(type, direction);
    }

    public bool HasOneShotParts(BasePart.PartType type, BasePart.Direction direction)
    {
        int[] array;
        return this.m_oneShotPartAmount.TryGetValue(type, out array) && array[(int)direction] > 0;
    }

    public bool HasPoweredParts(BasePart.PartType type, BasePart.Direction direction)
    {
        int[] array;
        return this.m_poweredPartAmount.TryGetValue(type, out array) && array[(int)direction] > 0;
    }

    public bool HasPushableParts(BasePart.PartType type, BasePart.Direction direction)
    {
        int[] array;
        return this.m_pushablePartAmount.TryGetValue(type, out array) && array[(int)direction] > 0;
    }

    public List<PartPlacementInfo> PartPlacements
    {
        get
        {
            return this.m_partPlacements;
        }
    }

    public bool IsMovementStopped()
    {
        return this.m_stopTimer > 0.5f;
    }

    public float PowerConsumption
    {
        get
        {
            return this.m_powerConsumption;
        }
    }

    public bool HasPart(BasePart.PartType type)
    {
        for (int i = 0; i < this.m_parts.Count; i++)
        {
            if (this.m_parts[i].m_partType == type)
            {
                return true;
            }
        }
        return false;
    }

    public bool HasPart(BasePart.PartType type, BasePart.PartTier tier)
    {
        for (int i = 0; i < this.m_parts.Count; i++)
        {
            if (this.m_parts[i].m_partType == type && this.m_parts[i].m_partTier == tier)
            {
                return true;
            }
        }
        return false;
    }

    public int GetPartCount(BasePart.PartType type)
    {
        int num = 0;
        for (int i = 0; i < this.m_parts.Count; i++)
        {
            if (this.m_parts[i].m_partType == type)
            {
                num++;
            }
        }
        return num;
    }

    public bool IsBroken()
    {
        return this.m_broken;
    }

    public void SetGroundTouchTime(BasePart part)
    {
        int connectedComponent = part.ConnectedComponent;
        if (connectedComponent >= 0 && connectedComponent < this.m_connectedComponents.Count)
        {
            ConnectedComponent value = this.m_connectedComponents[connectedComponent];
            value.groundTouchTime = Time.time;
            this.m_connectedComponents[connectedComponent] = value;
        }
    }

    public float GetGroundTouchTime(int componentIndex)
    {
        if (componentIndex >= 0 && componentIndex < this.m_connectedComponents.Count)
        {
            return this.m_connectedComponents[componentIndex].groundTouchTime;
        }
        return 0f;
    }

    public float GetEnginePowerFactor(BasePart part)
    {
        int connectedComponent = part.ConnectedComponent;
        if (connectedComponent >= 0 && connectedComponent < this.m_connectedComponents.Count)
        {
            ConnectedComponent connectedComponent2 = this.m_connectedComponents[connectedComponent];
            float num = 0f;
            float num2 = connectedComponent2.powerConsumption;
            for (int i = 0; i < connectedComponent2.motorWheels.Count; i++)
            {
                MotorWheel motorWheel = connectedComponent2.motorWheels[i];
                if (!motorWheel.HasContact)
                {
                    num2 -= 0.9f * motorWheel.m_powerConsumption;
                }
            }
            if (num2 > 1f)
            {
                num = Mathf.Min(connectedComponent2.enginePower / num2, 10f);
            }
            else if (connectedComponent2.enginePower > 0f)
            {
                num = 1f;
            }
            if (num > 1f)
            {
                return Mathf.Pow(num, 0.585f);
            }
            else
            {
                return Mathf.Pow(num, 0.75f);
            }
        }
        return 0f;
    }

    public void AddRuntimePart(BasePart part)
    {
        this.m_parts.Add(part);
    }

    private void Awake()
    {
        this.m_contraptionDataSet = new ContraptionDataset();
        this.m_gameCamera = Camera.main;
        this.m_droppedSandbagLayer = LayerMask.NameToLayer("DroppedSandbag");
        this.nightVisionGogglesPrefab = Resources.Load<GameObject>("Prefabs/NightVisionGoggles");
    }

    public int NumOfIntegralParts()
    {
        return this.m_integralParts.Count;
    }

    public int DynamicPartCount()
    {
        return this.m_parts.Count - this.m_staticPartCount;
    }

    public void IncreaseStaticPartCount()
    {
        this.m_staticPartCount++;
    }

    public BasePart FindPig()
    {
        return this.FindPart(BasePart.PartType.Pig);
    }

    public BasePart FindPart(BasePart.PartType type)
    {
        foreach (BasePart basePart in this.m_parts)
        {
            if (basePart != null && basePart.m_partType == type)
            {
                return basePart;
            }
        }
        return null;
    }

    public static void AddToBoundingBox(ref Rect box, Vector2 min, Vector2 max)
    {
        if (min.x < box.xMin)
        {
            box.xMin = min.x;
        }
        if (min.y < box.yMin)
        {
            box.yMin = min.y;
        }
        if (max.x > box.xMax)
        {
            box.xMax = max.x;
        }
        if (max.y > box.yMax)
        {
            box.yMax = max.y;
        }
    }

    public Rect BoundingBox()
    {
        if (this.m_pig && this.m_cameraTarget == this.m_pig)
        {
            Vector3 position = this.m_pig.transform.position;
            Rect result = new Rect(position.x, position.y, 0f, 0f);
            for (int i = 0; i < this.m_parts.Count; i++)
            {
                BasePart basePart = this.m_parts[i];
                if (basePart && basePart.m_partType != BasePart.PartType.Rope && this.m_componentsConnectedByRope.Contains(basePart.ConnectedComponent) && basePart.m_partType != BasePart.PartType.Spring)
                {
                    Vector3 position2 = basePart.transform.position;
                    Vector2 min = new Vector2(position2.x - 0.5f, position2.y - 0.5f);
                    Vector2 max = new Vector2(position2.x + 0.5f, position2.y + 0.5f);
                    Contraption.AddToBoundingBox(ref result, min, max);
                }
            }
            return result;
        }
        if (this.m_cameraTarget)
        {
            Rect result2 = new Rect(this.m_cameraTarget.transform.position.x - 0.5f, this.m_cameraTarget.transform.position.y - 0.5f, 1f, 1f);
            return result2;
        }
        return default(Rect);
    }

    public bool CanConnectTo(BasePart part1, BasePart part2, BasePart.Direction direction)
    {
        if (part1 != null && part2 != null)
        {
            if (!part1.CanConnectTo(direction))
            {
                return false;
            }
            if (!part2.CanConnectTo(BasePart.InverseDirection(direction)))
            {
                return false;
            }
            if (part2.m_jointConnectionType != BasePart.JointConnectionType.None && (part2.m_jointConnectionType == BasePart.JointConnectionType.Source || part1.m_jointConnectionType == BasePart.JointConnectionType.Source))
            {
                return true;
            }
            if ((direction == BasePart.Direction.Down || direction == BasePart.Direction.Up) && (part1.m_partType == BasePart.PartType.Wings || part1.m_partType == BasePart.PartType.MetalWing) && (part2.m_partType == BasePart.PartType.Wings || part2.m_partType == BasePart.PartType.MetalWing))
            {
                return true;
            }
        }
        return false;
    }

    public bool CanConnectTo(BasePart part, BasePart.JointConnectionDirection direction)
    {
        if (direction == BasePart.JointConnectionDirection.Any)
        {
            return true;
        }
        if (direction == BasePart.JointConnectionDirection.LeftAndRight)
        {
            return this.CanConnectTo(part, BasePart.Direction.Left) || this.CanConnectTo(part, BasePart.Direction.Right);
        }
        if (direction == BasePart.JointConnectionDirection.UpAndDown)
        {
            return this.CanConnectTo(part, BasePart.Direction.Up) || this.CanConnectTo(part, BasePart.Direction.Down);
        }
        return this.CanConnectTo(part, BasePart.ConvertDirection(direction));
    }

    public bool CanConnectTo(BasePart part, BasePart.Direction direction)
    {
        int coordX = part.m_coordX;
        int coordY = part.m_coordY;
        switch (direction)
        {
            case BasePart.Direction.Right:
                {
                    BasePart part2 = this.FindPartAt(coordX + 1, coordY);
                    return this.CanConnectTo(part, part2, direction);
                }
            case BasePart.Direction.Up:
                {
                    BasePart part2 = this.FindPartAt(coordX, coordY + 1);
                    return this.CanConnectTo(part, part2, direction);
                }
            case BasePart.Direction.Left:
                {
                    BasePart part2 = this.FindPartAt(coordX - 1, coordY);
                    return this.CanConnectTo(part, part2, direction);
                }
            case BasePart.Direction.Down:
                {
                    BasePart part2 = this.FindPartAt(coordX, coordY - 1);
                    return this.CanConnectTo(part, part2, direction);
                }
            default:
                return false;
        }
    }

    public BasePart GetPartAt(BasePart part, BasePart.Direction direction)
    {
        int coordX = part.m_coordX;
        int coordY = part.m_coordY;
        switch (direction)
        {
            case BasePart.Direction.Right:
                return this.FindPartAt(coordX + 1, coordY);
            case BasePart.Direction.Up:
                return this.FindPartAt(coordX, coordY + 1);
            case BasePart.Direction.Left:
                return this.FindPartAt(coordX - 1, coordY);
            case BasePart.Direction.Down:
                return this.FindPartAt(coordX, coordY - 1);
            default:
                return null;
        }
    }

    public void StartContraption()
    {
        this.m_broken = false;
        this.m_stopTimer = 0f;
        this.m_parts = new List<BasePart>(base.GetComponentsInChildren<BasePart>());
        this.m_ropes.Clear();
        this.m_powerConsumption = 0f;
        this.m_enginesAmount = 0;
        if (this.m_hasTurboCharge)
        {
            this.m_enginePowerFactor = WPFMonoBehaviour.gameData.m_turboChargePowerFactor;
        }
        foreach (BasePart basePart in this.m_parts)
        {
            Vector3 localPosition = basePart.transform.localPosition;
            int x = Mathf.RoundToInt(localPosition.x);
            int y = Mathf.RoundToInt(localPosition.y);
            this.SetPartPos(x, y, basePart);
            if (basePart.enclosedInto)
            {
                this.SetPartPos(x, y, basePart.enclosedInto);
            }
            if (basePart.IsIntegralPart())
            {
                this.m_integralParts.Add(basePart);
            }
            basePart.gameObject.tag = "Contraption";
            for (int i = 0; i < basePart.transform.childCount; i++)
            {
                basePart.transform.GetChild(i).gameObject.tag = "Contraption";
            }
            if (basePart.m_partType == BasePart.PartType.Pig)
            {
                this.m_cameraTarget = basePart;
                this.m_pig = basePart;
            }
            this.m_powerConsumption += basePart.m_powerConsumption;
        }
        foreach (BasePart basePart2 in this.m_parts)
        {
            int coordX = basePart2.m_coordX;
            int coordY = basePart2.m_coordY;
            this.m_contraptionDataSet.AddPart(coordX, coordY, (int)basePart2.m_partType, basePart2.customPartIndex, basePart2.m_gridRotation, basePart2.m_flipped);
            basePart2.contraption = this;
            basePart2.EnsureRigidbody();
            if (basePart2.m_jointConnectionType != BasePart.JointConnectionType.None)
            {
                BasePart basePart3 = this.FindPartAt(coordX + 1, coordY);
                BasePart basePart4 = this.FindPartAt(coordX, coordY - 1);
                if (basePart3 != null)
                {
                    basePart3.contraption = this;
                }
                if (basePart4 != null)
                {
                    basePart4.contraption = this;
                }
                if (this.CanConnectTo(basePart2, basePart3, BasePart.Direction.Right))
                {
                    if (basePart2.GetCustomJointConnectionDirection() == BasePart.JointConnectionDirection.Right || basePart2.GetCustomJointConnectionDirection() == BasePart.JointConnectionDirection.LeftAndRight)
                    {
                        this.AddCustomConnectionBetweenParts(basePart2, basePart3);
                    }
                    else if (basePart3.GetCustomJointConnectionDirection() == BasePart.JointConnectionDirection.Left || basePart3.GetCustomJointConnectionDirection() == BasePart.JointConnectionDirection.LeftAndRight)
                    {
                        this.AddCustomConnectionBetweenParts(basePart3, basePart2);
                    }
                    else
                    {
                        this.AddFixedJoint(basePart2, basePart3);
                    }
                }
                if (this.CanConnectTo(basePart2, basePart4, BasePart.Direction.Down))
                {
                    if (basePart2.GetCustomJointConnectionDirection() == BasePart.JointConnectionDirection.Down || basePart2.GetCustomJointConnectionDirection() == BasePart.JointConnectionDirection.UpAndDown)
                    {
                        this.AddCustomConnectionBetweenParts(basePart2, basePart4);
                    }
                    else if (basePart4.GetCustomJointConnectionDirection() == BasePart.JointConnectionDirection.Up || basePart4.GetCustomJointConnectionDirection() == BasePart.JointConnectionDirection.UpAndDown)
                    {
                        this.AddCustomConnectionBetweenParts(basePart4, basePart2);
                    }
                    else
                    {
                        this.AddFixedJoint(basePart2, basePart4);
                    }
                }
                if (basePart2.m_partType == BasePart.PartType.Rope)
                {
                    BasePart.JointConnectionDirection customJointConnectionDirection = basePart2.GetCustomJointConnectionDirection();
                    BasePart basePart5;
                    BasePart basePart6;
                    if (customJointConnectionDirection == BasePart.JointConnectionDirection.LeftAndRight)
                    {
                        basePart5 = this.FindPartAt(coordX - 1, coordY);
                        basePart6 = this.FindPartAt(coordX + 1, coordY);
                    }
                    else
                    {
                        basePart5 = this.FindPartAt(coordX, coordY + 1);
                        basePart6 = this.FindPartAt(coordX, coordY - 1);
                    }
                    if (basePart5 && basePart5.GetComponent<Rope>() && basePart5.GetComponent<Rope>().m_gridRotation != basePart2.m_gridRotation)
                    {
                        basePart5 = null;
                    }
                    if (basePart6 && basePart6.GetComponent<Rope>() && basePart6.GetComponent<Rope>().m_gridRotation != basePart2.m_gridRotation)
                    {
                        basePart6 = null;
                    }
                    if (basePart5 && !basePart5.GetComponent<Rope>() && !basePart5.GetComponent<Frame>() && !basePart5.GetComponent<Kicker>())
                    {
                        basePart5 = null;
                    }
                    if (basePart6 && !basePart6.GetComponent<Rope>() && !basePart6.GetComponent<Frame>() && !basePart6.GetComponent<Kicker>())
                    {
                        basePart6 = null;
                    }
                    if (basePart5)
                    {
                        basePart5.EnsureRigidbody();
                    }
                    if (basePart6)
                    {
                        basePart6.EnsureRigidbody();
                    }
                    basePart2.GetComponent<Rope>().Create(basePart5, basePart6);
                    this.m_ropes.Add(basePart2.GetComponent<Rope>());
                }
            }
            if (basePart2.m_partType == BasePart.PartType.Spring)
            {
                BasePart.Direction direction = BasePart.ConvertDirection(basePart2.GetCustomJointConnectionDirection());
                BasePart partAt = this.GetPartAt(basePart2, direction);
                if (!partAt || !this.CanConnectTo(basePart2, partAt, direction))
                {
                    basePart2.GetComponent<Spring>().CreateSpringBody(direction);
                }
            }
            if (basePart2.m_partType == BasePart.PartType.Pig && WPFMonoBehaviour.levelManager && WPFMonoBehaviour.levelManager.m_disablePigCollisions && basePart2.m_enclosedInto != null)
            {
                basePart2.gameObject.layer = LayerMask.NameToLayer("NonCollidingPart");
            }
            if (basePart2.m_partType == BasePart.PartType.KingPig || basePart2.m_partType == BasePart.PartType.GoldenPig)
            {
                for (int i = 0; i <= 1; i++)
                {
                    for (int j = -2; j <= 2; j += 4)
                    {
                        BasePart basePart7 = this.FindPartAt(coordX + j, coordY + i);
                        if (basePart7 && (basePart7.m_partType == BasePart.PartType.Wings || basePart7.m_partType == BasePart.PartType.MetalWing))
                        {
                            basePart7.EnsureRigidbody();
                            if (basePart7.collider)
                            {
                                Physics.IgnoreCollision(basePart2.collider, basePart7.collider);
                            }
                        }
                    }
                    for (int k = -1; k <= 1; k++)
                    {
                        if (k != 0 || i != 0)
                        {
                            BasePart basePart8 = this.FindPartAt(coordX + k, coordY + i);
                            if (basePart8)
                            {
                                if (basePart8.m_partType == BasePart.PartType.WoodenFrame || basePart8.m_partType == BasePart.PartType.MetalFrame)
                                {
                                    basePart8.EnsureRigidbody();
                                    if (i == 0)
                                    {
                                        this.AddFixedJoint(basePart2, basePart8);
                                    }
                                    else
                                    {
                                        Physics.IgnoreCollision(basePart2.collider, basePart8.collider);
                                    }
                                }
                                else if (basePart8.m_partType == BasePart.PartType.Spring)
                                {
                                    basePart8.EnsureRigidbody();
                                    if (basePart8.collider)
                                    {
                                        Physics.IgnoreCollision(basePart2.collider, basePart8.collider);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        for (int l = 0; l < this.m_parts.Count; l++)
        {
            BasePart basePart9 = this.m_parts[l];
            basePart9.contraption = this;
            basePart9.enabled = true;
            basePart9.Initialize();
        }
        this.FindConnectedComponents();
        this.FindComponentsConnectedByRope();
        this.CalculatePartPlacement();
        this.InitializeEngines();
        this.CountActiveParts();
        if (this.m_currentGlue != Glue.Type.None)
        {
            this.MakeUnbreakable();
        }
        for (int m = 0; m < this.m_parts.Count; m++)
        {
            BasePart basePart10 = this.m_parts[m];
            basePart10.PostInitialize();
        }
        int[] array;
        if (this.m_oneShotPartAmount.TryGetValue(BasePart.PartType.Balloon, out array))
        {
            int num = array[0];
            if (num > 0)
            {
                for (int n = 0; n < this.m_parts.Count; n++)
                {
                    BasePart basePart11 = this.m_parts[n];
                    if (basePart11.m_partType == BasePart.PartType.Balloon)
                    {
                        basePart11.GetComponent<Balloon>().ConfigureExtraBalanceJoint(1f / (float)num);
                    }
                }
            }
        }
        this.m_running = true;
    }

    public void SaveContraption(string currentContraptionName)
    {
        WPFPrefs.SaveContraptionDataset(currentContraptionName, this.m_contraptionDataSet);
        GameProgress.Save();
    }

    private void AddCustomConnectionBetweenParts(BasePart part1, BasePart part2)
    {
        part2.EnsureRigidbody();
        Joint joint = part1.CustomConnectToPart(part2);
        this.AddJointToMap(part1, part2, joint);
    }

    public void CalculatePartPlacement()
    {
        this.m_partPlacements.Clear();
        for (int i = 0; i < this.m_parts.Count; i++)
        {
            this.AddPartPlacement(this.m_parts[i]);
        }
        foreach (PartPlacementInfo partPlacementInfo in this.m_partPlacements)
        {
            partPlacementInfo.averagePosition /= (float)partPlacementInfo.count;
        }
        this.m_partPlacements.Sort(new PartOrder());
    }

    private void AddPartPlacement(BasePart part)
    {
        BasePart.PartType partType = InGameFlightMenu.CombinedTypeForGadgetButtonOrdering(part.m_partType);
        foreach (PartPlacementInfo partPlacementInfo in this.m_partPlacements)
        {
            if (partPlacementInfo.partType == partType && partPlacementInfo.direction == part.EffectDirection())
            {
                partPlacementInfo.averagePosition += part.transform.position;
                partPlacementInfo.count++;
                return;
            }
        }
        this.m_partPlacements.Add(new PartPlacementInfo(partType, part.EffectDirection(), part.transform.position, 1));
    }

    public int EnginePoweredPartTypeCount()
    {
        int num = 0;
        foreach (KeyValuePair<BasePart.PartType, int[]> keyValuePair in this.m_poweredPartAmount)
        {
            if (keyValuePair.Key != BasePart.PartType.Bellows)
            {
                if (keyValuePair.Value[0] > 0)
                {
                    num++;
                }
                if (keyValuePair.Value[1] > 0)
                {
                    num++;
                }
                if (keyValuePair.Value[2] > 0)
                {
                    num++;
                }
                if (keyValuePair.Value[3] > 0)
                {
                    num++;
                }
            }
        }
        return num;
    }

    public void CountActiveParts()
    {
        foreach (KeyValuePair<BasePart.PartType, int[]> keyValuePair in this.m_poweredPartAmount)
        {
            Array.Clear(keyValuePair.Value, 0, keyValuePair.Value.Length);
        }
        foreach (KeyValuePair<BasePart.PartType, int[]> keyValuePair2 in this.m_pushablePartAmount)
        {
            Array.Clear(keyValuePair2.Value, 0, keyValuePair2.Value.Length);
        }
        foreach (BasePart basePart in this.m_parts)
        {
            if (basePart.CanBeEnabled() && !basePart.IsEngine())
            {
                if (basePart.IsPowered())
                {
                    this.ChangePoweredPartAmount(basePart.m_partType, basePart.EffectDirection(), 1);
                }
                else
                {
                    this.ChangePushablePartAmount(basePart.m_partType, basePart.EffectDirection(), 1);
                }
            }
        }
    }

    public bool SomePoweredPartsEnabled()
    {
        for (int i = 0; i < this.m_parts.Count; i++)
        {
            if (this.m_parts[i].m_powerConsumption > 0f && this.m_parts[i].IsEnabled())
            {
                return true;
            }
        }
        return false;
    }

    public bool AllPoweredPartsEnabled()
    {
        bool result = false;
        for (int i = 0; i < this.m_parts.Count; i++)
        {
            if (this.m_parts[i].m_powerConsumption > 0f)
            {
                if (!this.m_parts[i].IsEnabled() && this.m_parts[i].CanBeEnabled())
                {
                    return false;
                }
                result = true;
            }
        }
        return result;
    }

    public bool AnyPartsEnabled(BasePart.PartType type, BasePart.Direction direction)
    {
        for (int i = 0; i < this.m_parts.Count; i++)
        {
            if (this.m_parts[i].m_partType == type && this.m_parts[i].EffectDirection() == direction && this.m_parts[i].IsEnabled())
            {
                return true;
            }
        }
        return false;
    }

    public bool AnyPartsEnabled(BasePart.PartType type, BasePart.PartTier tier, BasePart.Direction direction)
    {
        for (int i = 0; i < this.m_parts.Count; i++)
        {
            if (this.m_parts[i].m_partType == type && this.m_parts[i].m_partTier == tier && this.m_parts[i].EffectDirection() == direction && this.m_parts[i].IsEnabled())
            {
                return true;
            }
        }
        return false;
    }

    public void ActivatePartType(BasePart.PartType type, BasePart.Direction direction)
    {
        if (type == BasePart.PartType.Engine)
        {
            this.ActivateAllPoweredParts();
        }
        else if (type == BasePart.PartType.Balloon || type == BasePart.PartType.Sandbag)
        {
            this.ActivateOnePartOfType(type);
        }
        else
        {
            int num = 0;
            foreach (BasePart basePart in this.m_parts)
            {
                if (basePart.m_partType == type && basePart.EffectDirection() == direction && !basePart.IsEnabled() && basePart.CanBeEnabled() && basePart.HasOnOffToggle())
                {
                    num++;
                }
            }
            bool startAll = num > 0;
            this.ActivateParts((BasePart part) => part.m_partType == type && part.EffectDirection() == direction && (startAll != part.IsEnabled() || !part.HasOnOffToggle()));
        }
    }

    public void ActivateParts(Func<BasePart, bool> predicate)
    {
        foreach (BasePart basePart in new List<BasePart>(this.m_parts))
        {
            if (basePart && predicate(basePart))
            {
                basePart.ProcessTouch();
            }
        }
    }

    private void ActivateOnePartOfType(BasePart.PartType type)
    {
        Vector3 vector = Vector3.zero;
        float num = 0f;
        foreach (BasePart basePart in this.m_parts)
        {
            if (basePart != null && basePart.ConnectedComponent == this.m_pig.ConnectedComponent)
            {
                vector += basePart.transform.position;
                num += 1f;
            }
        }
        if (num > 0f)
        {
            vector /= num;
        }
        float num2 = 0f;
        BasePart basePart2 = null;
        foreach (BasePart basePart3 in this.m_parts)
        {
            if (basePart3 && basePart3.m_partType == type)
            {
                if (basePart3.m_partType != BasePart.PartType.Sandbag || basePart3.GetComponent<Sandbag>().IsAttached())
                {
                    float num3 = Vector3.Distance(basePart3.transform.position, vector);
                    if (num3 > num2)
                    {
                        num2 = num3;
                        basePart2 = basePart3;
                    }
                }
            }
        }
        if (basePart2)
        {
            basePart2.ProcessTouch();
        }
    }

    public void ActivateAllPoweredParts()
    {
        int num = 0;
        foreach (BasePart basePart in this.m_parts)
        {
            if (basePart.CanBeEnabled() && !basePart.IsEnabled() && basePart.IsPowered())
            {
                num++;
            }
        }
        bool flag = num > 0;
        foreach (BasePart basePart2 in this.m_parts)
        {
            if (basePart2.CanBeEnabled() && basePart2.IsPowered())
            {
                if (flag)
                {
                    if (!basePart2.IsEnabled())
                    {
                        basePart2.SetEnabled(true);
                    }
                }
                else if (basePart2.IsEnabled())
                {
                    basePart2.SetEnabled(false);
                }
            }
        }
    }

    public void TurnOffAllPoweredParts()
    {
        for (int i = 0; i < this.m_parts.Count; i++)
        {
            if (!(this.m_parts[i] == null))
            {
                if ((this.m_parts[i].IsPowered() || this.m_parts[i].IsEngine()) && this.m_parts[i].IsEnabled())
                {
                    this.m_parts[i].SetEnabled(false);
                }
            }
        }
    }

    public int ActivateAllPoweredParts(int connectedComponent)
    {
        int num = 0;
        int num2 = 0;
        for (int i = 0; i < this.m_parts.Count; i++)
        {
            if (this.m_parts[i].ConnectedComponent == connectedComponent && this.m_parts[i].CanBeEnabled() && !this.m_parts[i].IsEnabled() && this.m_parts[i].IsPowered())
            {
                num2++;
            }
        }
        bool flag = num2 > 0;
        for (int j = 0; j < this.m_parts.Count; j++)
        {
            if (this.m_parts[j].ConnectedComponent == connectedComponent && this.m_parts[j].CanBeEnabled() && this.m_parts[j].IsPowered())
            {
                num++;
                if (flag)
                {
                    if (!this.m_parts[j].IsEnabled())
                    {
                        this.m_parts[j].SetEnabled(true);
                    }
                }
                else if (this.m_parts[j].IsEnabled())
                {
                    this.m_parts[j].SetEnabled(false);
                }
            }
        }
        return num;
    }

    public void UpdateEngineStates(int connectedComponent)
    {
        int num = 0;
        for (int i = 0; i < this.m_parts.Count; i++)
        {
            BasePart basePart = this.m_parts[i];
            if (basePart.ConnectedComponent == connectedComponent && basePart.CanBeEnabled() && basePart.IsEnabled() && basePart.IsPowered())
            {
                num++;
            }
        }
        this.EnableComponentEngines(connectedComponent, num > 0);
    }

    private void EnableComponentEngines(int connectedComponent, bool enable)
    {
        for (int i = 0; i < this.m_parts.Count; i++)
        {
            BasePart basePart = this.m_parts[i];
            if (basePart.IsEngine() && basePart.ConnectedComponent == connectedComponent)
            {
                basePart.SetEnabled(enable);
            }
        }
    }

    public void FindComponentsConnectedByRope()
    {
        this.m_componentsConnectedByRope.Clear();
        if (this.m_ropes.Count == 0 && !this.m_pig)
        {
            return;
        }
        Queue<int> components = this.m_connectionSearchState.components;
        HashSet<int> visited = this.m_connectionSearchState.visited;
        components.Clear();
        visited.Clear();
        components.Enqueue(this.m_pig.ConnectedComponent);
        while (components.Count > 0)
        {
            int num = components.Dequeue();
            this.m_componentsConnectedByRope.Add(num);
            visited.Add(num);
            this.FindRopeConnections(num, ref components, visited);
        }
    }

    public bool IsConnectedTo(BasePart part1, Collider collider1, BasePart part2)
    {
        if (!part1 || !part2)
        {
            return false;
        }
        if (part1.m_partType != BasePart.PartType.Rope)
        {
            return this.IsConnectedTo(part1, part2);
        }
        Rope component = part1.GetComponent<Rope>();
        if (component.IsCut())
        {
            if (component.IsLeftPart(base.collider))
            {
                if (component.LeftPart)
                {
                    return this.IsConnectedTo(component.LeftPart, part2);
                }
            }
            else if (component.RightPart)
            {
                return this.IsConnectedTo(component.RightPart, part2);
            }
            return false;
        }
        if (component.LeftPart)
        {
            return this.IsConnectedTo(component.LeftPart, part2);
        }
        return component.RightPart && this.IsConnectedTo(component.RightPart, part2);
    }

    public bool IsConnectedTo(BasePart part1, BasePart part2)
    {
        Queue<int> components = this.m_connectionSearchState.components;
        HashSet<int> visited = this.m_connectionSearchState.visited;
        components.Clear();
        visited.Clear();
        components.Enqueue(part1.ConnectedComponent);
        while (components.Count > 0)
        {
            int num = components.Dequeue();
            if (num == part2.ConnectedComponent)
            {
                return true;
            }
            visited.Add(num);
            this.FindRopeConnections(num, ref components, visited);
        }
        return false;
    }

    public bool IsConnectedToPig(BasePart part, Collider collider = null)
    {
        if (!part)
        {
            return false;
        }
        if (part.m_partType != BasePart.PartType.Rope)
        {
            return this.m_componentsConnectedByRope.Contains(part.ConnectedComponent);
        }
        Rope component = part.GetComponent<Rope>();
        if (component.IsCut())
        {
            if (component.IsLeftPart(collider))
            {
                if (component.LeftPart)
                {
                    return this.m_componentsConnectedByRope.Contains(component.LeftPart.ConnectedComponent);
                }
            }
            else if (component.RightPart)
            {
                return this.m_componentsConnectedByRope.Contains(component.RightPart.ConnectedComponent);
            }
            return false;
        }
        if (component.LeftPart)
        {
            return this.m_componentsConnectedByRope.Contains(component.LeftPart.ConnectedComponent);
        }
        return component.RightPart && this.m_componentsConnectedByRope.Contains(component.RightPart.ConnectedComponent);
    }

    private void FindRopeConnections(int component, ref Queue<int> components, HashSet<int> ignoreList)
    {
        for (int i = 0; i < this.m_ropes.Count; i++)
        {
            Rope rope = this.m_ropes[i];
            if (rope != null && !rope.IsCut())
            {
                if (rope.LeftPart != null && rope.RightPart != null)
                {
                    int num = rope.LeftPart.ConnectedComponent;
                    int num2 = rope.RightPart.ConnectedComponent;
                    int num3 = rope.ConnectedComponent;
                    if (num == component)
                    {
                        if (!ignoreList.Contains(num2))
                        {
                            components.Enqueue(num2);
                        }
                    }
                    else if (num2 == component)
                    {
                        if (!ignoreList.Contains(num))
                        {
                            components.Enqueue(num);
                        }
                    }
                    else if (num3 == component)
                    {
                        if (!ignoreList.Contains(num))
                        {
                            components.Enqueue(num);
                        }
                        if (!ignoreList.Contains(num2))
                        {
                            components.Enqueue(num2);
                        }
                    }
                }
                else if ((rope.LeftPart || rope.RightPart) && rope.ConnectedComponent == component)
                {
                    if (rope.RightPart && !ignoreList.Contains(rope.RightPart.ConnectedComponent))
                    {
                        components.Enqueue(rope.RightPart.ConnectedComponent);
                    }
                    if (rope.LeftPart && !ignoreList.Contains(rope.LeftPart.ConnectedComponent))
                    {
                        components.Enqueue(rope.LeftPart.ConnectedComponent);
                    }
                }
            }
        }
    }

    public void FinishConnectedComponentSearch()
    {
        if ((this.m_jointDetached & 1) != 0)
        {
            this.FindConnectedComponents();
            this.InitializeEngines();
            this.CountActiveParts();
            this.FindComponentsConnectedByRope();
        }
        this.m_jointDetached >>= 1;
    }

    private void FindConnectedComponents()
    {
        int count = this.m_parts.Count;
        DisjointSet disjointSet = new DisjointSet(count);
        Dictionary<BasePart, int> dictionary = new Dictionary<BasePart, int>(count);
        for (int i = 0; i < count; i++)
        {
            dictionary[this.m_parts[i]] = i;
        }
        foreach (Contraption.JointConnection jointConnection in this.m_jointMap)
        {
            int x;
            int y;
            if (jointConnection.partA != null && jointConnection.partB != null && dictionary.TryGetValue(jointConnection.partA, out x) && dictionary.TryGetValue(jointConnection.partB, out y))
            {
                disjointSet.Union(x, y);
            }
        }
        int[] array = new int[count];
        for (int j = 0; j < count; j++)
        {
            array[j] = -1;
        }
        this.m_connectedComponents = new List<Contraption.ConnectedComponent>();
        for (int k = 0; k < count; k++)
        {
            int num = disjointSet.FindSet(k);
            int num2 = array[num];
            BasePart basePart = this.m_parts[k];
            Contraption.ConnectedComponent connectedComponent = (num2 == -1) ? new Contraption.ConnectedComponent
            {
                motorWheels = new List<MotorWheel>()
            } : this.m_connectedComponents[num2];
            connectedComponent.partCount++;
            connectedComponent.powerConsumption += basePart.m_powerConsumption;
            connectedComponent.enginePower += basePart.m_enginePower * this.m_enginePowerFactor;
            if (basePart.m_enginePower > 0f && basePart.m_partType != BasePart.PartType.Pig)
            {
                connectedComponent.hasEngine = true;
            }
            if (basePart.m_partType == BasePart.PartType.Gearbox)
            {
                connectedComponent.hasGearbox = true;
                connectedComponent.gearbox = (basePart as Gearbox);
            }
            if (basePart.m_partType == BasePart.PartType.MotorWheel)
            {
                connectedComponent.motorWheels.Add(basePart as MotorWheel);
            }
            if (num2 == -1)
            {
                num2 = this.m_connectedComponents.Count;
                this.m_connectedComponents.Add(connectedComponent);
            }
            else
            {
                this.m_connectedComponents[num2] = connectedComponent;
            }
            basePart.ConnectedComponent = num2;
            array[num] = num2;
        }
    }

    public bool PartIsConnected(BasePart part)
    {
        for (int i = 0; i < this.m_jointMap.Count; i++)
        {
            if (this.m_jointMap[i].partA == part)
            {
                return true;
            }
            if (this.m_jointMap[i].partB == part)
            {
                return true;
            }
        }
        return false;
    }

    private void InitializeEngines()
    {
        foreach (BasePart basePart in this.m_parts)
        {
            basePart.InitializeEngine();
        }
    }

    public void StopContraption()
    {
        for (int i = 0; i < this.m_parts.Count; i++)
        {
            BasePart basePart = this.m_parts[i];
            if (basePart != null)
            {
                UnityEngine.Object.Destroy(basePart.gameObject);
            }
        }
        this.m_running = false;
    }

    public float GetJointConnectionStrength(BasePart.JointConnectionStrength strength)
    {
        switch (strength)
        {
            case BasePart.JointConnectionStrength.Weak:
                return WPFMonoBehaviour.gameData.m_jointConnectionStrengthWeak;
            case BasePart.JointConnectionStrength.Normal:
                return WPFMonoBehaviour.gameData.m_jointConnectionStrengthNormal;
            case BasePart.JointConnectionStrength.High:
                return WPFMonoBehaviour.gameData.m_jointConnectionStrengthHigh;
            case BasePart.JointConnectionStrength.Extreme:
                return WPFMonoBehaviour.gameData.m_jointConnectionStrengthExtreme;
            case BasePart.JointConnectionStrength.HighlyExtreme:
                return WPFMonoBehaviour.gameData.m_jointConnectionStrengthHighlyExtreme;
            default:
                return 0f;
        }
    }

    private void AddFixedJoint(BasePart part, BasePart other)
    {
        other.EnsureRigidbody();
        Joint joint;
        if (part.m_jointType == BasePart.JointType.HingeJoint || other.m_jointType == BasePart.JointType.HingeJoint)
        {
            HingeJoint hingeJoint = part.gameObject.AddComponent<HingeJoint>();
            hingeJoint.autoConfigureConnectedAnchor = false;
            hingeJoint.anchor = part.transform.InverseTransformPoint(other.transform.position) * 0.5f;
            hingeJoint.connectedAnchor = other.transform.InverseTransformPoint(part.transform.position) * 0.5f;
            JointLimits limits = hingeJoint.limits;
            limits.min = -0.1f;
            limits.max = 0.1f;
            hingeJoint.limits = limits;
            hingeJoint.axis = Vector3.forward;
            hingeJoint.useLimits = true;
            joint = hingeJoint;
        }
        else
        {
            joint = part.gameObject.AddComponent<FixedJoint>();
        }
        joint.connectedBody = other.rigidbody;
        joint.enablePreprocessing = (part.JointPreprocessing && other.JointPreprocessing);
        float jointConnectionStrength = this.GetJointConnectionStrength(part.GetJointConnectionStrength());
        float jointConnectionStrength2 = this.GetJointConnectionStrength(other.GetJointConnectionStrength());
        float breakForce = jointConnectionStrength + jointConnectionStrength2;
        joint.breakForce = breakForce;
        this.AddJointToMap(part, other, joint);
    }

    public void MoveOnGrid(int dx, int dy)
    {
        this.m_partMap.Clear();
        foreach (BasePart basePart in this.m_parts)
        {
            int num = basePart.m_coordX + dx;
            int num2 = basePart.m_coordY + dy;
            if (num >= WPFMonoBehaviour.levelManager.GridXMin && num <= WPFMonoBehaviour.levelManager.GridXMax && num2 >= 0 && num2 < WPFMonoBehaviour.levelManager.GridHeight)
            {
                this.SetPartPos(num, num2, basePart);
            }
        }
    }

    public bool CanMoveOnGrid(int dx, int dy)
    {
        if (this.m_parts.Count == 0)
        {
            return false;
        }
        foreach (BasePart basePart in this.m_parts)
        {
            int num = basePart.m_coordX + dx;
            int num2 = basePart.m_coordY + dy;
            if (num < WPFMonoBehaviour.levelManager.GridXMin || num > WPFMonoBehaviour.levelManager.GridXMax || num2 < 0 || num2 >= WPFMonoBehaviour.levelManager.GridHeight)
            {
                return false;
            }
        }
        return true;
    }

    private void SetPartPos(int x, int y, BasePart part)
    {
        if (part != null)
        {
            part.m_coordX = x;
            part.m_coordY = y;
            float num = -(float)(x + 2 * y) / 100000f;
            part.transform.localPosition = new Vector3((float)x, (float)y, -0.1f + part.m_ZOffset + num);
        }
        if (part == null || part.m_enclosedInto == null)
        {
            int key = x + (y << 16);
            this.m_partMap[key] = part;
        }
    }

    public BasePart FindPartAt(int x, int y)
    {
        int key = x + (y << 16);
        BasePart result;
        this.m_partMap.TryGetValue(key, out result);
        return result;
    }

    public bool IsPartTypeAt(int x, int y, BasePart.PartType type, BasePart.GridRotation rotation)
    {
        int key = x + (y << 16);
        BasePart basePart;
        return this.m_partMap.TryGetValue(key, out basePart) && basePart && basePart.m_partType == type && basePart.m_gridRotation == rotation;
    }

    public BasePart FindPartOfType(BasePart.PartType type)
    {
        foreach (BasePart basePart in this.m_parts)
        {
            if (basePart.m_partType == type)
            {
                return basePart;
            }
        }
        return null;
    }

    public List<BasePart> FindNeighbours(int x, int y)
    {
        List<BasePart> list = new List<BasePart>();
        BasePart basePart = this.FindPartAt(x - 1, y);
        if (basePart != null)
        {
            list.Add(basePart);
        }
        basePart = this.FindPartAt(x + 1, y);
        if (basePart != null)
        {
            list.Add(basePart);
        }
        basePart = this.FindPartAt(x, y - 1);
        if (basePart != null)
        {
            list.Add(basePart);
        }
        basePart = this.FindPartAt(x, y + 1);
        if (basePart != null)
        {
            list.Add(basePart);
        }
        return list;
    }

    public void RefreshNeighbours(int x, int y)
    {
        this.m_isValidationRequired = true;
        BasePart basePart = this.FindPartAt(x - 1, y);
        if (basePart != null)
        {
            basePart.OnChangeConnections();
        }
        BasePart basePart2 = this.FindPartAt(x + 1, y);
        if (basePart2 != null)
        {
            basePart2.OnChangeConnections();
        }
        BasePart basePart3 = this.FindPartAt(x, y + 1);
        if (basePart3 != null)
        {
            basePart3.OnChangeConnections();
        }
        BasePart basePart4 = this.FindPartAt(x, y - 1);
        if (basePart4 != null)
        {
            basePart4.OnChangeConnections();
        }
        if (this.m_currentGlue != Glue.Type.None)
        {
            Glue.ShowSuperGlue(this, this.m_currentGlue);
        }
    }

    public void RefreshNeighboursVisual(int x, int y)
    {
        BasePart basePart = this.FindPartAt(x - 1, y);
        if (basePart != null)
        {
            basePart.ChangeVisualConnections();
        }
        BasePart basePart2 = this.FindPartAt(x + 1, y);
        if (basePart2 != null)
        {
            basePart2.ChangeVisualConnections();
        }
        BasePart basePart3 = this.FindPartAt(x, y + 1);
        if (basePart3 != null)
        {
            basePart3.ChangeVisualConnections();
        }
        BasePart basePart4 = this.FindPartAt(x, y - 1);
        if (basePart4 != null)
        {
            basePart4.ChangeVisualConnections();
        }
        if (this.m_currentGlue != Glue.Type.None)
        {
            Glue.ShowSuperGlue(this, this.m_currentGlue);
        }
    }

    public BasePart SetPartAt(int x, int y, BasePart newPart)
    {
        return this.SetPartAt(x, y, newPart, true);
    }

    public BasePart SetPartAt(int x, int y, BasePart newPart, bool refreshNeighbours)
    {
        BasePart basePart = this.RemovePartsAt(x, y);
        newPart.transform.parent = base.transform;
        newPart.contraption = this;
        this.SetPartPos(x, y, newPart);
        this.m_parts.Add(newPart);
        if (newPart.m_partType == BasePart.PartType.Pig && this.m_hasSuperMagnet)
        {
            SuperMagnet component = newPart.GetComponent<SuperMagnet>();
            if (component == null)
            {
                newPart.gameObject.AddComponent<SuperMagnet>();
            }
        }
        if (newPart.IsEngine() && this.m_enginePowerFactor > 1f)
        {
            this.AddTurboChargeEffect(newPart.gameObject);
        }
        if (newPart.m_partType == BasePart.PartType.Pig && this.m_hasNightVision)
        {
            this.ApplyNightVisionGoggles();
        }
        if (basePart && basePart.CanBeEnclosed() && newPart.CanEncloseParts())
        {
            newPart.enclosedPart = basePart;
            this.m_parts.Add(basePart);
        }
        else
        {
            if (newPart.CanBeEnclosed() && basePart && basePart.CanEncloseParts())
            {
                BasePart enclosedPart = basePart.enclosedPart;
                basePart.enclosedPart = newPart;
                this.m_parts.Add(basePart);
                this.SetPartPos(x, y, basePart);
                if (refreshNeighbours)
                {
                    basePart.OnChangeConnections();
                    this.RefreshNeighbours(x, y);
                }
                return enclosedPart;
            }
            if (basePart && basePart.enclosedPart && newPart.CanEncloseParts())
            {
                newPart.enclosedPart = basePart.enclosedPart;
                basePart.enclosedPart = null;
                this.m_parts.Add(newPart.enclosedPart);
                if (refreshNeighbours)
                {
                    newPart.OnChangeConnections();
                    this.RefreshNeighbours(x, y);
                }
                return basePart;
            }
            if (basePart)
            {
                if (refreshNeighbours)
                {
                    newPart.OnChangeConnections();
                    this.RefreshNeighbours(x, y);
                }
                return basePart;
            }
        }
        if (refreshNeighbours)
        {
            newPart.OnChangeConnections();
            this.RefreshNeighbours(x, y);
        }
        this.m_isValidationRequired = true;
        return null;
    }

    public BasePart RemovePartsAt(int x, int y)
    {
        BasePart basePart = this.FindPartAt(x, y);
        this.SetPartPos(x, y, null);
        if (basePart)
        {
            this.m_parts.Remove(basePart);
            if (basePart.enclosedPart)
            {
                this.m_parts.Remove(basePart.enclosedPart);
            }
        }
        return basePart;
    }

    public BasePart RemovePartAt(int x, int y)
    {
        BasePart basePart = this.FindPartAt(x, y);
        if (basePart)
        {
            BasePart enclosedPart = basePart.enclosedPart;
            if (enclosedPart)
            {
                basePart.enclosedPart = null;
                enclosedPart.enclosedInto = null;
                this.SetPartPos(x, y, basePart);
                basePart = enclosedPart;
            }
            else
            {
                this.SetPartPos(x, y, null);
            }
        }
        if (basePart)
        {
            this.m_parts.Remove(basePart);
        }
        this.RefreshNeighbours(x, y);
        return basePart;
    }

    public void RemovePart(BasePart part)
    {
        if (!part)
        {
            return;
        }
        if (part.enclosedPart)
        {
            part.enclosedPart.enclosedInto = null;
            part.enclosedPart = null;
        }
        this.m_parts.Remove(part);
    }

    public void RemoveAllDynamicParts()
    {
        List<BasePart> list = new List<BasePart>();
        foreach (BasePart basePart in this.m_parts)
        {
            if (!basePart.m_static)
            {
                UnityEngine.Object.Destroy(basePart.gameObject);
                list.Add(basePart);
            }
        }
        foreach (BasePart basePart2 in list)
        {
            this.RemovePartAt(basePart2.m_coordX, basePart2.m_coordY);
        }
    }

    public void AutoAlign(BasePart part)
    {
        if (part.enclosedInto != null)
        {
            return;
        }
        if (part.m_autoAlign == BasePart.AutoAlignType.None)
        {
            return;
        }
        if (part.m_autoAlign == BasePart.AutoAlignType.Rotate)
        {
            BasePart.JointConnectionDirection jointConnectionDirection = BasePart.JointConnectionDirection.Any;
            if (this.IsConnectionSourceTo(part.m_coordX - 1, part.m_coordY, BasePart.Direction.Right))
            {
                jointConnectionDirection = BasePart.JointConnectionDirection.Left;
            }
            else if (this.IsConnectionSourceTo(part.m_coordX + 1, part.m_coordY, BasePart.Direction.Left))
            {
                jointConnectionDirection = BasePart.JointConnectionDirection.Right;
            }
            else if (this.IsConnectionSourceTo(part.m_coordX, part.m_coordY + 1, BasePart.Direction.Down))
            {
                jointConnectionDirection = BasePart.JointConnectionDirection.Up;
            }
            else if (this.IsConnectionSourceTo(part.m_coordX, part.m_coordY - 1, BasePart.Direction.Up))
            {
                jointConnectionDirection = BasePart.JointConnectionDirection.Down;
            }
            if (part.GetComponent<Rope>())
            {
                if (this.IsPartTypeAt(part.m_coordX - 1, part.m_coordY, BasePart.PartType.Rope, BasePart.GridRotation.Deg_0))
                {
                    jointConnectionDirection = BasePart.JointConnectionDirection.Left;
                }
                else if (this.IsPartTypeAt(part.m_coordX + 1, part.m_coordY, BasePart.PartType.Rope, BasePart.GridRotation.Deg_0))
                {
                    jointConnectionDirection = BasePart.JointConnectionDirection.Right;
                }
                else if (this.IsPartTypeAt(part.m_coordX, part.m_coordY + 1, BasePart.PartType.Rope, BasePart.GridRotation.Deg_270))
                {
                    jointConnectionDirection = BasePart.JointConnectionDirection.Up;
                }
                else if (this.IsPartTypeAt(part.m_coordX, part.m_coordY - 1, BasePart.PartType.Rope, BasePart.GridRotation.Deg_270))
                {
                    jointConnectionDirection = BasePart.JointConnectionDirection.Down;
                }
            }
            if (jointConnectionDirection != BasePart.JointConnectionDirection.Any)
            {
                BasePart.GridRotation gridRotation = part.AutoAlignRotation(jointConnectionDirection);
                if (part.GetComponent<Rope>())
                {
                    if (gridRotation == BasePart.GridRotation.Deg_180)
                    {
                        gridRotation = BasePart.GridRotation.Deg_0;
                    }
                    if (gridRotation == BasePart.GridRotation.Deg_90)
                    {
                        gridRotation = BasePart.GridRotation.Deg_270;
                    }
                }
                part.SetRotation(gridRotation);
                part.OnChangeConnections();
                this.RefreshNeighboursVisual(part.m_coordX, part.m_coordY);
            }
        }
        else if (part.m_autoAlign == BasePart.AutoAlignType.FlipVertically)
        {
            if (this.IsChassisPart(part.m_coordX + 1, part.m_coordY))
            {
                part.SetFlipped(false);
            }
            else if (this.IsChassisPart(part.m_coordX - 1, part.m_coordY))
            {
                part.SetFlipped(true);
            }
        }
    }

    public bool Flip(BasePart part)
    {
        bool result = false;
        if (part.m_autoAlign == BasePart.AutoAlignType.FlipVertically)
        {
            for (int i = 0; i < 3; i++)
            {
                part.SetFlipped(!part.IsFlipped());
                result = (i != 1);
                if (part.m_jointConnectionDirection == BasePart.JointConnectionDirection.Any || this.CanConnectTo(part, BasePart.ConvertDirection(part.GetJointConnectionDirection())))
                {
                    break;
                }
            }
        }
        else if (part.m_autoAlign == BasePart.AutoAlignType.Rotate)
        {
            if (part.m_jointConnectionDirection == BasePart.JointConnectionDirection.Any)
            {
                part.RotateClockwise();
                part.OnChangeConnections();
                this.RefreshNeighboursVisual(part.m_coordX, part.m_coordY);
                result = true;
            }
            else
            {
                for (int j = 0; j < 5; j++)
                {
                    part.RotateClockwise();
                    result = (j != 3);
                    if (part.GetComponent<Rope>())
                    {
                        if (part.m_gridRotation == BasePart.GridRotation.Deg_0 || part.m_gridRotation == BasePart.GridRotation.Deg_270)
                        {
                            break;
                        }
                    }
                    else if (this.CanConnectTo(part, part.GetJointConnectionDirection()))
                    {
                        break;
                    }
                }
                this.RefreshNeighboursVisual(part.m_coordX, part.m_coordY);
            }
        }
        return result;
    }

    private bool IsChassisPart(int coordX, int coordY)
    {
        BasePart basePart = this.FindPartAt(coordX, coordY);
        return basePart && basePart.IsPartOfChassis();
    }

    private bool IsConnectionSourceTo(int coordX, int coordY, BasePart.Direction direction)
    {
        BasePart basePart = this.FindPartAt(coordX, coordY);
        return basePart && basePart.m_jointConnectionType == BasePart.JointConnectionType.Source && (basePart.CanConnectTo(direction) || basePart.CanCustomConnectTo(direction));
    }

    public bool CanPlaceSpecificPartAt(int coordX, int coordY, BasePart newPart)
    {
        BasePart basePart = this.FindPartAt(coordX, coordY);
        if (basePart && basePart.enclosedPart)
        {
            basePart = basePart.enclosedPart;
        }
        return !basePart || ((!basePart.m_static || (basePart.CanEncloseParts() && newPart.CanBeEnclosed())) && (!basePart.CanBeEnclosed() || !newPart.CanEncloseParts() || true));
    }

    public void Update()
    {
        if (!this.m_running)
        {
            return;
        }
        if ((this.m_jointDetached & 1) != 0)
        {
            this.m_broken = true;
            for (int i = this.m_jointMap.Count - 1; i >= 0; i--)
            {
                JointConnection item = this.m_jointMap[i];
                if (item.joint == null || item.partA == null || item.partB == null)
                {
                    if (item.partA != null && item.partA.enclosedInto != null && item.partA.enclosedInto == item.partB)
                    {
                        item.partA.enclosedInto.enclosedPart = null;
                        item.partA.enclosedInto.OnEnclosedPartDetached();
                        item.partA.m_enclosedInto = null;
                        item.partA.OnDetach();
                    }
                    if (item.partB != null && item.partB.enclosedInto != null && item.partB.enclosedInto == item.partA)
                    {
                        item.partB.enclosedInto.enclosedPart = null;
                        item.partB.enclosedInto.OnEnclosedPartDetached();
                        item.partB.m_enclosedInto = null;
                        item.partB.OnDetach();
                    }
                    this.m_jointMap.RemoveAt(i);
                }
            }
            this.FindConnectedComponents();
            this.InitializeEngines();
            this.CountActiveParts();
            this.FindComponentsConnectedByRope();
        }
        this.m_jointDetached >>= 1;
        if (this.m_pig != null)
        {
            if (this.m_pig.rigidbody.velocity.magnitude < 0.2f)
            {
                this.m_stopTimer += Time.deltaTime;
            }
            else
            {
                this.m_stopTimer = 0f;
            }
        }
        for (int i = 0; i < GuiManager.PointerCount; i++)
        {
            GuiManager.Pointer pointer = GuiManager.GetPointer(i);
            if (pointer.down && !pointer.onWidget)
            {
                Vector3 position = pointer.position;
                position.z = this.m_gameCamera.farClipPlane;
                Vector3 vector = WPFMonoBehaviour.ScreenToZ0(position);
                foreach (BasePart basePart in this.m_parts)
                {
                    if (basePart && basePart.IsInInteractiveRadius(vector) && !basePart.enclosedPart && basePart.gameObject.layer != this.m_droppedSandbagLayer)
                    {
                        basePart.ProcessTouch(vector);
                        EventManager.Send(default(UserInputEvent));
                        break;
                    }
                }
            }
        }
    }

    public void SetVisible(bool visible)
    {
        base.gameObject.SetActive(visible);
    }

    private void InternalSetVisible(Transform t, bool enable)
    {
        if (enable)
        {
            t.gameObject.SetActive(true);
        }
        for (int i = 0; i < t.childCount; i++)
        {
            this.InternalSetVisible(t.GetChild(i), enable);
        }
        if (!enable)
        {
            t.gameObject.SetActive(false);
        }
    }

    public void RefreshConnections()
    {
        foreach (BasePart basePart in this.m_parts)
        {
            basePart.OnChangeConnections();
        }
    }

    private void CopyActiveStates(GameObject original, GameObject clone)
    {
        clone.SetActive(original.activeSelf);
        for (int i = 0; i < original.transform.childCount; i++)
        {
            this.CopyActiveStates(original.transform.GetChild(i).gameObject, clone.transform.GetChild(i).gameObject);
        }
    }

    public void SetTouchingGround(bool touching)
    {
        this.m_contraptionTouchingGround = touching;
    }

    public bool GetTouchingGround()
    {
        return this.m_contraptionTouchingGround;
    }

    public void SetHangingFromHook(bool hanging, int id)
    {
        this.m_contraptionHangingFromHook[id] = hanging;
    }

    public bool GetHangingFromHook()
    {
        return this.m_contraptionHangingFromHook.ContainsValue(true);
    }

    public void SetSwings(int swing)
    {
        this.m_numberOfSwings = swing;
    }

    public int GetSwings()
    {
        return this.m_numberOfSwings;
    }

    public Contraption Clone()
    {
        GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(base.gameObject);
        this.CopyActiveStates(base.gameObject, gameObject);
        return gameObject.GetComponent<Contraption>();
    }

    public bool ConsiderCollided()
    {
        return Time.time - this.m_timeLastCollided < 0.3f;
    }

    public bool ValidateContraption()
    {
        if (!this.m_isValidationRequired)
        {
            return this.m_lastValidation;
        }
        this.m_isValidationRequired = false;
        bool flag = false;
        bool flag2 = false;
        bool flag3 = false;
        bool flag4 = false;
        List<BasePart> list = new List<BasePart>();
        List<BasePart> list2 = new List<BasePart>();
        bool flag5 = true;
        foreach (BasePart basePart in this.m_parts)
        {
            if (basePart.m_partType == BasePart.PartType.Pig)
            {
                flag = true;
            }
            if (basePart.m_partType == BasePart.PartType.Egg)
            {
                flag2 = true;
            }
            if (basePart.m_partType == BasePart.PartType.Pumpkin)
            {
                flag3 = true;
            }
            if (basePart.m_partType == BasePart.PartType.TimeBomb)
            {
                flag4 = true;
            }
            if (basePart.IsPartOfChassis())
            {
                if (list.Count == 0)
                {
                    list.Add(basePart);
                }
                list2.Add(basePart);
            }
            if (!basePart.ValidatePart())
            {
                flag5 = false;
            }
        }
        bool flag6;
        bool flag7;
        do
        {
            flag6 = false;
            flag7 = true;
            foreach (BasePart basePart2 in list2)
            {
                if (!list.Contains(basePart2))
                {
                    List<BasePart> list3 = this.FindNeighbours(basePart2.m_coordX, basePart2.m_coordY);
                    foreach (BasePart basePart3 in list3)
                    {
                        if (basePart3 && list.Contains(basePart3))
                        {
                            flag6 = true;
                            list.Add(basePart2);
                            break;
                        }
                    }
                    flag7 = false;
                }
            }
        }
        while (flag6);
        if (WPFMonoBehaviour.levelManager.RequireConnectedContraption && !flag7)
        {
            return this.m_lastValidation = false;
        }
        if (!flag5 || !flag || (WPFMonoBehaviour.levelManager.EggRequired && !flag2) || (WPFMonoBehaviour.levelManager.PumpkinRequired && !flag3) || (WPFMonoBehaviour.levelManager.CurrentGameMode is CakeRaceMode && !flag4))
        {
            return this.m_lastValidation = false;
        }
        return this.m_lastValidation = true;
    }

    public void MakeUnbreakable()
    {
        foreach (JointConnection JointConnection in this.m_jointMap)
        {
            if (JointConnection.joint != null)
            {
                JointConnection.joint.breakForce = float.PositiveInfinity;
            }
        }
    }

    public List<Joint> FindPartFixedJoints(BasePart part)
    {
        List<Joint> list = new List<Joint>();
        BasePart basePart = (part.enclosedInto == null) ? ((part.enclosedPart == null) ? null : part.enclosedPart) : part.enclosedInto;
        for (int i = 0; i < this.m_jointMap.Count; i++)
        {
            JointConnection JointConnection = this.m_jointMap[i];
            if (JointConnection.joint != null && (JointConnection.joint is FixedJoint || JointConnection.joint is HingeJoint))
            {
                if (JointConnection.partA == part || JointConnection.partB == part || (basePart != null && (JointConnection.partA == basePart || JointConnection.partB == basePart)))
                {
                    list.Add(JointConnection.joint);
                }
            }
        }
        return list;
    }

    public void DestroyAllJoints()
    {
        foreach (JointConnection JointConnection in this.m_jointMap)
        {
            if (JointConnection.joint != null)
            {
                UnityEngine.Object.Destroy(JointConnection.joint);
            }
        }
        this.m_jointMap.Clear();
    }

    public void AddJointToMap(BasePart endJointA, BasePart endJointB, Joint joint)
    {
        JointConnection item;
        item.partA = endJointA;
        item.partB = endJointB;
        item.joint = joint;
        this.m_jointMap.Add(item);
    }

    public bool HasComponentEngine(int componentIndex)
    {
        return componentIndex >= 0 && componentIndex < this.m_connectedComponents.Count && this.m_connectedComponents[componentIndex].hasEngine;
    }

    public int ComponentPartCount(int componentIndex)
    {
        if (componentIndex >= 0 && componentIndex < this.m_connectedComponents.Count)
        {
            return this.m_connectedComponents[componentIndex].partCount;
        }
        return 0;
    }

    public bool HasPoweredPartsRunning(int componentIndex)
    {
        for (int i = 0; i < this.m_parts.Count; i++)
        {
            BasePart basePart = this.m_parts[i];
            if (basePart.ConnectedComponent == componentIndex && basePart.IsEnabled() && basePart.IsPowered())
            {
                return true;
            }
        }
        return false;
    }

    public void ApplySuperGlue(Glue.Type type)
    {
        if (this.m_currentGlue == Glue.Type.None)
        {
            Singleton<AudioManager>.Instance.Play2dEffect(WPFMonoBehaviour.gameData.commonAudioCollection.SuperGlueApplied);
            if (Singleton<SocialGameManager>.IsInstantiated())
            {
                Singleton<SocialGameManager>.Instance.ReportAchievementProgress("grp.INDESTRUCTIBLE", 100.0);
            }
        }
        this.m_currentGlue = type;
        Glue.ShowSuperGlue(this, type);
    }

    public void RemoveSuperGlue()
    {
        this.m_currentGlue = Glue.Type.None;
        Glue.RemoveSuperGlue(this);
    }

    private void AddTurboChargeEffect(GameObject part)
    {
        Transform x = part.transform.Find(WPFMonoBehaviour.gameData.m_turboChargeEffect.name);
        if (x == null)
        {
            GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(WPFMonoBehaviour.gameData.m_turboChargeEffect, part.transform.position, Quaternion.identity);
            gameObject.name = WPFMonoBehaviour.gameData.m_turboChargeEffect.name;
            gameObject.transform.parent = part.transform;
        }
    }

    private void ResetTurboCharge()
    {
        this.m_enginePowerFactor = 1f;
        foreach (BasePart basePart in this.m_parts)
        {
            if (basePart.IsEngine())
            {
                Transform transform = basePart.transform.Find(WPFMonoBehaviour.gameData.m_turboChargeEffect.name);
                if (transform)
                {
                    UnityEngine.Object.Destroy(transform.gameObject);
                }
            }
        }
    }

    private void ApplyTurboCharge()
    {
        if (this.m_enginePowerFactor != WPFMonoBehaviour.gameData.m_turboChargePowerFactor)
        {
            if (Singleton<SocialGameManager>.IsInstantiated())
            {
                Singleton<SocialGameManager>.Instance.ReportAchievementProgress("grp.SUPER_CHARGED", 100.0);
            }
            Singleton<AudioManager>.Instance.Play2dEffect(WPFMonoBehaviour.gameData.commonAudioCollection.TurboChargeApplied);
        }
        this.m_enginePowerFactor = WPFMonoBehaviour.gameData.m_turboChargePowerFactor;
        foreach (BasePart basePart in this.m_parts)
        {
            if (basePart.IsEngine())
            {
                this.AddTurboChargeEffect(basePart.gameObject);
            }
        }
    }

    private void ApplyNightVisionGoggles()
    {
        foreach (BasePart basePart in this.m_parts)
        {
            if (basePart.m_partType == BasePart.PartType.Pig)
            {
                if (this.nightVisionGogglesPrefab == null)
                {
                    this.nightVisionGogglesPrefab = Resources.Load<GameObject>("Prefabs/NightVisionGoggles");
                }
                if (this.m_hasNightVision && this.nightVisionGoggles == null)
                {
                    this.nightVisionGoggles = UnityEngine.Object.Instantiate<GameObject>(this.nightVisionGogglesPrefab);
                    this.nightVisionGoggles.transform.parent = basePart.transform.Find("PigVisualization/Face/MaskHolder");
                    this.nightVisionGoggles.transform.localPosition = Vector3.up * 0.02f;
                    this.nightVisionGoggles.transform.localScale = Vector3.one;
                    PigHat componentInChildren = basePart.transform.GetComponentInChildren<PigHat>(true);
                    if (componentInChildren)
                    {
                        componentInChildren.Show(false);
                    }
                }
                else if (!this.m_hasNightVision && this.nightVisionGoggles != null)
                {
                    UnityEngine.Object.Destroy(this.nightVisionGoggles);
                    PigHat componentInChildren2 = basePart.transform.GetComponentInChildren<PigHat>(true);
                    if (componentInChildren2)
                    {
                        componentInChildren2.Show(true);
                    }
                }
            }
        }
    }

    public BasePart m_cameraTarget;

    public BasePart m_pig;

    public int m_enginesAmount;

    public int m_jointDetached;

    protected List<BasePart> m_parts = new List<BasePart>();

    protected Dictionary<int, BasePart> m_partMap = new Dictionary<int, BasePart>();

    protected List<BasePart> m_integralParts = new List<BasePart>();

    protected Camera m_gameCamera;

    protected bool m_running;

    protected List<JointConnection> m_jointMap = new List<JointConnection>();

    private float m_enginePowerFactor = 1f;

    private ContraptionDataset m_contraptionDataSet;

    private List<Rope> m_ropes = new List<Rope>();

    private float m_powerConsumption;

    private float m_stopTimer;

    private List<ConnectedComponent> m_connectedComponents = new List<ConnectedComponent>();

    private List<int> m_componentsConnectedByRope = new List<int>();

    private Dictionary<BasePart.PartType, int[]> m_oneShotPartAmount = new Dictionary<BasePart.PartType, int[]>();

    private Dictionary<BasePart.PartType, int[]> m_poweredPartAmount = new Dictionary<BasePart.PartType, int[]>();

    private Dictionary<BasePart.PartType, int[]> m_pushablePartAmount = new Dictionary<BasePart.PartType, int[]>();

    private int m_droppedSandbagLayer;

    private bool m_broken;

    private List<PartPlacementInfo> m_partPlacements = new List<PartPlacementInfo>();

    private int m_staticPartCount;

    private ConnectionSearchState m_connectionSearchState = new ConnectionSearchState();

    [SerializeField]
    [HideInInspector]
    private Glue.Type m_currentGlue;

    [SerializeField]
    [HideInInspector]
    private bool m_hasSuperMagnet;

    [SerializeField]
    [HideInInspector]
    private bool m_hasTurboCharge;

    [SerializeField]
    [HideInInspector]
    private bool m_hasNightVision;

    private GameObject nightVisionGogglesPrefab;

    private GameObject nightVisionGoggles;

    private bool m_contraptionTouchingGround;

    private Dictionary<int, bool> m_contraptionHangingFromHook = new Dictionary<int, bool>();

    private int m_numberOfSwings;

    protected float m_timeLastCollided;

    private bool m_lastValidation;

    private bool m_isValidationRequired = true;

    protected struct JointConnection
    {
        public BasePart partA;

        public BasePart partB;

        public Joint joint;
    }

    private struct ConnectedComponent
    {
        public bool hasEngine;

        public bool hasGearbox;

        public Gearbox gearbox;

        public float enginePower;

        public float powerConsumption;

        public List<MotorWheel> motorWheels;

        public int partCount;

        public float groundTouchTime;
    }

    public class PartPlacementInfo
    {
        public PartPlacementInfo(BasePart.PartType partType, BasePart.Direction direction, Vector3 averagePosition, int count)
        {
            this.partType = partType;
            this.direction = direction;
            this.averagePosition = averagePosition;
            this.count = count;
        }

        public BasePart.PartType partType;

        public BasePart.Direction direction;

        public Vector3 averagePosition = Vector3.zero;

        public int count;
    }

    private class PartOrder : IComparer<PartPlacementInfo>
    {
        public int Compare(PartPlacementInfo obj1, PartPlacementInfo obj2)
        {
            if (InGameFlightMenu.CombinedTypeForGadgetButtonOrdering(obj1.partType) == BasePart.PartType.Balloon || InGameFlightMenu.CombinedTypeForGadgetButtonOrdering(obj2.partType) == BasePart.PartType.Balloon)
            {
                return 0;
            }
            if (obj1.averagePosition.x < obj2.averagePosition.x)
            {
                return -1;
            }
            if (obj1.averagePosition.x > obj2.averagePosition.x)
            {
                return 1;
            }
            return 0;
        }
    }

    private class ConnectionSearchState
    {
        public Queue<int> components = new Queue<int>();

        public HashSet<int> visited = new HashSet<int>();
    }
}
