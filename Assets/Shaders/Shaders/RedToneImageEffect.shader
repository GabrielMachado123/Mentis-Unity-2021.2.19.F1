Shader "MyShaders/DamageFeedback"{
	Properties{

		_MainTex("TEXTURE",2D) = "white"{}
	    _DisplaceTex("Displacement Texture", 2D) = "White" {}
		_Magnitude("Magnitude", Range(0,0.1)) = 1
	}



	SubShader{
		Cull Off
		ZWrite Off
		ZTest Always
		Pass{
			HLSLPROGRAM
			//first handle vertex, result from vertex process goes to fragment, result of the fragment goes to screen
			#pragma vertex MyVertexProgram
			#pragma fragment MyFragmentProgram
			#include "UnityCG.cginc"

			struct VertexData {
				float4 position : POSITION;
				float2 uv : TEXCOORD0;
	
			};



			struct VertexToFragment{
					float4 position : SV_POSITION;
					float2 uv : TEXCOORD0; // extra info
				
			};

		
			sampler2D _MainTex;
			sampler2D _DisplaceTex;
			float _Magnitude;

			float4 _MainTex_ST;		
			
			// 					MEANING OF VERTEX  :   MEANING OF RESULT, SCREEN POSITION OF VERTEX
			VertexToFragment MyVertexProgram(VertexData vertex) 
			{
				VertexToFragment res;
				res.position = UnityObjectToClipPos(vertex.position);
				res.uv = vertex.uv * _MainTex_ST.xy + _MainTex_ST.zw;

				return res;
			}



			float4 MyFragmentProgram(VertexToFragment V2F) : SV_TARGET
			{
				float2 disp = tex2D(_DisplaceTex, V2F.uv).xy;
				disp = ((disp * 2) - 1) * _Magnitude;


				float4 color = tex2D(_MainTex,V2F.uv + disp);

				return color * float4(1,0,0,1);
			}

			ENDHLSL
		}


	}



}
