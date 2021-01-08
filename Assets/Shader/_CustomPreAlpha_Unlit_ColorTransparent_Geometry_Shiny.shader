Shader "_Custom/PreAlpha_Unlit_ColorTransparent_Geometry_Shiny" {
	Properties {
		_MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
		_Color ("Main Color", Vector) = (1,1,1,1)
		_Center ("Shine center", Float) = 0
		_Scale ("Scale", Float) = 0
	}
	SubShader {
		LOD 100
		Tags { "IGNOREPROJECTOR" = "true" "QUEUE" = "Transparent" "RenderType" = "Transparent" }
		Pass {
			LOD 100
			Tags { "IGNOREPROJECTOR" = "true" "QUEUE" = "Transparent" "RenderType" = "Transparent" }
			Blend SrcAlpha OneMinusSrcAlpha
			ZWrite Off
			Cull Off
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
			struct appdata {
				float4 vertex : POSITION;
				float2 texcoord : TEXCOORD0;
			};
			struct v2f {
				float4 vertex : SV_POSITION;
				float2 texcoord0 : TEXCOORD0;
				float2 texcoord1 : TEXCOORD1;
			};
			float4 projectionParams : _ProjectionParams;
			float4 _MainTex_ST;
			v2f vert(appdata v)
			{
				v2f o;
				float4 var = UnityObjectToClipPos(v.vertex);
				float4 var2 = var * 0.5;
				o.vertex = var;
				o.texcoord0 = TRANSFORM_TEX(v.texcoord, _MainTex);
				o.texcoord1 = float2(var2.x, var2.y * _ProjectionParams.x) + var2.w;
				return o;
			}
			sampler2D _MainTex;
			fixed4 _Color;
			fixed _Center;
			fixed _Scale;
			fixed4 frag(v2f i) : SV_Target
			{
				fixed4 var = tex2D (_MainTex, i.texcoord0);
				fixed var2 = 1.0 - abs((i.texcoord1.x - _Center) * _Scale);
				return var + clamp(var2, 0.0, 1.0) * _Color * var.w;
			}
			ENDCG
		}
	}
}