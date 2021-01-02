Shader "Depth Mask/MaskOverlayNV" {
	Properties {
		_Color ("Main Color", Vector) = (1,1,1,1)
		_MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
		_Radius ("Vignetting radius", Float) = 0.7
		_Softness ("Vignetting softness", Float) = 0.3
	}
	SubShader {
		LOD 100
		Tags { "IGNOREPROJECTOR" = "true" "QUEUE" = "Transparent+10" "RenderType" = "Transparent" }
		Pass {
			LOD 100
			Tags { "IGNOREPROJECTOR" = "true" "QUEUE" = "Transparent+10" "RenderType" = "Transparent" }
			Blend SrcColor OneMinusSrcAlpha, SrcColor OneMinusSrcAlpha
			ColorMask RGB
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
				float2 texcoord : TEXCOORD0;
				float2 texcoord1 : TEXCOORD1;
			};
			float4 _MainTex_ST;
			v2f vert(appdata v)
			{
				float4 var = UnityObjectToClipPos(v.vertex);
				float4 var2 = (var * 0.5);
				float2 var3;
				var3.x = var2.x;
				var3.y = (var2.y * _ProjectionParams.x);
				v2f o;
				o.vertex = var;
				o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
				o.texcoord1 = (var3 + var2.w);
				return o;
			}
			sampler2D _MainTex;
			fixed4 _Color;
			float _Radius;
			float _Softness;
			fixed4 frag(v2f i) : SV_Target
			{
				fixed4 var = (tex2D(_MainTex, i.texcoord) * _Color);
				float2 var2 = (i.texcoord1 - 0.5);
				float var3 = clamp(((
				sqrt(dot(var2, var2))
				- _Radius) / (
				(_Radius - _Softness)
				- _Radius)), 0.0, 1.0);
				float3 var4 = lerp(var.xyz, (var.xyz * (var3 *
				(var3 * (3.0 - (2.0 * var3)))
				)), float3(0.5, 0.5, 0.5));
				fixed4 var5;
				var5.w = var.w;
				var5.xyz = var4;
				return var5;
			}
			ENDCG
		}
	}
}