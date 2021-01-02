Shader "Depth Mask/MaskOverlay" {
	Properties {
		_Color ("Main Color", Vector) = (1,1,1,1)
		_MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
	}
	SubShader {
		LOD 100
		Tags { "IGNOREPROJECTOR" = "true" "QUEUE" = "Transparent" "RenderType" = "Transparent" }
		Pass {
			LOD 100
			Tags { "IGNOREPROJECTOR" = "true" "LIGHTMODE" = "Vertex" "QUEUE" = "Transparent" "RenderType" = "Transparent" }
			Blend SrcAlpha OneMinusSrcAlpha, SrcAlpha OneMinusSrcAlpha
			ZWrite Off
			Fog {
				Mode Off
			}
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
            #include "UnityCG.cginc"
            struct appdata {
                float4 vertex : POSITION;
				float3 normal : NORMAL;
                float2 texcoord : TEXCOORD0;
            };
            struct v2f {
                float4 vertex : SV_POSITION;
                float2 texcoord : TEXCOORD0;
				fixed4 color : COLOR;
            };
			float4 _MainTex_ST;
			fixed4 _Color;
            v2f vert(appdata v)
            {
				float4x4 var = (unity_WorldToObject * unity_MatrixInvV);
				float3x3 var2;
				var2[0] = float4(var[0].x, var[1].x, var[2].x, var[3].x);
				var2[1] = float4(var[0].y, var[1].y, var[2].y, var[3].y);
				var2[2] = float4(var[0].z, var[1].z, var[2].z, var[3].z);
				half3 eyeNormal = normalize(mul(var2, v.normal));
				half3 var3 = (_Color.xyz * glstate_lightmodel_ambient.xyz);
				for (int i = 0; i < 8; i++)
				{
					half3 dirToLight = unity_LightPosition[i].xyz;
					var3 = (var3 + min((
						((max(dot(eyeNormal, dirToLight), 0.0) * _Color.xyz) * unity_LightColor[i].xyz)
						* 0.5), half3(1.0, 1.0, 1.0)));
				}
				half4 var4;
				var4.xyz = var3;
				var4.w = _Color.w;
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
				o.color = clamp(var4, 0.0, 1.0);
				return o;
            }
			sampler2D _MainTex;
			fixed4 frag(v2f i) : SV_Target
			{
				fixed4 var = tex2D(_MainTex, i.texcoord);
				fixed4 var2;
				var2.xyz = (var * i.color * 2.0).xyz;
				var2.w = (var.w * i.color.w);
				return var2;
            }
			ENDCG
		}
	}
}