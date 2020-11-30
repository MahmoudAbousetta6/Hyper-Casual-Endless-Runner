Shader "Blend/BendWorld"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_NormalMap ("NormalMap", 2D) = "bump" {}
		_Curvature("Curvature",float) = 0.001
		[HDR] _Color("Color", Color) = (1,1,1,1)		
		_BumpMap ("Bumpmap", 2D) = "bump" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5


	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 200

		CGPROGRAM
		#pragma surface surf Standard vertex:vert addshadow

		uniform sampler2D _MainTex;
		uniform float _Curvature;
		sampler2D _BumpMap;
		fixed4 _Color;
		half _Glossiness;

		struct Input{

			float2 uv_MainTex;			
			float2 uv_BumpMap;
		};

		void vert(inout appdata_full v){

		float4 worldSpace = mul(unity_ObjectToWorld, v.vertex);
		worldSpace.xyz -= _WorldSpaceCameraPos.xyz;
		worldSpace = float4(0.0f,(worldSpace.z * worldSpace.z) * -_Curvature, 0.0f, 0.0f);
		v.vertex += mul(unity_WorldToObject, worldSpace);
		}

		void surf(Input IN, inout SurfaceOutputStandard o){
	
		half4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
		o.Albedo = c.rgb;
		o.Alpha = c.a;		
        o.Normal = UnpackNormal (tex2D (_BumpMap, IN.uv_BumpMap));
		o.Smoothness = _Glossiness;

		}

		ENDCG
	}
	FallBack "Mobile/Diffuse"
}

