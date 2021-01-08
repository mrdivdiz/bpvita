Shader "_Custom/Unlit_Alpha8Bit_Color" {
	Properties {
		_Color ("Tint", Vector) = (1,1,1,1)
		_MainTex ("Transparency (A)", 2D) = "white" {}
	}
	SubShader {
		Tags { "IGNOREPROJECTOR" = "true" "QUEUE" = "Transparent" "RenderType" = "Opaque" }
		Pass {
			Tags { "IGNOREPROJECTOR" = "true" "QUEUE" = "Transparent" "RenderType" = "Opaque" }
			Blend SrcAlpha OneMinusSrcAlpha, SrcAlpha OneMinusSrcAlpha
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
				fixed4 var;
				var.xyz = _Color.xyz;
				var.w = (_Color.w * tex2D (_MainTex, i.texcoord).w);
				return var;
            }
			ENDCG
		}
	}
}