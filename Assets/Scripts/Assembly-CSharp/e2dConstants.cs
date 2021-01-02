using UnityEngine;

public class e2dConstants
{
	public static readonly bool CHECK_CURVE_INTERCROSSING = false;

	public static readonly Color COLOR_HANDLE_CENTER = new Color(1f, 1f, 1f, 0.6f);

	public static readonly Color COLOR_HANDLE_X_SLIDER = new Color(1f, 0.2f, 0.2f, 0.9f);

	public static readonly Color COLOR_HANDLE_Y_SLIDER = new Color(0.2f, 1f, 0.2f, 0.9f);

	public static readonly float SCALE_HANDLE_CENTER = 0.15f;

	public static readonly float SCALE_HANDLE_CENTER_DOT = 0.05f;

	public static readonly float SCALE_HANDLE_SLIDER = 1f;

	public static readonly float SCALE_HANDLE_ROTATION = 1.1f;

	public static readonly float RECT_FIELD_PADDING = 2f;

	public static readonly float RECT_FIELD_LABEL_MARGIN = 2f;

	public static readonly float VECTOR_FIELD_PADDING = 5f;

	public static readonly float VECTOR_FIELD_LABEL_MARGIN = 10f;

	public static readonly float COLLISION_MESH_Z_DEPTH = 10f;

	public static readonly int NUM_TEXTURES_PER_STRIPE_SHADER = 4;

	public static readonly string FILL_MESH_NAME = "_fill";

	public static readonly string CURVE_MESH_NAME = "_curve";

	public static readonly string COLLIDER_MESH_NAME = "_collider";

	public static readonly float INIT_FILL_TEXTURE_WIDTH = 1f;

	public static readonly float INIT_FILL_TEXTURE_HEIGHT = 1f;

	public static readonly float INIT_FILL_TEXTURE_OFFSET_X = 0f;

	public static readonly float INIT_FILL_TEXTURE_OFFSET_Y = 0f;

	public static readonly bool INIT_CURVE_CLOSED = false;

	public static readonly bool INIT_NO_COLLIDER = false;

	public static readonly float FILL_TEXTURE_SIZE_MIN = float.Epsilon;

	public static readonly float FILL_TEXTURE_SIZE_MAX = 20f;

	public static readonly float FILL_TEXTURE_OFFSET_MAX = 20f;

	public static readonly float TEXTURE_WIDTH_MIN = 0.1f;

	public static readonly float TEXTURE_WIDTH_MAX = 10f;

	public static readonly float TEXTURE_HEIGHT_MIN = 0f;

	public static readonly float TEXTURE_HEIGHT_MAX = 5f;

	public static readonly float CONTROL_TEXTURE_SIZE = 50f;

	public static readonly float SCENE_GIZMOS_SIZE = 78f;

	public static readonly Color COLOR_CURVE_NORMAL = new Color(0.8f, 0f, 0f);

	public static readonly Color COLOR_CURVE_BRUSH_LINE = new Color(0f, 0.3f, 1f, 0.3f);

	public static readonly Color COLOR_CURVE_BRUSH_SPHERE = new Color(0f, 0f, 1f, 0.3f);

	public static readonly Color COLOR_BOUNDARY_RECT = new Color(0f, 0.5f, 0.5f);

	public static readonly Color COLOR_NODE_CURSOR = new Color(0f, 0f, 1f, 0.5f);

	public static readonly Color COLOR_BRUSH_ARROW = new Color(1f, 0f, 0f, 0.8f);

	public static readonly float SCALE_CURVE_BRUSH_LINE = 0.1f;

	public static readonly float SCALE_CURVE_BRUSH_SPHERE = 0.2f;

	public static readonly float SCALE_NODE_HANDLES = 2.5f;

	public static readonly float SCALE_NODES_CURSOR = 0.2f;

	public static readonly float SCALE_NODES_CURVE_SPHERE = 0.1f;

	public static readonly float SCALE_BRUSH_ARROW = 2f;

	public static readonly float BRUSH_HEIGHT_RATIO = 0.05f;

	public static readonly float BRUSH_SIZE_INC_RATIO = 40f;

