public enum Resource_image_content {

    not_give = 0b_0000_0000__0000_0000__0000_0000__0000_0000,

    /*pre_alloc*/ nothing = 0b_0000_0000__0000_0000__0000_0000__0000_0001, 
                  compress_low_quality_data = 0b_0000_0000__0000_0000__0000_0000__0000_0010, 
    /*pre_alloc*/ compress_data = 0b_0000_0000__0000_0000__0000_0000__0000_0100, 

                        texture = 0b_0000_0000__0000_0000__0000_0000__0000_1000, // text + data
                        texture_with_pixels = 0b_0000_0000__0000_0000__0000_0000__0001_0000,
                        texture_with_pixels_applied = 0b_0000_0000__0000_0000__0000_0000__0010_0000,

    /*pre_alloc*/ sprite = 0b_0000_0000__0000_0000__0000_0000__0100_0000,

}

