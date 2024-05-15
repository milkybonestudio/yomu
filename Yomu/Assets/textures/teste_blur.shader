


// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "blur"
{
	Properties
	{
		[PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
		_Color ("Tint", Color) = (1,1,1,1)
		[MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
		_BlurSize("Blur Size", Range(0.0, 0.1)) = 0.05
	}

	SubShader
	{
		Tags
		{ 
			"Queue"="Transparent" 
			"IgnoreProjector"="True" 
			"RenderType"="Transparent" 
			"PreviewType"="Plane"
			"CanUseSpriteAtlas"="True"
		}

		Cull Off
		Lighting Off
		ZWrite Off
		Blend One OneMinusSrcAlpha

		Pass
		{
		CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile _ PIXELSNAP_ON
			#include "UnityCG.cginc"
			
			struct appdata_t
			{
				float4 vertex   : POSITION;
				float4 color    : COLOR;
				float2 texcoord : TEXCOORD0;
			};

			struct v2f
			{
				float4 vertex   : SV_POSITION;
				fixed4 color    : COLOR;
				float2 uv  : TEXCOORD0;
			};
			
			fixed4 _Color;

			v2f vert(appdata_t IN)
			{
				v2f OUT;
				OUT.vertex = UnityObjectToClipPos(IN.vertex);
				OUT.uv = IN.texcoord;
				OUT.color = IN.color * _Color;
				#ifdef PIXELSNAP_ON
				OUT.vertex = UnityPixelSnap (OUT.vertex);
				#endif

				return OUT;
			}

			sampler2D _MainTex;
			sampler2D _AlphaTex;
			float _AlphaSplitEnabled;

			uniform float _BlurSize;

			fixed4 SampleSpriteTexture (float2 uv)
			{
				fixed4 color = tex2D (_MainTex, uv);

#if UNITY_TEXTURE_ALPHASPLIT_ALLOWED
				if (_AlphaSplitEnabled)
					color.a = tex2D (_AlphaTex, uv).r;
#endif //UNITY_TEXTURE_ALPHASPLIT_ALLOWED

				return color;
			}

			fixed4 frag(v2f i) : SV_Target
			{
				//fixed4 c = SampleSpriteTexture (IN.texcoord) * IN.color;
				//c.rgb *= c.a;
				//return c;



				fixed4 sum = fixed4(0.0, 0.0, 0.0, 0.0);
				sum += tex2D(_MainTex, half2(i.uv.x, i.uv.y - 4.0 * _BlurSize)) * 0.05;
				sum += tex2D(_MainTex, half2(i.uv.x, i.uv.y - 3.0 * _BlurSize)) * 0.09;
				sum += tex2D(_MainTex, half2(i.uv.x, i.uv.y - 2.0 * _BlurSize)) * 0.12;
				sum += tex2D(_MainTex, half2(i.uv.x, i.uv.y - _BlurSize)) * 0.15;
				sum += tex2D(_MainTex, half2(i.uv.x, i.uv.y)) * 0.16;
				sum += tex2D(_MainTex, half2(i.uv.x, i.uv.y + _BlurSize)) * 0.15;
				sum += tex2D(_MainTex, half2(i.uv.x, i.uv.y + 2.0 * _BlurSize)) * 0.12;
				sum += tex2D(_MainTex, half2(i.uv.x, i.uv.y + 3.0 * _BlurSize)) * 0.09;
				sum += tex2D(_MainTex, half2(i.uv.x, i.uv.y + 4.0 * _BlurSize)) * 0.05;

#if UNITY_TEXTURE_ALPHASPLIT_ALLOWED
				if (_AlphaSplitEnabled)
					sum.a = tex2D(_AlphaTex, i.uv).r;
#endif //UNITY_TEXTURE_ALPHASPLIT_ALLOWED

				return sum;
			}
		ENDCG
		}
	}
}



// // Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader "teste"
// {
//     Properties
//     {
//         [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
//         _Color ("Tint", Color) = (1,1,1,1)
//         [MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
        
//     }
 
//     SubShader
//     {
//         Tags
//         {
//             "Queue"="Transparent"
//             "IgnoreProjector"="True"
//             "RenderType"="Transparent"
//             "PreviewType"="Plane"
//             "CanUseSpriteAtlas"="True"
//         }
 
//         Cull Off
//         Lighting Off
//         ZWrite Off
        
//         Blend One OneMinusSrcAlpha
 
//         Pass
//         {
//         CGPROGRAM
//             #pragma vertex vert
//             #pragma fragment frag
//             //#pragma multi_compile DUMMY PIXELSNAP_ON
//             #pragma multi_compile _ PIXELSNAP_ON
//             #include "UnityCG.cginc"
           
//             struct appdata_t
//             {
//                 float4 vertex   : POSITION;
//                 float4 color    : COLOR;
//                 float2 texcoord : TEXCOORD0;
//             };
 
//             struct v2f
//             {
//                 float4 vertex   : SV_POSITION;
//                 fixed4 color    : COLOR;
//                 half2 texcoord  : TEXCOORD0;
//             };
           
//             fixed4 _Color;
 
//             v2f vert(appdata_t IN)
//             {
//                 v2f OUT;
//                 OUT.vertex = UnityObjectToClipPos(IN.vertex);
//                 OUT.texcoord = IN.texcoord;
//                 OUT.color = IN.color * _Color;

//                 #ifdef PIXELSNAP_ON
//                 OUT.vertex = UnityPixelSnap (OUT.vertex);
//                 #endif
 
//                 return OUT;
//             }
 
//             sampler2D _MainTex;
//             sampler2D _AlphaTex;
//             //uniform float _GrayscaleAmount;
//             float _AlphaSplitEnabled = 1;
//             uniform float _BlurSize = 0.05;



//              //testar
//         //  fixed4 SampleSpriteTexture (float2 _possition)
// 		// 	{
// 		// 		fixed4 color = tex2D (_MainTex, _possition);

//         //     #if UNITY_TEXTURE_ALPHASPLIT_ALLOWED
// 		// 		if (_AlphaSplitEnabled)
// 		// 			color.a = tex2D (_AlphaTex, _possition).r;
//         //      #endif //UNITY_TEXTURE_ALPHASPLIT_ALLOWED

// 		// 		return color;
// 		// 	}

           

 
//             fixed4 frag(v2f IN) : SV_Target
//             {

 
               

//                 //    //  * _BlurSize
//                 // fixed4 sum = fixed4(0.0, 0.0, 0.0, 0.0);
// 				// sum += tex2D(_MainTex, half2(IN.texcoord.x  -  1  * _BlurSize ,  IN.texcoord.y    +  1  * _BlurSize  )) * 0.05;
// 				// sum += tex2D(_MainTex, half2(IN.texcoord.x                    ,  IN.texcoord.y    +  1  * _BlurSize )) * 0.09;
// 				// sum += tex2D(_MainTex, half2(IN.texcoord.x  +  1  * _BlurSize ,  IN.texcoord.y    +  1  * _BlurSize  )) * 0.12;
// 				// sum += tex2D(_MainTex, half2(IN.texcoord.x  -  1  * _BlurSize ,  IN.texcoord.y        )) * 0.15;
// 				// sum += tex2D(_MainTex, half2(IN.texcoord.x  +       _BlurSize ,  IN.texcoord.y                 )) * 0.17;
// 				// sum += tex2D(_MainTex, half2(IN.texcoord.x  +  1  * _BlurSize ,  IN.texcoord.y        )) * 0.15;
// 				// sum += tex2D(_MainTex, half2(IN.texcoord.x  -  1  * _BlurSize ,  IN.texcoord.y    - 1  * _BlurSize  )) * 0.12;
// 				// sum += tex2D(_MainTex, half2(IN.texcoord.x                    ,  IN.texcoord.y    - 1  * _BlurSize  )) * 0.09;
// 				// sum += tex2D(_MainTex, half2(IN.texcoord.x  +  1  * _BlurSize ,  IN.texcoord.y    - 1  * _BlurSize  )) * 0.05;

//             //    // _BlurSize
//             //     fixed4 sum = fixed4(0.0, 0.0, 0.0, 0.0);
// 			// 	sum += tex2D(_MainTex, half2(IN.texcoord.x  -  1  ,  IN.texcoord.y + 1 )) * 0.05;
// 			// 	sum += tex2D(_MainTex, half2(IN.texcoord.x        ,  IN.texcoord.y + 1)) * 0.09;
// 			// 	sum += tex2D(_MainTex, half2(IN.texcoord.x  +  1  ,  IN.texcoord.y + 1 )) * 0.12;
// 			// 	sum += tex2D(_MainTex, half2(IN.texcoord.x  -  1  ,  IN.texcoord.y   )) * 0.15;
// 			// 	sum += tex2D(_MainTex, half2(IN.texcoord.x        ,  IN.texcoord.y   )) * 0.16;
// 			// 	sum += tex2D(_MainTex, half2(IN.texcoord.x  +  1  ,  IN.texcoord.y   )) * 0.15;
// 			// 	sum += tex2D(_MainTex, half2(IN.texcoord.x  -  1  ,  IN.texcoord.y - 1 )) * 0.12;
// 			// 	sum += tex2D(_MainTex, half2(IN.texcoord.x        ,  IN.texcoord.y - 1 )) * 0.09;
// 			// 	sum += tex2D(_MainTex, half2(IN.texcoord.x  +  1  ,  IN.texcoord.y - 1 )) * 0.05;



//             fixed4 sum = fixed4(0.0, 0.0, 0.0, 0.0);
// 				sum += tex2D(_MainTex, half2(IN.texcoord.x  -  1  ,  IN.texcoord.y + 1 )) ;
// 				sum += tex2D(_MainTex, half2(IN.texcoord.x        ,  IN.texcoord.y + 1)) ;
// 				sum += tex2D(_MainTex, half2(IN.texcoord.x  +  1  ,  IN.texcoord.y + 1 )) ;
// 				sum += tex2D(_MainTex, half2(IN.texcoord.x  -  1  ,  IN.texcoord.y   )) ;
// 				sum += tex2D(_MainTex, half2(IN.texcoord.x        ,  IN.texcoord.y   )) ;
// 				sum += tex2D(_MainTex, half2(IN.texcoord.x  +  1  ,  IN.texcoord.y   )) ;
// 				sum += tex2D(_MainTex, half2(IN.texcoord.x  -  1  ,  IN.texcoord.y - 1 )) ;
// 				sum += tex2D(_MainTex, half2(IN.texcoord.x        ,  IN.texcoord.y - 1 )) ;
// 				sum += tex2D(_MainTex, half2(IN.texcoord.x  +  1  ,  IN.texcoord.y - 1 )) ;

//                 sum /= 9;




//                 // fixed4 sum = fixed4(0.0, 0.0, 0.0, 0.0);
// 				// sum += tex2D(_MainTex, half2(IN.texcoord.x, IN.texcoord.y - 4.0 * _BlurSize)) * 0.05;
// 				// sum += tex2D(_MainTex, half2(IN.texcoord.x, IN.texcoord.y - 3.0 * _BlurSize)) * 0.09;
// 				// sum += tex2D(_MainTex, half2(IN.texcoord.x, IN.texcoord.y - 2.0 * _BlurSize)) * 0.12;
// 				// sum += tex2D(_MainTex, half2(IN.texcoord.x, IN.texcoord.y - _BlurSize)) * 0.15;
// 				// sum += tex2D(_MainTex, half2(IN.texcoord.x, IN.texcoord.y)) * 0.16;
// 				// sum += tex2D(_MainTex, half2(IN.texcoord.x, IN.texcoord.y + _BlurSize)) * 0.15;
// 				// sum += tex2D(_MainTex, half2(IN.texcoord.x, IN.texcoord.y + 2.0 * _BlurSize)) * 0.12;
// 				// sum += tex2D(_MainTex, half2(IN.texcoord.x, IN.texcoord.y + 3.0 * _BlurSize)) * 0.09;
// 				// sum += tex2D(_MainTex, half2(IN.texcoord.x, IN.texcoord.y + 4.0 * _BlurSize)) * 0.05;





//                 // fixed4 sum = fixed4(0.0, 0.0, 0.0, 0.0);
// 				// sum += tex2D(_MainTex, half2(IN.texcoord.x, IN.texcoord.y - 4.0 * _BlurSize));
// 				// sum += tex2D(_MainTex, half2(IN.texcoord.x, IN.texcoord.y - 3.0 * _BlurSize));
// 				// sum += tex2D(_MainTex, half2(IN.texcoord.x, IN.texcoord.y - 2.0 * _BlurSize));
// 				// sum += tex2D(_MainTex, half2(IN.texcoord.x, IN.texcoord.y - _BlurSize));
// 				// sum += tex2D(_MainTex, half2(IN.texcoord.x, IN.texcoord.y));
// 				// sum += tex2D(_MainTex, half2(IN.texcoord.x, IN.texcoord.y + _BlurSize));
// 				// sum += tex2D(_MainTex, half2(IN.texcoord.x, IN.texcoord.y + 2.0 * _BlurSize));
// 				// sum += tex2D(_MainTex, half2(IN.texcoord.x, IN.texcoord.y + 3.0 * _BlurSize));
// 				// sum += tex2D(_MainTex, half2(IN.texcoord.x, IN.texcoord.y + 4.0 * _BlurSize));

//                 // sum /= 9;
                
//                  //sum = fixed4(0.0, 0.0, 0.0, 0.5);




//            //     sum = float4(0.8, 0.59, 0.11, 1);

// #if UNITY_TEXTURE_ALPHASPLIT_ALLOWED
// 				if (_AlphaSplitEnabled)
// 					sum.a = tex2D(_AlphaTex, IN.texcoord).r;
// #endif //UNITY_TEXTURE_ALPHASPLIT_ALLOWED

// 				return sum;

       
//             //     half4 texcol = tex2D (_MainTex, IN.texcoord);   


//             //     half4 texcol_1 = tex2D (_MainTex, IN.texcoord + 1);


//             //     if( texcol.rgb[0] > texcol_1.rgb[0]   ) {

//             //             texcol.rgb = lerp(texcol.rgb, dot(texcol.rgb, float3(0.3, 0.59, 0.11)), _GrayscaleAmount);

//             //     }

//             //    // texcol.rgb = float4(0.5, 0.59, 0.11, 0.4);



//             //     texcol = texcol * IN.color;
//             //     return texcol;
//             }
//         ENDCG
//         }
//     }
//     Fallback "Sprites/Default"
// }