

using UnityEngine;


public struct Yomu_version {

    public byte EDITION;
    public byte MINOR;
    public byte PATH;

    public static bool Is_the_same( Yomu_version _version_1, Yomu_version _version_2 ){

        bool is_equal = true;

        if( _version_1.EDITION != _version_2.EDITION )
            { is_equal = false; }

        if( _version_1.MINOR != _version_2.MINOR )
            { is_equal = false; }

        if( _version_1.PATH != _version_2.PATH )
            { is_equal = false; }

        return is_equal;

    }

    public static string Get_name( Yomu_version _version ){

        return $"version_{ _version.EDITION }.{ _version.MINOR }.{ _version.PATH }";

    }

    public string Get_name(){

        return $"version_{ EDITION }.{ MINOR }.{ PATH }";

    }


}