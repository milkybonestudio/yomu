




// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "desfoco"
{
    Properties
    {
        [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
         _Color ("Tint", Color) = (1,1,1,1)
     
      
       
        [MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
		 _BlurSize("Blur Size", Float) = 0.0010
		_GrayscaleAmount ("Grayscale Amount", Float) = 0.3
         



         _Stencil ("Stencil Ref", Float) = 0



         _StencilComp ("Stencil Comparison", Float) = 8

_StencilOp ("Stencil Operation", Float) = 0
_StencilWriteMask ("Stencil Write Mask", Float) = 255
_StencilReadMask ("Stencil Read Mask", Float) = 255
_ColorMask ("Color Mask", Float) = 0.4

      
                 

        
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
        
       Blend SrcAlpha OneMinusSrcAlpha

        
    
        Pass
        {
        CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile DUMMY PIXELSNAP_ON
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
                half2 texcoord  : TEXCOORD0;
            };
           
            fixed4 _Color;
 
            v2f vert(appdata_t IN)
            {
                v2f OUT;
                OUT.vertex = UnityObjectToClipPos(IN.vertex);
                OUT.texcoord = IN.texcoord;
                OUT.color = IN.color * _Color;

                #ifdef PIXELSNAP_ON
                OUT.vertex = UnityPixelSnap (OUT.vertex);
                #endif
 
                return OUT;
            }
 
            sampler2D _MainTex;
            sampler2D _AlphaTex;
            //uniform float _GrayscaleAmount;
            float _AlphaSplitEnabled;
            uniform float _BlurSize ;
			uniform float _GrayscaleAmount;
           
            



        
           

 
            fixed4 frag(v2f IN) : SV_Target
            {

               fixed4 sum = tex2D(_MainTex , IN.texcoord);
              


               if(_BlurSize != 0){

                sum = fixed4(0.0, 0.0, 0.0, 0.0);

                sum += tex2D(_MainTex, half2(IN.texcoord.x  -  1  * _BlurSize ,  IN.texcoord.y    +  1  * _BlurSize )) * 0.05;
				sum += tex2D(_MainTex, half2(IN.texcoord.x                    ,  IN.texcoord.y    +  1  * _BlurSize )) * 0.09;
				sum += tex2D(_MainTex, half2(IN.texcoord.x  +  1  * _BlurSize ,  IN.texcoord.y    +  1  * _BlurSize )) * 0.12;
				sum += tex2D(_MainTex, half2(IN.texcoord.x  -  1  * _BlurSize ,  IN.texcoord.y                      )) * 0.15;
				sum += tex2D(_MainTex, half2(IN.texcoord.x  +       _BlurSize ,  IN.texcoord.y                      )) * 0.18;
				sum += tex2D(_MainTex, half2(IN.texcoord.x  +  1  * _BlurSize ,  IN.texcoord.y                      )) * 0.15;
				sum += tex2D(_MainTex, half2(IN.texcoord.x  -  1  * _BlurSize ,  IN.texcoord.y    - 1  * _BlurSize  )) * 0.12;
				sum += tex2D(_MainTex, half2(IN.texcoord.x                    ,  IN.texcoord.y    - 1  * _BlurSize  )) * 0.09;
				sum += tex2D(_MainTex, half2(IN.texcoord.x  +  1  * _BlurSize ,  IN.texcoord.y    - 1  * _BlurSize  )) * 0.05;

                // estava deixando meio branco, essa parte escurece um pouco para balancear 
                //sum -= fixed4(0.007,0.007,0.007,0);
                

          
               #if UNITY_TEXTURE_ALPHASPLIT_ALLOWED
			   if (_AlphaSplitEnabled)
					//sum.a = tex2D(_AlphaTex, IN.texcoord).r;
                #endif //UNITY_TEXTURE_ALPHASPLIT_ALLOWED

               }


               if(_GrayscaleAmount>0){
                  
                  sum.rgb = lerp(sum.rgb, dot(sum.rgb, float3(0.3, 0.59, 0.11)), _GrayscaleAmount);
                  sum = sum * IN.color;


               }

              
				

                // sum *= float4(1,1,1,0);

               


                

                
                

				return sum;

       
          
            }
        ENDCG
        }
    }
    Fallback "Sprites/Default"
}