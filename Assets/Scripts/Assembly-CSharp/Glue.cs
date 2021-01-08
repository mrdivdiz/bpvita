using System.Collections.Generic;
using UnityEngine;

public class Glue : MonoBehaviour
{
    public static void ShowSuperGlue(Contraption contraption, Type type)
    {
        if (type == Glue.Type.None)
        {
            return;
        }
        if (contraption.CurrentGlue != Glue.Type.None || contraption.CurrentGlue != type)
        {
            Glue.RemoveSuperGlue(contraption);
        }
        Glue.ShowSuperGlue(contraption, type, contraption.Parts);
    }

    public static void ShowSuperGlue(Contraption contraption, Type type, List<BasePart> parts)
    {
        foreach (BasePart basePart in parts)
        {
            if (Glue.IsPartTypeRequireGlue(basePart.m_partType))
            {
                BasePart anotherPart = contraption.FindPartAt(basePart.m_coordX - 1, basePart.m_coordY);
                BasePart anotherPart2 = contraption.FindPartAt(basePart.m_coordX + 1, basePart.m_coordY);
                BasePart anotherPart3 = contraption.FindPartAt(basePart.m_coordX, basePart.m_coordY - 1);
                BasePart anotherPart4 = contraption.FindPartAt(basePart.m_coordX, basePart.m_coordY + 1);
                Glue exists = basePart.GetComponent<Glue>();
                if (exists == null)
                {
                    exists = basePart.gameObject.AddComponent<Glue>();
                }
                Glue.CheckSideAndAppendGlue(basePart, anotherPart, Glue.Direction.Left, type);
                Glue.CheckSideAndAppendGlue(basePart, anotherPart2, Glue.Direction.Right, type);
                Glue.CheckSideAndAppendGlue(basePart, anotherPart4, Glue.Direction.Up, type);
                Glue.CheckSideAndAppendGlue(basePart, anotherPart3, Glue.Direction.Down, type);
            }
        }
    }

    public static void RemoveSuperGlue(Contraption contraption)
    {
        Glue.RemoveSuperGlue(contraption.Parts);
    }

    public static void RemoveSuperGlue(List<BasePart> parts)
    {
        foreach (BasePart basePart in parts)
        {
            if (Glue.IsPartTypeRequireGlue(basePart.m_partType))
            {
                Glue component = basePart.GetComponent<Glue>();
                if (component != null)
                {
                    for (int i = basePart.transform.childCount - 1; i >= 0; i--)
                    {
                        GameObject gameObject = basePart.transform.GetChild(i).gameObject;
                        if (gameObject.name.StartsWith(WPFMonoBehaviour.gameData.m_glueSprite.name) || gameObject.name.StartsWith(WPFMonoBehaviour.gameData.m_alienGlueSprite.name))
                        {
                            UnityEngine.Object.DestroyImmediate(gameObject);
                        }
                    }
                    UnityEngine.Object.DestroyImmediate(component);
                }
            }
        }
    }

    public static bool ContraptionHasGluedParts(Contraption contraption)
    {
        foreach (BasePart x in contraption.Parts)
        {
            if (x.GetComponent<Glue>() != null)
            {
                return true;
            }
        }
        return false;
    }

    private static bool IsPartTypeRequireGlue(BasePart.PartType type)
    {
        return type == BasePart.PartType.WoodenFrame || type == BasePart.PartType.MetalFrame;
    }

    private static void AddSuperGlueSprite(Glue glue, Direction dir, Type type)
    {
        GameObject gameObject = (type != Glue.Type.Alien ? WPFMonoBehaviour.gameData.m_glueSprite : WPFMonoBehaviour.gameData.m_alienGlueSprite);
        Vector3 localPosition = new Vector3(((dir != Glue.Direction.Left) ? ((dir != Glue.Direction.Right) ? 0f : 0.5f) : (-0.5f)), ((dir != Glue.Direction.Down) ? ((dir != Glue.Direction.Up) ? 0f : 0.5f) : (-0.5f)), -0.01f);
        Quaternion localRotation = Quaternion.AngleAxis((dir != Glue.Direction.Up && dir != Glue.Direction.Down) ? 0f : 90f, Vector3.back);
        Transform transform = UnityEngine.Object.Instantiate<GameObject>(gameObject).transform;
        transform.parent = glue.transform;
        transform.localPosition = localPosition;
        transform.localRotation = localRotation;
        glue.m_GlueDirectionMask |= (int)dir;
    }

