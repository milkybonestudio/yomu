


public static class Rectangle {


    public static bool Check_point_inside( float x, float y, float x_rect_min,  float x_rect_max   ,float y_rect_min,  float y_rect_max  ){

          return  !!!(  x  <  x_rect_min    ||  x > x_rect_max   ||   y < y_rect_min   ||  y> y_rect_max  );

     }


}