Shader "_Custom/DailyChallengeMask" {
	Properties {
		_MainTex ("Texture", 2D) = "black" {}
		_Mask ("Mask", 2D) = "white" {}
		_Layer ("Layer", 2D) = "white" {}
		_Grayness ("Grayness", Range(0, 1)) = 0
	}
	SubShader {
		LOD 100
		Tags { "IGNOREPROJECTOR" = "true" "RenderType" = "Transparent" }
		Pass {
			LOD 100
			Tags { "IGNOREPROJECTOR" = "true" "RenderType" = "Transparent" }
			Blend SrcAlpha OneMinusSrcAlpha
			ZWrite Off
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
			sampler2D _Mask;
			sampler2D _Layer;
			float _Grayness;
			fixed4 frag(v2f i) : SV_Target
			{
				fixed4 var = tex2D(_MainTex, i.texcoord);
				fixed4 var2 = tex2D(_Layer, i.texcoord);
				fixed var3 = 0.2989 * var.x + 0.587 * var.y + 0.114 * var.z;
				fixed4 var4;
				var4.xyz = var.xyz * (1 - _Grayness) + fixed3(var3, var3, var3) * _Grayness;
				var4.w = tex2D(_Mask, i.texcoord).w;
				fixed4 var5;
				var5.xyz = var4.xyz * (1 - var2.w) + var2.xyz * var2.w;
				var5.w = max(var4.w, var2.w);
				return var5;
			}
			ENDCG
		}
	}
}