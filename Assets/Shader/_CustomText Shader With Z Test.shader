Shader "_Custom/Text Shader With Z Test" {
	Properties {
		_MainTex ("Font Texture", 2D) = "white" {}
		_Color ("Text Color", Vector) = (1,1,1,1)
	}
	SubShader {
		Tags { "IGNOREPROJECTOR" = "true" "QUEUE" = "Transparent" "RenderType" = "Transparent" }
		Pass {
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
				float4 vertex : POSITION;
				float2 texcoord : TEXCOORD0;
			};
			struct v2f {
				fixed4 color : COLOR;
				float4 vertex : SV_POSITION;
				float2 texcoord : TEXCOORD0;
			};
			fixed4 _Color;
			float4 _MainTex_ST;
			v2f vert(appdata v)
			{
				v2f o;
				o.color = clamp(_Color, 0.0, 1.0);
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
				return o;
			}
			sampler2D _MainTex;
			fixed4 frag(v2f i) : SV_Target
			{
				fixed4 var;
				var.xyz = i.color.xyz;
				var.w = tex2D(_MainTex, i.texcoord).w * i.color.w;
				return var;
			}
			ENDCG
		}
	}
}