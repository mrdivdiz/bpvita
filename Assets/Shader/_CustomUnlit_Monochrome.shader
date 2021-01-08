Shader "_Custom/Unlit_Monochrome" {
	Properties {
		_Color ("Main Color", Vector) = (1,1,1,1)
	}
	SubShader {
		LOD 100
		Tags { "IGNOREPROJECTOR" = "true" "QUEUE" = "Transparent" "RenderType" = "Opaque" }
		Pass {
			LOD 100
			Tags { "IGNOREPROJECTOR" = "true" "QUEUE" = "Transparent" "RenderType" = "Opaque" }
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
            };
            struct v2f {
                float4 vertex : SV_POSITION;
            };
			float4 _MainTex_ST;
            v2f vert(appdata v)
            {
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
                return o;
            }
			sampler2D _MainTex;
			fixed4 _Color;
			fixed4 frag(v2f i) : SV_Target
			{
				return _Color;
            }
			ENDCG
		}
	}
}