// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "MoonSurface"
{
	Properties
	{
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" "IsEmissive" = "true"  }
		Cull Back
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#pragma target 3.0
		#pragma surface surf Unlit keepalpha addshadow fullforwardshadows noambient novertexlights nolightmap  nodynlightmap nodirlightmap 
		struct Input
		{
			float2 uv_texcoord;
			float3 worldPos;
		};


		//https://www.shadertoy.com/view/XdXGW8
		float2 GradientNoiseDir( float2 x )
		{
			const float2 k = float2( 0.3183099, 0.3678794 );
			x = x * k + k.yx;
			return -1.0 + 2.0 * frac( 16.0 * k * frac( x.x * x.y * ( x.x + x.y ) ) );
		}
		
		float GradientNoise( float2 UV, float Scale )
		{
			float2 p = UV * Scale;
			float2 i = floor( p );
			float2 f = frac( p );
			float2 u = f * f * ( 3.0 - 2.0 * f );
			return lerp( lerp( dot( GradientNoiseDir( i + float2( 0.0, 0.0 ) ), f - float2( 0.0, 0.0 ) ),
					dot( GradientNoiseDir( i + float2( 1.0, 0.0 ) ), f - float2( 1.0, 0.0 ) ), u.x ),
					lerp( dot( GradientNoiseDir( i + float2( 0.0, 1.0 ) ), f - float2( 0.0, 1.0 ) ),
					dot( GradientNoiseDir( i + float2( 1.0, 1.0 ) ), f - float2( 1.0, 1.0 ) ), u.x ), u.y );
		}


		inline half4 LightingUnlit( SurfaceOutput s, half3 lightDir, half atten )
		{
			return half4 ( 0, 0, 0, s.Alpha );
		}

		void surf( Input i , inout SurfaceOutput o )
		{
			half gradientNoise16 = GradientNoise(i.uv_texcoord,50.0);
			gradientNoise16 = gradientNoise16*0.5 + 0.5;
			half gradientNoise12 = GradientNoise(i.uv_texcoord,200.0);
			gradientNoise12 = gradientNoise12*0.5 + 0.5;
			half gradientNoise18 = GradientNoise(i.uv_texcoord,500.0);
			gradientNoise18 = gradientNoise18*0.5 + 0.5;
			half4 color1 = IsGammaSpace() ? half4(0.277,0.277,0.277,1) : half4(0.06236279,0.06236279,0.06236279,1);
			half4 color7 = IsGammaSpace() ? half4(0.1320755,0.1320755,0.1320755,1) : half4(0.01574109,0.01574109,0.01574109,1);
			float3 ase_vertex3Pos = mul( unity_WorldToObject, float4( i.worldPos , 1 ) );
			half4 lerpResult3 = lerp( color1 , color7 , ( ase_vertex3Pos.z * 25.0 ));
			o.Emission = ( ( ( gradientNoise16 + gradientNoise12 + gradientNoise18 ) * 0.1 ) + lerpResult3 ).rgb;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18933
1557;226;1663;663;838.6777;676.1045;1;True;True
Node;AmplifyShaderEditor.TexCoordVertexDataNode;11;-838.4536,-537.7656;Inherit;False;0;2;0;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.NoiseGeneratorNode;12;-607.4536,-542.7656;Inherit;False;Gradient;True;False;2;0;FLOAT2;0,0;False;1;FLOAT;200;False;1;FLOAT;0
Node;AmplifyShaderEditor.NoiseGeneratorNode;16;-611.4536,-644.7656;Inherit;False;Gradient;True;False;2;0;FLOAT2;0,0;False;1;FLOAT;50;False;1;FLOAT;0
Node;AmplifyShaderEditor.NoiseGeneratorNode;18;-618.2245,-765.4854;Inherit;False;Gradient;True;False;2;0;FLOAT2;0,0;False;1;FLOAT;500;False;1;FLOAT;0
Node;AmplifyShaderEditor.PosVertexDataNode;2;-1124.139,-363.5928;Inherit;False;0;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;1;-955.0424,-139.8638;Inherit;False;Constant;_Base;Base;0;0;Create;True;0;0;0;False;0;False;0.277,0.277,0.277,1;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;7;-949.854,47.7345;Inherit;False;Constant;_Base2;Base2;0;0;Create;True;0;0;0;False;0;False;0.1320755,0.1320755,0.1320755,1;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;8;-733.854,-270.2655;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;25;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;17;-368.4539,-595.7656;Inherit;False;3;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;3;-427.27,-182.0665;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;15;-234.4541,-554.7656;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0.1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;14;-57.854,-224.2655;Inherit;False;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;300.6776,-347.4697;Half;False;True;-1;2;ASEMaterialInspector;0;0;Unlit;MoonSurface;False;False;False;False;True;True;True;True;True;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Opaque;0.5;True;True;0;False;Opaque;;Geometry;All;18;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;True;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;15;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;12;0;11;0
WireConnection;16;0;11;0
WireConnection;18;0;11;0
WireConnection;8;0;2;3
WireConnection;17;0;16;0
WireConnection;17;1;12;0
WireConnection;17;2;18;0
WireConnection;3;0;1;0
WireConnection;3;1;7;0
WireConnection;3;2;8;0
WireConnection;15;0;17;0
WireConnection;14;0;15;0
WireConnection;14;1;3;0
WireConnection;0;2;14;0
ASEEND*/
//CHKSM=74D31CD8F0B8FF00011A9DFF46EDFB976239916F