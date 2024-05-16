using UnityEngine;
using System.Collections;
using System;


public class Projetil {

    public static void _void(){}




    


    public int id;

    public string object_name;


    


    public bool fisica_afeta;


    public Action efeito_tempo = _void;


    
    

    public int[] dados_int_projetil;
    public float[] dados_float_projetil;
    public int[] ids_objetos_atingidos;
    public Tipo_objeto[] tipos_objetos_atingidos;



  //  [   7   ,    50007   , 100007  ]

    

    public  Fisica_objeto fisica;

    public Stats_objeto stats;
    
    public Animations_object animations;


    public GameObject projetil_game_object;



    


    public Projetil(int _id , string _name){

        object_name = _name;

        fisica = new Fisica_objeto(_id, Tipo_objeto.projetil);

        stats = new Stats_objeto(_id,  Tipo_objeto.projetil);

        animations = new Animations_object(_id, Tipo_objeto.projetil);

    

    }


    public void Colocar_world(){

        this.projetil_game_object = new GameObject( this.object_name );

        this.projetil_game_object.transform.SetParent( BLOCO_plataforma.Pegar_instancia().world.transform  ,false );

        this.projetil_game_object.transform.localPosition = new Vector3( this.fisica.position[0], this.fisica.position[1], 0f);

        // RectTransform rect =  this.projetil_game_object.AddComponent<RectTransform>();

        // rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal  ,   this.fisica.dimensions[0]);
        // rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical  ,   this.fisica.dimensions[1]);

        this.projetil_game_object.SetActive(true);

        return;

    }







}