	public static readonly float BRUSH_ANGLE_INC_RATIO = 150f;

	public static readonly float BRUSH_TEXTURE_INC_RATIO = 2f;

	public static readonly float BRUSH_OPACITY_INC_RATIO = 40f;

	public static readonly float BRUSH_APPLY_STEP_RATIO = 0.3f;

	public static readonly int BRUSH_SIZE_MIN = 1;

	public static readonly int BRUSH_SIZE_MAX = 50;

	public static readonly int INIT_BRUSH_SIZE = 15;

	public static readonly int BRUSH_OPACITY_MIN = 0;

	public static readonly int BRUSH_OPACITY_MAX = 100;

	public static readonly int INIT_BRUSH_OPACITY = 50;

	public static readonly float INIT_BRUSH_ANGLE = 0f;

	public static readonly float GENERATOR_STEP_NODE_SIZE_MIN = 0.001f;

	public static readonly float PERLIN_FREQUENCY_MIN = 0.001f;

	public static readonly float PERLIN_FREQUENCY_MAX = 0.2f;

	public static readonly int PERLIN_OCTAVES_MIN = 1;

	public static readonly int PERLIN_OCTAVES_MAX = 20;

	public static readonly float PERLIN_PERSISTENCE_MIN = 0.001f;

	public static readonly float PERLIN_PERSISTENCE_MAX = 1f;

	public static readonly float VORONOI_FREQUENCY_MIN = 0.001f;

	public static readonly float VORONOI_FREQUENCY_MAX = 0.2f;

	public static readonly float VORONOI_PEAK_RATIO_MIN = 0.001f;

	public static readonly float VORONOI_PEAK_RATIO_MAX = 1f;

	public static readonly float VORONOI_PEAK_WIDTH_MIN = 0.001f;

	public static readonly float VORONOI_PEAK_WIDTH_MAX = 1f;

	public static readonly float VORONOI_SIN_POWER_MIN = 0.6f;

	public static readonly float VORONOI_SIN_POWER_MAX = 2.5f;

	public static readonly float VORONOI_QUADRATIC_PEAK_WIDTH_RATIO = 4f;

	public static readonly float MIDPOINT_FREQUENCY_MIN = 0.001f;

	public static readonly float MIDPOINT_FREQUENCY_MAX = 0.2f;

	public static readonly float MIDPOINT_ROUGHNESS_MIN = 0f;

	public static readonly float MIDPOINT_ROUGHNESS_MAX = 1f;

	public static readonly float MIDPOINT_ROUGHNESS_POWER_MIN = -2f;

	public static readonly float MIDPOINT_ROUGHNESS_POWER_MAX = -0.5f;

	public static readonly float WALK_FREQUENCY_MIN = 0.001f;

	public static readonly float WALK_FREQUENCY_MAX = 0.5f;

	public static readonly float WALK_ANGLE_CHANGE_MIN = 0f;

	public static readonly float WALK_ANGLE_CHANGE_MAX = 100f;

	public static readonly float WALK_COHESION_MIN = 0f;

	public static readonly float WALK_COHESION_MAX = 2f;

	public static readonly int SMOOTH_ITERATIONS_MIN = 1;

	public static readonly int SMOOTH_ITERATIONS_MAX = 100;

	public static readonly bool INIT_FULL_REBUILD = true;

	public static readonly float INIT_NODE_STEP_SIZE = 0.5f;

	public static readonly Vector2 INIT_TARGET_POSITION = new Vector2(50f, 50f);

	public static readonly Vector2 INIT_TARGET_SIZE = new Vector2(100f, 100f);

	public static readonly float INIT_TARGET_ANGLE = 0f;

	public static readonly Color COLOR_TARGET_AREA = new Color(0f, 0.5f, 1f, 0.7f);

	public static readonly Color COLOR_GENERATOR_PEAKS = new Color(1f, 0f, 0f, 0.9f);

	public static readonly float SCALE_TARGET_AREA_LINE_WIDTH = 0.01f;

	public static readonly float SCALE_GENERATOR_PEAKS = 0.15f;
}
