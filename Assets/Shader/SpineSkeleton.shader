Shader "Spine/Skeleton" {
	Properties {
		_Cutoff ("Shadow alpha cutoff", Range(0, 1)) = 0.1
		_MainTex ("Texture to blend", 2D) = "black" {}
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
			Fog {
				Mode Off
			}
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
			struct appdata {
				fixed4 color : COLOR;
				float4 vertex : POSITION;
				float2 texcoord : TEXCOORD0;
			};
			struct v2f {
				fixed4 color : COLOR;
				float4 vertex : SV_POSITION;
				float2 texcoord : TEXCOORD0;
			};
			float4 _MainTex_ST;
			v2f vert(appdata v)
			{
				v2f o;
				o.color = clamp(v.color, 0.0, 1.0);
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
				return o;
			}
			sampler2D _MainTex;
			fixed4 frag(v2f i) : SV_Target
			{
				return tex2D(_MainTex, i.texcoord) * i.color;
			}
			ENDCG
		}
	}
}