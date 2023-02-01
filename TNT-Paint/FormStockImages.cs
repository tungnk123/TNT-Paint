using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace TNT_Paint
{
    public partial class FormStockImages : Form
    {
        public List<String> imageList1 = new List<string>();
        public List<String> imageList2 = new List<string>();
        public List<String> imageList3 = new List<string>();
        public List<String> imageList4 = new List<string>();
        public List<String> imageList5 = new List<string>();
        public List<String> imageList6 = new List<string>();
        bool isLoad2 = false;
        bool isLoad3 = false;
        bool isLoad4 = false;
        bool isLoad5 = false;
        bool isLoad6 = false;
        public FormStockImages()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.instance.g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            if (listView1.SelectedItems.Count > 0)
            {
                Form1.instance.g.Clear(Color.White);
                int index = listView1.SelectedItems[0].Index;
                Image image = listView1.SelectedItems[0].ImageList.Images[index];
                Form1.instance.g.DrawImage(image, Form1.instance.pb_mainScreen.Location.X, Form1.instance.pb_mainScreen.Location.Y,
                    Form1.instance.pb_mainScreen.Width, Form1.instance.pb_mainScreen.Height);
            }
            if (listView2.SelectedItems.Count > 0)
            {
                Form1.instance.g.Clear(Color.White);
                int index = listView2.SelectedItems[0].Index;
                Image image = listView2.SelectedItems[0].ImageList.Images[index];
                Form1.instance.g.DrawImage(image, Form1.instance.pb_mainScreen.Location.X, Form1.instance.pb_mainScreen.Location.Y,
                    Form1.instance.pb_mainScreen.Width, Form1.instance.pb_mainScreen.Height);
            }
            if (listView3.SelectedItems.Count > 0)
            {
                Form1.instance.g.Clear(Color.White);
                int index = listView3.SelectedItems[0].Index;
                Image image = listView3.SelectedItems[0].ImageList.Images[index];
                Form1.instance.g.DrawImage(image, Form1.instance.pb_mainScreen.Location.X, Form1.instance.pb_mainScreen.Location.Y,
                    Form1.instance.pb_mainScreen.Width, Form1.instance.pb_mainScreen.Height);
            }
            if (listView4.SelectedItems.Count > 0)
            {
                Form1.instance.g.Clear(Color.White);
                int index = listView4.SelectedItems[0].Index;
                Image image = listView4.SelectedItems[0].ImageList.Images[index];
                Form1.instance.g.DrawImage(image, Form1.instance.pb_mainScreen.Location.X, Form1.instance.pb_mainScreen.Location.Y,
                    Form1.instance.pb_mainScreen.Width, Form1.instance.pb_mainScreen.Height);
            }
            if (listView5.SelectedItems.Count > 0)
            {
                Form1.instance.g.Clear(Color.White);
                int index = listView5.SelectedItems[0].Index;
                Image image = listView5.SelectedItems[0].ImageList.Images[index];
                Form1.instance.g.DrawImage(image, Form1.instance.pb_mainScreen.Location.X, Form1.instance.pb_mainScreen.Location.Y,
                    Form1.instance.pb_mainScreen.Width, Form1.instance.pb_mainScreen.Height);
            }
            if (listView6.SelectedItems.Count > 0)
            {
                Form1.instance.g.Clear(Color.White);
                int index = listView6.SelectedItems[0].Index;
                Image image = listView6.SelectedItems[0].ImageList.Images[index];
                Form1.instance.g.DrawImage(image, Form1.instance.pb_mainScreen.Location.X, Form1.instance.pb_mainScreen.Location.Y,
                    Form1.instance.pb_mainScreen.Width, Form1.instance.pb_mainScreen.Height);
            }
            this.Close();
        }

        private void FormStockImages_Load(object sender, EventArgs e)
        {
            imageList1.Add("https://c.pxhere.com/photos/69/87/landscape_meadow_field_mountains_switzerland_nature_green_hut-1348062.jpg!d");
            imageList1.Add("https://c.pxhere.com/photos/d8/b0/field_meadow_nature_grass_green_landscape_sky_outdoor-726395.jpg!s1");
            imageList1.Add("https://c.pxhere.com/photos/d0/42/farmland_field_soil_nature_rural_agriculture_landscape_countryside-726409.jpg!s1");
            imageList1.Add("https://c.pxhere.com/photos/c7/d6/agriculture_arable_clouds_countryside_crop_dramatic_dusk_england-733875.jpg!s1");
            imageList1.Add("https://c.pxhere.com/photos/79/e9/bale_straw_agriculture_harvest_rural_landscape_arable_land_cereals_field-1415416.jpg!s1");
            imageList1.Add("https://c.pxhere.com/photos/72/7e/panorama_landscape_nature_autumn_clouds_hill_sky_outlook-1197708.jpg!s1");
            imageList1.Add("https://c.pxhere.com/photos/f5/a8/nature_landscape_lonely_tree_field_meadow_hill_tracks-1326052.jpg!s1");
            imageList1.Add("https://c.pxhere.com/photos/e2/7a/watch_tower_structure_green_trees_observation_lookout_nature_rural-714565.jpg!s1");
            imageList1.Add("https://c.pxhere.com/photos/c3/8e/avenue_coast_dike_east_frisia_askew_windy_lane_dirt_track-1411004.jpg!s1");
            imageList1.Add("https://c.pxhere.com/photos/fe/c7/field_away_nature_landscape_lane_summer_meadow_clouds-1085573.jpg!s1");
            imageList1.Add("https://c.pxhere.com/photos/4b/62/sky_field_blue_sky_clouds_landscape_cultivation_agriculture_spring-1061063.jpg!s1");
            imageList1.Add("https://c.pxhere.com/photos/c7/6b/hay_bales_hay_straw_bales_straw_harvest_round_bales_agriculture_snow-1206034.jpg!s1");
            imageList1.Add("https://c.pxhere.com/photos/cd/9c/green_park_season_nature_outdoor_green_background_landscape_natural-839604.jpg!s1");
            imageList1.Add("https://c.pxhere.com/photos/10/60/landscape_reflection_mountain_cloud_water-100772.jpg!s1");
            imageList1.Add("https://c.pxhere.com/photos/9b/63/runner_sunset_route_run_road-2492.jpg!s1");
            imageList1.Add("https://c.pxhere.com/photos/d2/a9/landscape_reflection_water_forest_sky_scenic_scene_season-1027091.jpg!s1");
            imageList1.Add("https://c.pxhere.com/photos/2b/a3/sunset_tree_water_silhouette_nature_landscape_sky_dusk-628743.jpg!s1");
            imageList1.Add("https://c.pxhere.com/photos/0f/22/rainbow_background_roadway_beautiful_landscape_country_road_countryside_blue_sky_clouds_sky-657518.jpg!s1");
            imageList1.Add("https://c.pxhere.com/images/ce/b8/8383300029892e7a00f5a8db540c-1670280.jpg!s1");
            imageList1.Add("https://c.pxhere.com/photos/e7/82/road_forest_season_autumn_fall_landscape_nature_forest_landscape-839463.jpg!s1");
            imageList1.Add("https://c.pxhere.com/photos/76/10/onion_fields_flower_crop_india_field_agriculture_agricultural_nature-982612.jpg!s1");

            InsertImage(listView1, imageList1);
        }
        public void InsertImage(ListView listView1, List<String> imageList)
        {
            ImageList img = new ImageList();
            img.ImageSize = new Size(200, 100);
            img.ColorDepth = ColorDepth.Depth32Bit;

            for (int i = 0; i < imageList.Count; i++)
            {
                WebClient w = new WebClient();
                byte[] imageByte = w.DownloadData(imageList[i]);
                MemoryStream stream = new MemoryStream(imageByte);

                Image im = Image.FromStream(stream);

                img.Images.Add(im);
                listView1.Items.Add("", i);
            }
            listView1.LargeImageList = img;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                if (!isLoad2)
                {
                    imageList2.Add("https://c.pxhere.com/photos/8f/30/silhouette_father_and_son_sundown_chat_advice_sunset_dad_together-1293906.jpg!s1");
                    imageList2.Add("https://c.pxhere.com/photos/72/be/studio_portrait_woman_face_model_beauty_canon_photography-748283.jpg!s1");
                    imageList2.Add("https://c.pxhere.com/photos/7e/0f/boy_child_playing_happy_kid_childhood_joy_play-929271.jpg!s1");
                    imageList2.Add("https://c.pxhere.com/photos/85/4d/person_human_child_girl_toboggan_slide_winter_snow-661555.jpg!s1");
                    imageList2.Add("https://c.pxhere.com/photos/ec/36/guitar_country_girl_music_guitarist_countryside_acoustic_guitar_boots-1323639.jpg!s1");
                    imageList2.Add("https://c.pxhere.com/photos/74/9b/woman_flowers_female_sitting_bouquet_face_girl_human-1326125.jpg!s1");
                    imageList2.Add("https://c.pxhere.com/photos/5d/01/baby_boy_child_childhood_computer_concept_education_infant-1250101.jpg!s1");
                    imageList2.Add("https://c.pxhere.com/photos/00/37/boy_hungry_sad-821068.jpg!s1");
                    imageList2.Add("https://c.pxhere.com/photos/9e/60/reading_woman_book_hand_girl-175683.jpg!s1");
                    imageList2.Add("https://c.pxhere.com/photos/2f/66/woman_portrait_girl_color_fashion_dress_tshirt_hair-1044060.jpg!s1");
                    imageList2.Add("https://c.pxhere.com/photos/fd/38/station_train_station_grand_central_station_new_york_city_ny-101935.jpg!s1");
                    imageList2.Add("https://c.pxhere.com/photos/76/14/urban_people_crowd_citizens_persons_city_lifestyle_young-938709.jpg!s1");
                    imageList2.Add("https://c.pxhere.com/photos/87/61/umbrella_eat_asia_burma_faith_boy_buddha-1026328.jpg!s1");
                    imageList2.Add("https://c.pxhere.com/photos/b4/09/buffalo_agriculture_asia_cambodia_kids_china_chinese_the_country-1025992.jpg!s1");
                    imageList2.Add("https://c.pxhere.com/photos/51/73/woman_beach_person_shore_sand-500856.jpg!s1");
                    imageList2.Add("https://c.pxhere.com/photos/a8/8a/girl_teddy_bear_snuggle_cute_kids_young_joy_satisfaction-720793.jpg!s1");
                    imageList2.Add("https://c.pxhere.com/photos/7b/a6/meditation_yoga_woman_girl_sand_beach_exercise_harmony-1084638.jpg!s1");
                    imageList2.Add("https://c.pxhere.com/photos/36/4f/child_girl_human_man_people_father_and_daughter_father_sea-963328.jpg!s1");
                    imageList2.Add("https://c.pxhere.com/photos/58/64/kid_child_boy_happy_sun_flare-149010.jpg!s1");
                    imageList2.Add("https://c.pxhere.com/photos/c4/eb/aroni_arsa_children_little_model_boy_girl_portrait-734535.jpg!s1");
                    InsertImage(listView2, imageList2);
                    isLoad2 = true;
                }
            }
            if (tabControl1.SelectedIndex == 2)
            {
                if (!isLoad3)
                {
                    imageList3.Add("https://c.pxhere.com/photos/41/32/city_las_vegas_usa_sign_famous_nevada_strip-265496.jpg!s1");
                    imageList3.Add("https://c.pxhere.com/photos/7f/4b/city_travel_india_tourism_monument_architecture_asia_sightseeing-456859.jpg!s1");
                    imageList3.Add("https://c.pxhere.com/photos/53/51/eiffel_tower_paris_france_tower_architecture_steel_structure_places_of_interest_building-713307.jpg!s1");
                    imageList3.Add("https://c.pxhere.com/photos/f1/49/tower_window_cathedral_gothic_norfolk_norman_spire_nave-322933.jpg!s1");
                    imageList3.Add("https://c.pxhere.com/photos/8a/7b/new_travel_india_monument_temple_delhi_sightseeing_journey-265471.jpg!s1");
                    imageList3.Add("https://c.pxhere.com/photos/f2/29/park_new_york_city_nyc_usa_manhattan_central-265507.jpg!s1");
                    imageList3.Add("https://c.pxhere.com/photos/fd/69/new_travel_india_tourism_monument_temple_delhi_tomb-382462.jpg!s1");
                    imageList3.Add("https://c.pxhere.com/photos/bd/cd/travel_pool_swimming_hotel_cuba_resort_exotic_tropical-382376.jpg!s1");
                    imageList3.Add("https://c.pxhere.com/photos/f3/f9/uk_summer_hot_tower_cathedral_gothic_july_medieval-322905.jpg!s1");
                    imageList3.Add("https://c.pxhere.com/photos/11/72/eiffel_tower_paris_france_landmark_europe_french_tourism_famous-1024204.jpg!s1");
                    imageList3.Add("https://c.pxhere.com/photos/37/d4/views_of_the_sugar_loaf_views_of_corcovado_rio_stunning_sugarloaf_view_botafogo_bay_landmark-662549.jpg!s1");
                    imageList3.Add("https://c.pxhere.com/images/30/19/d6dc9f562a9f91f5b849ea1abc41-1585991.jpg!s1");
                    imageList3.Add("https://c.pxhere.com/images/55/e1/60e7da2afcc1da43832ca6a9af10-1586031.jpg!s1");
                    imageList3.Add("https://c.pxhere.com/images/47/be/bd1fbe5dd6096eeec55bf48b2592-1586029.jpg!s1");
                    imageList3.Add("https://c.pxhere.com/photos/b6/44/cafe_restaurant_coffee_bar_business_people_tables_pub-725484.jpg!s1");
                   
                    InsertImage(listView3, imageList3);
                    isLoad3 = true;
                }
            }
            if (tabControl1.SelectedIndex == 3)
            {
                if (!isLoad4)
                {
                    imageList4.Add("https://c.pxhere.com/photos/f3/0a/box_boxing_match_uppercut_ricardo_dominguez_rafael_ortiz_hook_fists_boxer-1255491.jpg!s1");
                    imageList4.Add("https://c.pxhere.com/photos/20/46/soccer_ball_football_players_game_sport_match_shoot-989950.jpg!s1");
                    imageList4.Add("https://c.pxhere.com/photos/de/45/skydiving_jump_falling_parachuting_military_training_high_people-1081782.jpg!s1");
                    imageList4.Add("https://c.pxhere.com/photos/cc/63/ice_hockey_puck_players_game_pass_forward_contact_sticks-669349.jpg!s1");
                    imageList4.Add("https://c.pxhere.com/photos/97/f4/child_footballer_kick_backswing_sphere_football-757702.jpg!s1");
                    imageList4.Add("https://c.pxhere.com/photos/24/54/bicycle_bike_biking_sport_cycle_ride_fun_outdoor-1238803.jpg!s1");
                    imageList4.Add("https://c.pxhere.com/photos/fa/35/relay_race_competition_stadium_sport_run_athletics_black_and_white-752204.jpg!s1");
                    imageList4.Add("https://c.pxhere.com/photos/99/11/bicycling_riding_bike_riding_cyclists_activity_canyonlands_national_park_utah_biking-658729.jpg!s1");
                    imageList4.Add("https://c.pxhere.com/photos/9b/46/swimming_swimmer_female_race_racing_pool_water_lane-1139580.jpg!s1");
                    imageList4.Add("https://c.pxhere.com/photos/61/5d/spot_runs_start_la_stadion_jogging_games_sprint-869535.jpg!s1");
                    imageList4.Add("https://c.pxhere.com/photos/6b/d2/freerider_skiing_ski_sports_alpine_snow_winter_steep-780562.jpg!s1");
                    imageList4.Add("https://c.pxhere.com/photos/d5/b7/chess_pawn_king_game_tournament_intelligence_think_championship-597481.jpg!s1");
                    imageList4.Add("https://c.pxhere.com/photos/4d/2a/football_game_sport_stadium_american_football-100657.jpg!s1");
                    imageList4.Add("https://c.pxhere.com/photos/5f/0b/utah_mountain_biking_bike_biking_sport_sports_bicycle_free_riding-1134363.jpg!s1");
                    InsertImage(listView4, imageList4);
                    isLoad4 = true;
                }
            }
            if (tabControl1.SelectedIndex == 4)
            {
                if (!isLoad5)
                {
                    imageList5.Add("https://c.pxhere.com/photos/ff/94/bull_landscape_nature_mammal_animal_meadow_cattle_farm-552442.jpg!s1");
                    imageList5.Add("https://c.pxhere.com/photos/c7/07/goose_geese_ducks_animal_nature_grass_duck_spring-1348236.jpg!s1");
                    imageList5.Add("https://c.pxhere.com/photos/b1/09/cow_red_orange_pasture_curious_animal_attention_agriculture_portrait-589962.jpg!s1");
                    imageList5.Add("https://c.pxhere.com/photos/b5/eb/zebra_wildlife_africa_animal_photography_standing_striped_together-832343.jpg!s1");
                    imageList5.Add("https://c.pxhere.com/photos/06/48/wolf_torque_wolf_moon_cloud_sky_nature_full_moon_lights-769970.jpg!s1");
                    imageList5.Add("https://c.pxhere.com/photos/ca/7b/insect_macro_bug_nature_animal_detailed_colors-1292486.jpg!s1");
                    imageList5.Add("https://c.pxhere.com/photos/2c/7d/elephant_africa_namibia_nature_dry_heiss_national_park_animal-827720.jpg!s1");
                    imageList5.Add("https://c.pxhere.com/photos/16/b9/bee_lavender_insect_nature_yellow_animal_wing_buzz-842526.jpg!s1");
                    imageList5.Add("https://c.pxhere.com/photos/16/b9/bee_lavender_insect_nature_yellow_animal_wing_buzz-842526.jpg!s1");
                    imageList5.Add("https://c.pxhere.com/photos/e5/92/chihuahua_dog_puppy_cute_pet_breed_animal-1083663.jpg!s1");
                    imageList5.Add("https://c.pxhere.com/photos/bf/82/cat_face_goldfish_glass_close_view_eyes_portrait-1367741.jpg!s1");
                    imageList5.Add("https://c.pxhere.com/photos/5c/3b/spider_cross_insect_network_close_nature_animal_eat-498779.jpg!s1");
                    imageList5.Add("https://c.pxhere.com/photos/4c/c7/horse_field_herd_animal_wild-1653.jpg!s1");
                    imageList5.Add("https://c.pxhere.com/photos/e5/da/animal_big_cat_safari_tiger_wild_cat_wildlife_zoo-1169706.jpg!s1");
                    imageList5.Add("https://c.pxhere.com/photos/47/f1/reindeer_nature_wild_deer_animal-99589.jpg!s1");

                    InsertImage(listView5, imageList5);
                    isLoad5 = true;
                }
            }
            if (tabControl1.SelectedIndex == 5)
            {
                if (!isLoad6)
                {
                    imageList6.Add("https://c.pxhere.com/photos/04/3f/notebook_diary_leave_write_down_book_notes_booklet_note-1284616.jpg!s1");
                    imageList6.Add("https://c.pxhere.com/photos/e8/f1/writing_pad_fountain_pen_graf_von_faber_castell_faber_castell_writing_tool_filler_noble_expensive-1325644.jpg!s1");
                    imageList6.Add("https://c.pxhere.com/photos/fa/dd/diy_do_it_yourself_repairs_home_improvement_hobby_tool_equipment_manual-1084217.jpg!s1");
                    imageList6.Add("https://c.pxhere.com/photos/67/52/scissors_old_sewing_on_peace_work_dress_haute_background-1060747.jpg!s1");
                    imageList6.Add("https://c.pxhere.com/photos/5e/58/cutlery_eat_cutlery_set_shiny-918911.jpg!s1");
                    imageList6.Add("https://c.pxhere.com/photos/fd/bf/colors_makeup_cosmetic_fashion_beauty_feminine_brush_blush-1107142.jpg!s1");
                    imageList6.Add("https://c.pxhere.com/photos/ff/3c/pencil_color_colorful_green_tool_row_acute_brown-671444.jpg!s1");
                    imageList6.Add("https://c.pxhere.com/photos/23/c0/tool_toolkit_collection_things_hammer-445.jpg!s1");
                    imageList6.Add("https://c.pxhere.com/photos/fd/3f/photo-228919.jpg!s1");
                    imageList6.Add("https://c.pxhere.com/photos/67/52/scissors_old_sewing_on_peace_work_dress_haute_background-1060747.jpg!s1");
                    imageList6.Add("https://c.pxhere.com/photos/ef/2b/office_stuff_school_note_pen_office_supplies_office_block_write-553197.jpg!s1");

                    InsertImage(listView6, imageList6);
                    isLoad6 = true;
                }
            }
        }
    }
}
