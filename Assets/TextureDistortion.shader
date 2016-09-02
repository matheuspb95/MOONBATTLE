Shader "Hidden/CRTDiffuse" {
	Properties{
		_MainTex("Main Text", 2D) = "white" {}
		_DisplacementTex("Disp texture", 2D) = "white" {}
		_Strength("Strenght", Float) = 0
		_SquareSize("Size", Float) = 0
	}
		SubShader{
			Pass{
			CGPROGRAM
				#pragma vertex vert_img
				#pragma fragment frag
				#include "UnityCG.cginc"

				uniform sampler2D _MainTex;
				fixed _Strength;
				fixed _SquareSize;
				int _offSet;
				uniform sampler2D _DisplacementTex;

				float4 frag(v2f_img i) : COLOR{
					half2 n = tex2D(_DisplacementTex, i.uv * _SquareSize);
					half2 d = n * 2 - 1;
					i.uv += d * _Strength;
					i.uv = saturate(i.uv);

					float4 c = tex2D(_MainTex, i.uv);
					return c;
				}
			ENDCG
		}
	}
}