    private static void CheckSideAndAppendGlue(BasePart partWithGlue, BasePart anotherPart, Direction dir, Type type)
    {
        bool flag = dir == Glue.Direction.Up || dir == Glue.Direction.Down;
        bool flag2 = dir == Glue.Direction.Left || dir == Glue.Direction.Right;
        Glue component = partWithGlue.GetComponent<Glue>();
        if (anotherPart != null)
        {
            Glue component2 = anotherPart.GetComponent<Glue>();
            BasePart.JointConnectionDirection jointConnectionDirection = anotherPart.GetJointConnectionDirection();
            bool flag3 = BasePart.IsDirection(jointConnectionDirection);
            bool flag4 = (flag3 && Glue.OppositeGlueDir(BasePart.ConvertDirection(jointConnectionDirection)) == dir) || (flag && jointConnectionDirection == BasePart.JointConnectionDirection.UpAndDown) || (flag2 && jointConnectionDirection == BasePart.JointConnectionDirection.LeftAndRight) || (jointConnectionDirection == BasePart.JointConnectionDirection.Any && anotherPart.GetJointConnectionType() != BasePart.JointConnectionType.None);
            if ((component.m_GlueDirectionMask & (int)dir) == 0)
            {
                if (component2)
                {
                    if ((component2.m_GlueDirectionMask & (int)Glue.OppositeGlueDir(dir)) == 0)
                    {
                        Glue.AddSuperGlueSprite(component, dir, type);
                    }
                }
                else if (Glue.IsPartTypeRequireGlue(anotherPart.m_partType) || flag4)
                {
                    Glue.AddSuperGlueSprite(component, dir, type);
                }
                else
                {
                    Glue.RemoveSuperGlueSprite(component, dir);
                }
            }
            else if (!Glue.IsPartTypeRequireGlue(anotherPart.m_partType) && !flag4)
            {
                Glue.RemoveSuperGlueSprite(component, dir);
            }
        }
        else if (!anotherPart && (component.m_GlueDirectionMask & (int)dir) != 0)
        {
            Glue.RemoveSuperGlueSprite(component, dir);
        }
    }

    private static void RemoveSuperGlueSprite(Glue glue, Direction dir)
    {
        if (glue != null && (glue.m_GlueDirectionMask & (int)dir) != 0)
        {
            for (int i = glue.transform.childCount - 1; i >= 0; i--)
            {
                GameObject gameObject = glue.transform.GetChild(i).gameObject;
                if (gameObject.name.StartsWith(WPFMonoBehaviour.gameData.m_glueSprite.name) || gameObject.name.StartsWith(WPFMonoBehaviour.gameData.m_alienGlueSprite.name))
                {
                    switch (dir)
                    {
                        case Glue.Direction.Left:
                            if (gameObject.transform.localPosition.x < 0f)
                            {
                                UnityEngine.Object.DestroyImmediate(gameObject);
                            }
                            break;
                        case Glue.Direction.Right:
                            if (gameObject.transform.localPosition.x > 0f)
                            {
                                UnityEngine.Object.DestroyImmediate(gameObject);
                            }
                            break;
                        case Glue.Direction.Up:
                            if (gameObject.transform.localPosition.y > 0f)
                            {
                                UnityEngine.Object.DestroyImmediate(gameObject);
                            }
                            break;
                        case Glue.Direction.Down:
                            if (gameObject.transform.localPosition.y < 0f)
                            {
                                UnityEngine.Object.DestroyImmediate(gameObject);
                            }
                            break;
                    }
                }
            }
            glue.m_GlueDirectionMask &= (int)(~(int)dir);
        }
    }

    public static Direction OppositeGlueDir(Direction dir)
    {
        if (dir == Glue.Direction.Left || dir == Glue.Direction.Right)
        {
            return (dir != Glue.Direction.Left) ? Glue.Direction.Left : Glue.Direction.Right;
        }
        return (dir != Glue.Direction.Up) ? Glue.Direction.Up : Glue.Direction.Down;
    }

    public static Direction OppositeGlueDir(BasePart.Direction dir)
    {
        if (dir == BasePart.Direction.Left || dir == BasePart.Direction.Right)
        {
            return (dir != BasePart.Direction.Left) ? Glue.Direction.Left : Glue.Direction.Right;
        }
        return (dir != BasePart.Direction.Up) ? Glue.Direction.Up : Glue.Direction.Down;
    }

    public int m_GlueDirectionMask;

    public enum Direction
    {
        Left = 1,
        Right,
        Up = 4,
        Down = 8
    }

    public enum Type
    {
        None,
        Regular,
        Alien
    }
}
