Shader "e2d/Fill" {
	Properties {
		_Color ("Main Color", Color) = (1,1,1,1)
		_MainTex ("Base (RGB)", 2D) = "white" {}
	}
	SubShader { 
		LOD 100
		Tags { "QUEUE"="Transparent" "IGNOREPROJECTOR"="True" "RenderType"="Opaque" }
		Pass {
			Tags { "QUEUE"="Transparent" "IGNOREPROJECTOR"="True" "RenderType"="Opaque" }
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
				float2 texcoord : TEXCOORD0;
			};
			float4 _MainTex_ST;
			v2f vert(appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
				return o;
			}
			sampler2D _MainTex;
			fixed4 _Color;
			fixed4 frag(v2f i) : SV_Target
			{
				return tex2D(_MainTex, i.texcoord) * _Color;
			}
			ENDCG
		}
	}
}