using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GHMS.DataModel.Migrations
{
    public partial class InsertData_LuCountries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"delete from public.""LuCountries"";
INSERT INTO public.""LuCountries""(
	 ""LastUpdateUserId"", ""LastUpdateDate"", ""IsActive"", ""Name"", ""Code"")
select null,now(),true,'Andorra','AD' union
select null,now(),true,'United Arab Emirates','AE' union
select null,now(),true,'Afghanistan','AF' union
select null,now(),true,'Antigua and Barbuda','AG' union
select null,now(),true,'Anguilla','AI' union
select null,now(),true,'Albania','AL' union
select null,now(),true,'Armenia','AM' union
select null,now(),true,'Angola','AO' union
select null,now(),true,'Antarctica','AQ' union
select null,now(),true,'Argentina','AR' union
select null,now(),true,'American Samoa','AS' union
select null,now(),true,'Austria','AT' union
select null,now(),true,'Australia','AU' union
select null,now(),true,'Aruba','AW' union
select null,now(),true,'Azerbaijan','AZ' union
select null,now(),true,'Bosnia and Herzegovina','BA' union
select null,now(),true,'Barbados','BB' union
select null,now(),true,'Burundi','BI' union
select null,now(),true,'Belgium','BE' union
select null,now(),true,'Burkina Faso','BF' union
select null,now(),true,'Bulgaria','BG' union
select null,now(),true,'Bahrain','BH' union
select null,now(),true,'Bangladesh','BD' union
select null,now(),true,'Benin','BJ' union
select null,now(),true,'Bermuda','BM' union
select null,now(),true,'Brunei Darussalam','BN' union
select null,now(),true,'Bolivia, Plurinational State of','BO' union
select null,now(),true,'Brazil','BR' union
select null,now(),true,'Bahamas','BS' union
select null,now(),true,'Bhutan','BT' union
select null,now(),true,'Botswana','BW' union
select null,now(),true,'Belarus','BY' union
select null,now(),true,'Belize','BZ' union
select null,now(),true,'Canada','CA' union
select null,now(),true,'Cocos (Keeling) Islands','CC' union
select null,now(),true,'Congo, The Democratic Republic of the','CD' union
select null,now(),true,'Central African Republic','CF' union
select null,now(),true,'Congo','CG' union
select null,now(),true,'Switzerland','CH' union
select null,now(),true,'Côte d''Ivoire','CI' union
select null,now(),true,'Cook Islands','CK' union
select null,now(),true,'Chile','CL' union
select null,now(),true,'Cameroon','CM' union
select null,now(),true,'China','CN' union
select null,now(),true,'Colombia','CO' union
select null,now(),true,'Costa Rica','CR' union
select null,now(),true,'Cuba','CU' union
select null,now(),true,'Cape Verde','CV' union
select null,now(),true,'Christmas Island','CX' union
select null,now(),true,'Cyprus','CY' union
select null,now(),true,'Czech Republic','CZ' union
select null,now(),true,'Germany','DE' union
select null,now(),true,'Djibouti','DJ' union
select null,now(),true,'Denmark','DK' union
select null,now(),true,'Dominica','DM' union
select null,now(),true,'Dominican Republic','DO' union
select null,now(),true,'Algeria','DZ' union
select null,now(),true,'Ecuador','EC' union
select null,now(),true,'Estonia','EE' union
select null,now(),true,'Egypt','EG' union
select null,now(),true,'Western Sahara','EH' union
select null,now(),true,'Eritrea','ER' union
select null,now(),true,'Spain','ES' union
select null,now(),true,'Ethiopia','ET' union
select null,now(),true,'Finland','FI' union
select null,now(),true,'Fiji','FJ' union
select null,now(),true,'Falkland Islands (Malvinas)','FK' union
select null,now(),true,'Micronesia, Federated States of','FM' union
select null,now(),true,'Faroe Islands','FO' union
select null,now(),true,'France','FR' union
select null,now(),true,'Gabon','GA' union
select null,now(),true,'United Kingdom','GB' union
select null,now(),true,'Grenada','GD' union
select null,now(),true,'Georgia','GE' union
select null,now(),true,'French Guiana','GF' union
select null,now(),true,'Ghana','GH' union
select null,now(),true,'Gibraltar','GI' union
select null,now(),true,'Greenland','GL' union
select null,now(),true,'Gambia','GM' union
select null,now(),true,'Guinea','GN' union
select null,now(),true,'Guadeloupe','GP' union
select null,now(),true,'Equatorial Guinea','GQ' union
select null,now(),true,'Greece','GR' union
select null,now(),true,'South Georgia and the South Sandwich Islands','GS' union
select null,now(),true,'Guatemala','GT' union
select null,now(),true,'Guam','GU' union
select null,now(),true,'Guinea-Bissau','GW' union
select null,now(),true,'Guyana','GY' union
select null,now(),true,'Hong Kong ','HK' union
select null,now(),true,'Heard Island and McDonald Islands','HM' union
select null,now(),true,'Honduras','HN' union
select null,now(),true,'Croatia','HR' union
select null,now(),true,'Haiti','HT' union
select null,now(),true,'Hungary','HU' union
select null,now(),true,'Indonesia','ID' union
select null,now(),true,'Ireland','IE' union
select null,now(),true,'Israel','IL' union
select null,now(),true,'India','IN' union
select null,now(),true,'British Indian Ocean Territory','IO' union
select null,now(),true,'Iraq','IQ' union
select null,now(),true,'Iran, Islamic Republic of','IR' union
select null,now(),true,'Iceland','IS' union
select null,now(),true,'Italy','IT' union
select null,now(),true,'Jamaica','JM' union
select null,now(),true,'Jordan','JO' union
select null,now(),true,'Japan','JP' union
select null,now(),true,'Kenya','KE' union
select null,now(),true,'Kyrgyzstan','KG' union
select null,now(),true,'Cambodia','KH' union
select null,now(),true,'Kiribati','KI' union
select null,now(),true,'Comoros','KM' union
select null,now(),true,'Saint Kitts and Nevis','KN' union
select null,now(),true,'Korea, Democratic People''s Republic of','KP' union
select null,now(),true,'Korea, Republic of','KR' union
select null,now(),true,'Kuwait','KW' union
select null,now(),true,'Cayman Islands','KY' union
select null,now(),true,'Kazakhstan','KZ' union
select null,now(),true,'Lao People''s Democratic Republic','LA' union
select null,now(),true,'Lebanon','LB' union
select null,now(),true,'Saint Lucia','LC' union
select null,now(),true,'Liechtenstein','LI' union
select null,now(),true,'Sri Lanka','LK' union
select null,now(),true,'Liberia','LR' union
select null,now(),true,'Lesotho','LS' union
select null,now(),true,'Lithuania','LT' union
select null,now(),true,'Luxembourg','LU' union
select null,now(),true,'Latvia','LV' union
select null,now(),true,'Libya','LY' union
select null,now(),true,'Morocco','MA' union
select null,now(),true,'Monaco','MC' union
select null,now(),true,'Moldova, Republic of','MD' union
select null,now(),true,'Madagascar','MG' union
select null,now(),true,'Marshall Islands','MH' union
select null,now(),true,'Macedonia, The former Yugoslav Republic of','MK' union
select null,now(),true,'Mali','ML' union
select null,now(),true,'Myanmar','MM' union
select null,now(),true,'Mongolia','MN' union
select null,now(),true,'Macao','MO' union
select null,now(),true,'Northern Mariana Islands','MP' union
select null,now(),true,'Martinique','MQ' union
select null,now(),true,'Mauritania','MR' union
select null,now(),true,'Montserrat','MS' union
select null,now(),true,'Malta','MT' union
select null,now(),true,'Mauritius','MU' union
select null,now(),true,'Maldives','MV' union
select null,now(),true,'Malawi','MW' union
select null,now(),true,'Mexico','MX' union
select null,now(),true,'Malaysia','MY' union
select null,now(),true,'Mozambique','MZ' union
select null,now(),true,'Namibia','NA' union
select null,now(),true,'New Caledonia','NC' union
select null,now(),true,'Niger','NE' union
select null,now(),true,'Norfolk Island','NF' union
select null,now(),true,'Nigeria','NG' union
select null,now(),true,'Nicaragua','NI' union
select null,now(),true,'Netherlands','NL' union
select null,now(),true,'Norway','NO' union
select null,now(),true,'Nepal','NP' union
select null,now(),true,'Nauru','NR' union
select null,now(),true,'Niue','NU' union
select null,now(),true,'New Zealand','NZ' union
select null,now(),true,'Oman','OM' union
select null,now(),true,'Panama','PA' union
select null,now(),true,'Peru','PE' union
select null,now(),true,'French Polynesia','PF' union
select null,now(),true,'Papua New Guinea','PG' union
select null,now(),true,'Philippines','PH' union
select null,now(),true,'Pakistan','PK' union
select null,now(),true,'Poland','PL' union
select null,now(),true,'Saint Pierre and Miquelon','PM' union
select null,now(),true,'Pitcairn','PN' union
select null,now(),true,'Puerto Rico','PR' union
select null,now(),true,'Palestine, State of','PS' union
select null,now(),true,'Portugal','PT' union
select null,now(),true,'Palau','PW' union
select null,now(),true,'Paraguay','PY' union
select null,now(),true,'Qatar','QA' union
select null,now(),true,'Réunion','RE' union
select null,now(),true,'Romania','RO' union
select null,now(),true,'Russian Federation','RU' union
select null,now(),true,'Rwanda','RW' union
select null,now(),true,'Saudi Arabia','SA' union
select null,now(),true,'Solomon Islands','SB' union
select null,now(),true,'Seychelles','SC' union
select null,now(),true,'Sudan','SD' union
select null,now(),true,'Sweden','SE' union
select null,now(),true,'Singapore','SG' union
select null,now(),true,'Saint Helena, Ascension and Tristan Da Cunha','SH' union
select null,now(),true,'Slovenia','SI' union
select null,now(),true,'Svalbard and Jan Mayen','SJ' union
select null,now(),true,'Slovakia','SK' union
select null,now(),true,'Sierra Leone','SL' union
select null,now(),true,'San Marino','SM' union
select null,now(),true,'Senegal','SN' union
select null,now(),true,'Somalia','SO' union
select null,now(),true,'Suriname','SR' union
select null,now(),true,'Sao Tome and Principe','ST' union
select null,now(),true,'El Salvador','SV' union
select null,now(),true,'Syrian Arab Republic','SY' union
select null,now(),true,'Swaziland','SZ' union
select null,now(),true,'Turks and Caicos Islands','TC' union
select null,now(),true,'Chad','TD' union
select null,now(),true,'French Southern Territories','TF' union
select null,now(),true,'Togo','TG' union
select null,now(),true,'Thailand','TH' union
select null,now(),true,'Tajikistan','TJ' union
select null,now(),true,'Tokelau','TK' union
select null,now(),true,'Turkmenistan','TM' union
select null,now(),true,'Tunisia','TN' union
select null,now(),true,'Tonga','TO' union
select null,now(),true,'Timor-Leste','TL' union
select null,now(),true,'Turkey','TR' union
select null,now(),true,'Trinidad and Tobago','TT' union
select null,now(),true,'Tuvalu','TV' union
select null,now(),true,'Taiwan, Province of China','TW' union
select null,now(),true,'Tanzania, United Republic of','TZ' union
select null,now(),true,'Ukraine','UA' union
select null,now(),true,'Uganda','UG' union
select null,now(),true,'United States Minor Outlying Islands','UM' union
select null,now(),true,'United States','US' union
select null,now(),true,'Uruguay','UY' union
select null,now(),true,'Uzbekistan','UZ' union
select null,now(),true,'Holy See (Vatican City State)','VA' union
select null,now(),true,'Saint Vincent and the Grenadines','VC' union
select null,now(),true,'Venezuela','VE' union
select null,now(),true,'Virgin Islands, British','VG' union
select null,now(),true,'Virgin Islands, U.S.','VI' union
select null,now(),true,'Viet Nam','VN' union
select null,now(),true,'Vanuatu','VU' union
select null,now(),true,'Wallis and Futuna','WF' union
select null,now(),true,'Samoa','WS' union
select null,now(),true,'Yemen','YE' union
select null,now(),true,'Mayotte','YT' union
select null,now(),true,'South Africa','ZA' union
select null,now(),true,'Zambia','ZM' union
select null,now(),true,'Zimbabwe','ZW' union
select null,now(),true,'Installations in International Waters','XZ' union
select null,now(),true,'Serbia','RS' union
select null,now(),true,'Montenegro','ME' union
select null,now(),true,'Jersey','JE' union
select null,now(),true,'Guernsey','GG' union
select null,now(),true,'Isle of Man','IM' union
select null,now(),true,'Åland Islands','AX' union
select null,now(),true,'Curaçao','CW' union
select null,now(),true,'Bonaire, Sint Eustatius and Saba','BQ' union
select null,now(),true,'Saint Barthélemy','BL' union
select null,now(),true,'Saint Martin (French Part)','MF' union
select null,now(),true,'Sint Maarten (Dutch Part)','SX' union
select null,now(),true,'South Sudan','SS'  "
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
        }
    }
}
