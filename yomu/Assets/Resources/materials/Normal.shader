




Shader "Normal"
{
    Properties
    {
        [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
         _Color ("Tint", Color) = (1,1,1,1)
     
        _Alpha ("alpha" , float) = 0
       
        [MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
		//_BlurSize("Blur Size", Range(0.0, 0.1)) = 0.03
        _BlurSize("Blur Size", float ) = 0.001
		_GrayscaleAmount ("Grayscale Amount", float) = 0.3
         

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
            "Queue"="Overlay"
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
            
            Stencil
            {
                Ref [_Stencil]
                Comp [_StencilComp]
                Pass [_StencilOp]
                ReadMask [_StencilReadMask]
                WriteMask [_StencilWriteMask]
            }
             
            CGPROGRAM
                    #pragma vertex vert
                    #pragma fragment frag
                    //#pragma multi_compile DUMMY PIXELSNAP_ON
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
                    float _Alpha;
                            
                    fixed4 frag(v2f IN) : SV_Target
                        {

                            fixed4 cor_atual = IN.color;
                            fixed4 imagem_real = tex2D(_MainTex , IN.texcoord);
                            
                            return  fixed4  ( 
                                                imagem_real[ 0 ] * cor_atual[ 0 ] * _Color[ 0 ] ,
                                                imagem_real[ 1 ] * cor_atual[ 1 ] * _Color[ 1 ] ,
                                                imagem_real[ 2 ] * cor_atual[ 2 ] * _Color[ 2 ] ,
                                                imagem_real[ 3 ] * cor_atual[ 3 ] * _Color[ 3 ] 
                                            );

                    
                    
                        }

                ENDCG
        }
    }
    Fallback "Sprites/Default"
}