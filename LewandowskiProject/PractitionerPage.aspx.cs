﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LewandowskiProject
{
    public partial class PractitionerPage : System.Web.UI.Page
    {

        private string dbConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
        //Add the code that gets the "logged in" person ID from the state.
        //Temporarly set the person ID to 4 for testing purposes.
        private int personID = 4;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                get_practitionerInfo();
                get_practitionersEducations();
                get_practitionersProfessionalHealthExperiences();
                get_practitionersProfessions();
                get_practitionersBio();
            }
        }

        private void get_practitionerInfo()
        {
            using (MySqlConnection con = new MySqlConnection(dbConnectionString))
            {
                //These are the Local Variables Stored Proc
                string firstName = "";
                string lastName = "";
                string gender = "";
                string phone1 = "";
                string email1 = "";
                string city = "";
                string state = "";

                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("get_practitionerInfo", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //In parameters

                    cmd.Parameters.AddWithValue("personId", personID);
                    cmd.Parameters["personId"].Direction = ParameterDirection.Input;

                    //an out parameter

                    cmd.Parameters.AddWithValue("FirstName", firstName);
                    cmd.Parameters["FirstName"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("LastName", lastName);
                    cmd.Parameters["LastName"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("Gender", gender);
                    cmd.Parameters["Gender"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("Phone1", phone1);
                    cmd.Parameters["Phone1"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("Email1", email1);
                    cmd.Parameters["Email1"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("City", city);
                    cmd.Parameters["City"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("State", state);
                    cmd.Parameters["State"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    //Assigning the Parameters to the Local Variables
                    firstName = cmd.Parameters["FirstName"].Value.ToString();
                    lastName = cmd.Parameters["LastName"].Value.ToString();
                    gender = cmd.Parameters["Gender"].Value.ToString();
                    phone1 = cmd.Parameters["Phone1"].Value.ToString();
                    email1 = cmd.Parameters["Email1"].Value.ToString();
                    city = cmd.Parameters["City"].Value.ToString();
                    state = cmd.Parameters["State"].Value.ToString();

                    //Assigning the Fields Text or Index to the Local Variables

                    PractitionerFirstName.Text = firstName;//FirstName Textbox
                    PractitionerLastName.Text = lastName;//LastName Textbox

                    if (gender.Equals("Male") || gender.Equals("male") || gender.Equals("MALE") || gender.Equals("M"))
                    {
                        PractitionerGenderRadioButtonList.SelectedIndex = 1;// Select The Index That Corresponds with the Male Button
                    }
                    else if (gender.Equals("Female") || gender.Equals("female") || gender.Equals("FEMALE") || gender.Equals("F"))
                    {
                        PractitionerGenderRadioButtonList.SelectedIndex = 0;//Select The Index That Corresponds with the Female Button
                    }

                    PractitionerPhoneNumber.Text = phone1;
                    PractitionerEmail.Text = email1;
                    PractitionerCity.Text = city;

                    //Logic For Which State Will Be Selected

                    if (state.Equals("Alabama") || state.Equals("AL") || state.Equals("Al"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 0;
                    }
                    else if (state.Equals("Alaska") || state.Equals("AK") || state.Equals("Ak"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 1;
                    }
                    else if (state.Equals("Arizona") || state.Equals("AZ") || state.Equals("Az"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 2;
                    }
                    else if (state.Equals("Arkansas") || state.Equals("AR") || state.Equals("Ar"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 3;
                    }
                    else if (state.Equals("California") || state.Equals("CA") || state.Equals("Ca"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 4;
                    }
                    else if (state.Equals("Colorado") || state.Equals("CO") || state.Equals("Co"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 5;
                    }
                    else if (state.Equals("Connecticut") || state.Equals("CT") || state.Equals("Ct"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 6;
                    }
                    else if (state.Equals("Delaware") || state.Equals("DE") || state.Equals("De"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 7;
                    }
                    else if (state.Equals("District of Columbia") || state.Equals("DC") || state.Equals("Dc"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 8;
                    }
                    else if (state.Equals("Florida") || state.Equals("FL") || state.Equals("Fl"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 9;
                    }
                    else if (state.Equals("Georgia") || state.Equals("GA") || state.Equals("Ga"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 10;
                    }
                    else if (state.Equals("Hawaii") || state.Equals("HI") || state.Equals("Hi"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 11;
                    }
                    else if (state.Equals("Idaho") || state.Equals("ID") || state.Equals("Id"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 12;
                    }
                    else if (state.Equals("Illinois") || state.Equals("IL") || state.Equals("Il"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 13;
                    }
                    else if (state.Equals("Indiana") || state.Equals("IN") || state.Equals("In"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 14;
                    }
                    else if (state.Equals("Iowa") || state.Equals("IA") || state.Equals("Ia"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 15;
                    }
                    else if (state.Equals("Kansas") || state.Equals("KS") || state.Equals("Ks"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 16;
                    }
                    else if (state.Equals("Kentucky") || state.Equals("KY") || state.Equals("Ky"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 17;
                    }
                    else if (state.Equals("Louisiana") || state.Equals("LA") || state.Equals("La"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 18;
                    }
                    else if (state.Equals("Maine") || state.Equals("ME") || state.Equals("Me"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 19;
                    }
                    else if (state.Equals("Maryland") || state.Equals("MD") || state.Equals("Md"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 20;
                    }
                    else if (state.Equals("Massachusetts") || state.Equals("MA") || state.Equals("Ma"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 21;
                    }
                    else if (state.Equals("Michigan") || state.Equals("MI") || state.Equals("Mi"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 22;
                    }
                    else if (state.Equals("Minnesota") || state.Equals("MN") || state.Equals("Mn"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 23;
                    }
                    else if (state.Equals("Mississippi") || state.Equals("MS") || state.Equals("Ms"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 24;
                    }
                    else if (state.Equals("Missouri") || state.Equals("MO") || state.Equals("Mo"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 25;
                    }
                    else if (state.Equals("Montana") || state.Equals("MT") || state.Equals("Mt"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 26;
                    }
                    else if (state.Equals("Nebraska") || state.Equals("NE") || state.Equals("Ne"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 27;
                    }
                    else if (state.Equals("Nevada") || state.Equals("NV") || state.Equals("Nv"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 28;
                    }
                    else if (state.Equals("New Hampshire") || state.Equals("NH") || state.Equals("Nh"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 29;
                    }
                    else if (state.Equals("New Jersey") || state.Equals("NJ") || state.Equals("Nj"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 30;
                    }
                    else if (state.Equals("New Mexico") || state.Equals("NM") || state.Equals("Nm"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 31;
                    }
                    else if (state.Equals("New York") || state.Equals("NY") || state.Equals("Ny"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 32;
                    }
                    else if (state.Equals("North Carolina") || state.Equals("NC") || state.Equals("Nc"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 33;
                    }
                    else if (state.Equals("North Dakota") || state.Equals("ND") || state.Equals("Nd"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 34;
                    }
                    else if (state.Equals("Ohio") || state.Equals("OH") || state.Equals("Oh"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 35;
                    }
                    else if (state.Equals("Oklahoma") || state.Equals("OK") || state.Equals("Ok"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 36;
                    }
                    else if (state.Equals("Oregon") || state.Equals("OR") || state.Equals("Or"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 37;
                    }
                    else if (state.Equals("Pennsylvania") || state.Equals("PA") || state.Equals("Pa"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 38;
                    }
                    else if (state.Equals("Puerto Rico") || state.Equals("PR") || state.Equals("Pr"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 39;
                    }
                    else if (state.Equals("Rhode Island") || state.Equals("RI") || state.Equals("Ri"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 40;
                    }
                    else if (state.Equals("South Carolina") || state.Equals("SC") || state.Equals("Sc"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 41;
                    }
                    else if (state.Equals("South Dakota") || state.Equals("SD") || state.Equals("Sd"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 42;
                    }
                    else if (state.Equals("Tennessee") || state.Equals("TN") || state.Equals("Tn"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 43;
                    }
                    else if (state.Equals("Texas") || state.Equals("TX") || state.Equals("Tx"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 44;
                    }
                    else if (state.Equals("Utah") || state.Equals("UT") || state.Equals("Ut"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 45;
                    }
                    else if (state.Equals("Vermont") || state.Equals("VT") || state.Equals("Vt"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 46;
                    }
                    else if (state.Equals("Virginia") || state.Equals("VA") || state.Equals("Va"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 47;
                    }
                    else if (state.Equals("Virgin Islands") || state.Equals("VI") || state.Equals("Vi"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 48;
                    }
                    else if (state.Equals("Washington") || state.Equals("WA") || state.Equals("Wa"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 49;
                    }
                    else if (state.Equals("West Virginia") || state.Equals("WV") || state.Equals("Wv"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 50;
                    }
                    else if (state.Equals("Wisconsin") || state.Equals("WI") || state.Equals("Wi"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 51;
                    }
                    else if (state.Equals("Wyoming") || state.Equals("WY") || state.Equals("Wy"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 52;
                    }
                }
            }
        }

        private void get_practitionersEducations()
        {
            using (MySqlConnection con = new MySqlConnection(dbConnectionString))
            {
   
                //These are the Local Variables Stored Proc
                string InstitutionName = "";
                string EducationId = "";

                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("get_practitionersEducations", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //an in parameter

                    cmd.Parameters.AddWithValue("personId", personID);
                    cmd.Parameters["personId"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();

                    MySqlDataReader myReader;
                    myReader = cmd.ExecuteReader();
                    if (myReader.HasRows)
                    {
                        PractitionerAddEducationDropDownList.Visible = true;
                        PractitionerEducationUpdateButton.Visible = true;
                        PractitionerEducationDeleteButton.Visible = true;
                        while (myReader.Read())
                        {
                            InstitutionName = myReader["InstitutionName"].ToString();
                            EducationId = myReader["EducationId"].ToString();
                            PractitionerAddEducationDropDownList.Items.Add(new ListItem(InstitutionName, EducationId));
                        }
                        get_practitionersEducation(Convert.ToInt16(PractitionerAddEducationDropDownList.Items[0].Value));
                    } 
                    else
                    {
                        PractitionerAddEducationDropDownList.Visible = false;
                        PractitionerEducationUpdateButton.Visible = false;
                        PractitionerEducationDeleteButton.Visible = false;
                    }
                }
            }
        }

        protected void PractitionerAddEducationDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int EducationId = Convert.ToInt16(PractitionerAddEducationDropDownList.SelectedItem.Value);
            get_practitionersEducation(EducationId);
        }

        private void get_practitionersEducation(int EducationId)
        {
            using (MySqlConnection con = new MySqlConnection(dbConnectionString))
            {
                //These are the Local Variables Stored Proc
                string InstitutionName = "";
                string YearInSchool = "";
                string GraduationYear = "";
                string DegreeEarned = "";
                string Major = "";
                string Minor = "";

                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("get_practitionersEducation", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //In parameters

                    cmd.Parameters.AddWithValue("EducationId", EducationId);
                    cmd.Parameters["EducationId"].Direction = ParameterDirection.Input;

                    //an out parameter

                    cmd.Parameters.AddWithValue("InstitutionName", InstitutionName);
                    cmd.Parameters["InstitutionName"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("YearInSchool", YearInSchool);
                    cmd.Parameters["YearInSchool"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("GraduationYear", GraduationYear);
                    cmd.Parameters["GraduationYear"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("DegreeEarned", DegreeEarned);
                    cmd.Parameters["DegreeEarned"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("Major", Major);
                    cmd.Parameters["Major"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("Minor", Minor);
                    cmd.Parameters["Minor"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    //Assigning the Parameters to the Local Variables
                    InstitutionName = cmd.Parameters["InstitutionName"].Value.ToString();
                    YearInSchool = cmd.Parameters["YearInSchool"].Value.ToString();
                    GraduationYear = cmd.Parameters["GraduationYear"].Value.ToString();
                    DegreeEarned = cmd.Parameters["DegreeEarned"].Value.ToString();
                    Major = cmd.Parameters["Major"].Value.ToString();
                    Minor = cmd.Parameters["Minor"].Value.ToString();

                    //Assigning the Fields Text or Index to the Local Variables

                    PractitionerEducationSchoolNameText.Text = InstitutionName;
                    PractitionerEducationYearInText.Text = YearInSchool;

                    if (DegreeEarned.Equals("Associates"))
                    {
                        PractitionerEducationDegreeEarnedDropDownList.SelectedIndex = 0;
                    }
                    else if (DegreeEarned.Equals("Bachelors"))
                    {
                        PractitionerEducationDegreeEarnedDropDownList.SelectedIndex = 1;
                    }
                    else if (DegreeEarned.Equals("Masters")) 
                    {
                        PractitionerEducationDegreeEarnedDropDownList.SelectedIndex = 2;
                    }
                    else if (DegreeEarned.Equals("Doctorate"))
                    {
                        PractitionerEducationDegreeEarnedDropDownList.SelectedIndex = 3;
                    }
                    else if (DegreeEarned.Equals("Medical School"))
                    {
                        PractitionerEducationDegreeEarnedDropDownList.SelectedIndex = 4;
                    }

                    PractitionerEducationMajorText.Text = Major;
                    PractitionerEducationMinorText.Text = Minor;
                }
            }
        }

        private void get_practitionersProfessionalHealthExperiences()
        {
            using (MySqlConnection con = new MySqlConnection(dbConnectionString))
            {

                //These are the Local Variables Stored Proc
                string InstituteName = "";
                string PositionTitle = "";
                string ProfessionalHealthExperienceId = "";

                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("get_practitionersProfessionalHealthExperiences", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //an in parameter

                    cmd.Parameters.AddWithValue("personId", personID);
                    cmd.Parameters["personId"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();

                    MySqlDataReader myReader;
                    myReader = cmd.ExecuteReader();
                    if (myReader.HasRows)
                    {
                        PractitionerAddInternshipsDropDownList.Visible = true;
                        PractitionerInternshipsUpdateButton.Visible = true;
                        PractitionerInternshipsDeleteButton.Visible = true;
                        while (myReader.Read())
                        {
                            InstituteName = myReader["InstituteName"].ToString();
                            PositionTitle = myReader["PositionTitle"].ToString();
                            ProfessionalHealthExperienceId = myReader["ProfessionalHealthExperienceId"].ToString();
                            PractitionerAddInternshipsDropDownList.Items.Add(new ListItem(InstituteName + " - " + PositionTitle , ProfessionalHealthExperienceId));
                        }
                        get_practitionersProfessionalHealthExperience(Convert.ToInt16(PractitionerAddInternshipsDropDownList.Items[0].Value));
                    }
                    else
                    {
                        PractitionerAddInternshipsDropDownList.Visible = false;
                        PractitionerInternshipsUpdateButton.Visible = false;
                        PractitionerInternshipsDeleteButton.Visible = false;
                    }
                }
            }
        }

        protected void PractitionerAddInternshipsDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ProfessionalHealthExperienceId = Convert.ToInt16(PractitionerAddInternshipsDropDownList.SelectedItem.Value);
            get_practitionersProfessionalHealthExperience(ProfessionalHealthExperienceId);
        }

        private void get_practitionersProfessionalHealthExperience(int ProfessionalHealthExperienceId)
        {
            using (MySqlConnection con = new MySqlConnection(dbConnectionString))
            {
                //These are the Local Variables Stored Proc
                string professionalHealthExperienceType = "";
                string instituteName = "";
                string city = "";
                string state = "";
                string areaOfExpertise = "";
                string positionTitle = "";
                // not using yearsInExperience but keep if we want to later
                string yearsInExperience = "";
                string description = "";
                int currentJob = 0;

                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("get_practitionersProfessionalHealthExperience", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //In parameters

                    cmd.Parameters.AddWithValue("ProfessionalHealthExperienceId", ProfessionalHealthExperienceId);
                    cmd.Parameters["ProfessionalHealthExperienceId"].Direction = ParameterDirection.Input;

                    //an out parameter

                    cmd.Parameters.AddWithValue("ProfessionalHealthExperienceType", professionalHealthExperienceType);
                    cmd.Parameters["ProfessionalHealthExperienceType"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("InstituteName", instituteName);
                    cmd.Parameters["InstituteName"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("City", city);
                    cmd.Parameters["City"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("State", state);
                    cmd.Parameters["State"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("AreaOfExpertise", areaOfExpertise);
                    cmd.Parameters["AreaOfExpertise"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("PositionTitle", positionTitle);
                    cmd.Parameters["PositionTitle"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("YearsInExperience", yearsInExperience);
                    cmd.Parameters["YearsInExperience"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("Description", description);
                    cmd.Parameters["Description"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("CurrentJob", currentJob);
                    cmd.Parameters["CurrentJob"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    //Assigning the Parameters to the Local Variables
                    professionalHealthExperienceType = cmd.Parameters["ProfessionalHealthExperienceType"].Value.ToString();
                    instituteName = cmd.Parameters["InstituteName"].Value.ToString();
                    city = cmd.Parameters["City"].Value.ToString();
                    state = cmd.Parameters["State"].Value.ToString();
                    areaOfExpertise = cmd.Parameters["AreaOfExpertise"].Value.ToString();
                    positionTitle = cmd.Parameters["PositionTitle"].Value.ToString();
                    yearsInExperience = cmd.Parameters["YearsInExperience"].Value.ToString();
                    description = cmd.Parameters["Description"].Value.ToString();
                    currentJob = Convert.ToInt16(cmd.Parameters["CurrentJob"].Value);

                    //Assigning the Fields Text or Index to the Local Variables
                    if(professionalHealthExperienceType.Equals("Internship"))
                    {
                        PractitionerInternshipsDropDownList.SelectedIndex = 0;
                    }
                    else if(professionalHealthExperienceType.Equals("Residency"))
                    {
                        PractitionerInternshipsDropDownList.SelectedIndex = 1;
                    }
                    else if(professionalHealthExperienceType.Equals("Fellowship"))
                    {
                        PractitionerInternshipsDropDownList.SelectedIndex = 2;
                    }

                    PractitionerInternshipsInstituteNameText.Text = instituteName;
                    PractitionerInternshipsInstituteCity.Text = city;

                    //Logic For Which State Will Be Selected

                    if (state.Equals("Alabama") || state.Equals("AL") || state.Equals("Al"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 0;
                    }
                    else if (state.Equals("Alaska") || state.Equals("AK") || state.Equals("Ak"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 1;
                    }
                    else if (state.Equals("Arizona") || state.Equals("AZ") || state.Equals("Az"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 2;
                    }
                    else if (state.Equals("Arkansas") || state.Equals("AR") || state.Equals("Ar"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 3;
                    }
                    else if (state.Equals("California") || state.Equals("CA") || state.Equals("Ca"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 4;
                    }
                    else if (state.Equals("Colorado") || state.Equals("CO") || state.Equals("Co"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 5;
                    }
                    else if (state.Equals("Connecticut") || state.Equals("CT") || state.Equals("Ct"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 6;
                    }
                    else if (state.Equals("Delaware") || state.Equals("DE") || state.Equals("De"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 7;
                    }
                    else if (state.Equals("District of Columbia") || state.Equals("DC") || state.Equals("Dc"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 8;
                    }
                    else if (state.Equals("Florida") || state.Equals("FL") || state.Equals("Fl"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 9;
                    }
                    else if (state.Equals("Georgia") || state.Equals("GA") || state.Equals("Ga"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 10;
                    }
                    else if (state.Equals("Hawaii") || state.Equals("HI") || state.Equals("Hi"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 11;
                    }
                    else if (state.Equals("Idaho") || state.Equals("ID") || state.Equals("Id"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 12;
                    }
                    else if (state.Equals("Illinois") || state.Equals("IL") || state.Equals("Il"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 13;
                    }
                    else if (state.Equals("Indiana") || state.Equals("IN") || state.Equals("In"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 14;
                    }
                    else if (state.Equals("Iowa") || state.Equals("IA") || state.Equals("Ia"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 15;
                    }
                    else if (state.Equals("Kansas") || state.Equals("KS") || state.Equals("Ks"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 16;
                    }
                    else if (state.Equals("Kentucky") || state.Equals("KY") || state.Equals("Ky"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 17;
                    }
                    else if (state.Equals("Louisiana") || state.Equals("LA") || state.Equals("La"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 18;
                    }
                    else if (state.Equals("Maine") || state.Equals("ME") || state.Equals("Me"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 19;
                    }
                    else if (state.Equals("Maryland") || state.Equals("MD") || state.Equals("Md"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 20;
                    }
                    else if (state.Equals("Massachusetts") || state.Equals("MA") || state.Equals("Ma"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 21;
                    }
                    else if (state.Equals("Michigan") || state.Equals("MI") || state.Equals("Mi"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 22;
                    }
                    else if (state.Equals("Minnesota") || state.Equals("MN") || state.Equals("Mn"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 23;
                    }
                    else if (state.Equals("Mississippi") || state.Equals("MS") || state.Equals("Ms"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 24;
                    }
                    else if (state.Equals("Missouri") || state.Equals("MO") || state.Equals("Mo"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 25;
                    }
                    else if (state.Equals("Montana") || state.Equals("MT") || state.Equals("Mt"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 26;
                    }
                    else if (state.Equals("Nebraska") || state.Equals("NE") || state.Equals("Ne"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 27;
                    }
                    else if (state.Equals("Nevada") || state.Equals("NV") || state.Equals("Nv"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 28;
                    }
                    else if (state.Equals("New Hampshire") || state.Equals("NH") || state.Equals("Nh"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 29;
                    }
                    else if (state.Equals("New Jersey") || state.Equals("NJ") || state.Equals("Nj"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 30;
                    }
                    else if (state.Equals("New Mexico") || state.Equals("NM") || state.Equals("Nm"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 31;
                    }
                    else if (state.Equals("New York") || state.Equals("NY") || state.Equals("Ny"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 32;
                    }
                    else if (state.Equals("North Carolina") || state.Equals("NC") || state.Equals("Nc"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 33;
                    }
                    else if (state.Equals("North Dakota") || state.Equals("ND") || state.Equals("Nd"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 34;
                    }
                    else if (state.Equals("Ohio") || state.Equals("OH") || state.Equals("Oh"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 35;
                    }
                    else if (state.Equals("Oklahoma") || state.Equals("OK") || state.Equals("Ok"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 36;
                    }
                    else if (state.Equals("Oregon") || state.Equals("OR") || state.Equals("Or"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 37;
                    }
                    else if (state.Equals("Pennsylvania") || state.Equals("PA") || state.Equals("Pa"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 38;
                    }
                    else if (state.Equals("Puerto Rico") || state.Equals("PR") || state.Equals("Pr"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 39;
                    }
                    else if (state.Equals("Rhode Island") || state.Equals("RI") || state.Equals("Ri"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 40;
                    }
                    else if (state.Equals("South Carolina") || state.Equals("SC") || state.Equals("Sc"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 41;
                    }
                    else if (state.Equals("South Dakota") || state.Equals("SD") || state.Equals("Sd"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 42;
                    }
                    else if (state.Equals("Tennessee") || state.Equals("TN") || state.Equals("Tn"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 43;
                    }
                    else if (state.Equals("Texas") || state.Equals("TX") || state.Equals("Tx"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 44;
                    }
                    else if (state.Equals("Utah") || state.Equals("UT") || state.Equals("Ut"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 45;
                    }
                    else if (state.Equals("Vermont") || state.Equals("VT") || state.Equals("Vt"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 46;
                    }
                    else if (state.Equals("Virginia") || state.Equals("VA") || state.Equals("Va"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 47;
                    }
                    else if (state.Equals("Virgin Islands") || state.Equals("VI") || state.Equals("Vi"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 48;
                    }
                    else if (state.Equals("Washington") || state.Equals("WA") || state.Equals("Wa"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 49;
                    }
                    else if (state.Equals("West Virginia") || state.Equals("WV") || state.Equals("Wv"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 50;
                    }
                    else if (state.Equals("Wisconsin") || state.Equals("WI") || state.Equals("Wi"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 51;
                    }
                    else if (state.Equals("Wyoming") || state.Equals("WY") || state.Equals("Wy"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 52;
                    }

                    //Logic For Which Area of Expertise Will Be Selected

                    if (areaOfExpertise.Equals("Dentistry"))
                    {
                        PractitionerInternshipsAreaDropDownList.SelectedIndex = 0;
                    }
                    else if (areaOfExpertise.Equals("Surgery"))
                    {
                        PractitionerInternshipsAreaDropDownList.SelectedIndex = 1;
                    }
                    else if (PractitionerInternshipsAreaDropDownList.Equals("Other"))
                    {
                        PractitionerInternshipsAreaDropDownList.SelectedIndex = 2;
                    }

                    PractitionerInternshipNameOrTitle.Text = positionTitle;
                    PractitionerInternshipsTextArea.Text = description;

                    if (currentJob == 0)
                    {
                        PractitionerInternshipsCurrentRadioButtonList.SelectedIndex = 0;
                    }
                    else if (currentJob == 1)
                    {
                        PractitionerInternshipsCurrentRadioButtonList.SelectedIndex = 1;
                    }
                }
            }
        }

        private void get_practitionersProfessions()
        {
            using (MySqlConnection con = new MySqlConnection(dbConnectionString))
            {

                //These are the Local Variables Stored Proc
                string NameOfCompany = "";
                string ProfessionTitle = "";
                string ProfessionId = "";

                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("get_practitionersProfessions", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //an in parameter

                    cmd.Parameters.AddWithValue("personId", personID);
                    cmd.Parameters["personId"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();

                    MySqlDataReader myReader;
                    myReader = cmd.ExecuteReader();
                    if (myReader.HasRows)
                    {
                        PractitionerAddPrfessionDropDownList.Visible = true;
                        PractitionerProfessionUpdateButton.Visible = true;
                        PractitionerProfessionDeleteButton.Visible = true;
                        while (myReader.Read())
                        {
                            NameOfCompany = myReader["NameOfCompany"].ToString();
                            ProfessionTitle = myReader["ProfessionTitle"].ToString();
                            ProfessionId = myReader["ProfessionId"].ToString();
                            PractitionerAddPrfessionDropDownList.Items.Add(new ListItem(NameOfCompany + " - " + ProfessionTitle, ProfessionId));
                        }
                        get_practitionersProfession(Convert.ToInt16(PractitionerAddPrfessionDropDownList.Items[0].Value));
                    }
                    else
                    {
                        PractitionerAddPrfessionDropDownList.Visible = false;
                        PractitionerProfessionUpdateButton.Visible = false;
                        PractitionerProfessionDeleteButton.Visible = false;
                    }
                }
            }
        }

        protected void PractitionerAddPrfessionDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ProfessionId = Convert.ToInt16(PractitionerAddPrfessionDropDownList.SelectedItem.Value);
            get_practitionersProfession(ProfessionId);
        }

        private void get_practitionersProfession(int ProfessionId)
        {
            using (MySqlConnection con = new MySqlConnection(dbConnectionString))
            {
                //These are the Local Variables Stored Proc
                string professionTitle = "";
                string specialty = "";
                string nameOfCompany = "";
                string city = "";
                string state = "";
                string yearsInProfession = "";
                string areaOfExpertise = "";
                int currentJob = 0;

                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("get_practitionersProfession", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //In parameters

                    cmd.Parameters.AddWithValue("ProfessionId", ProfessionId);
                    cmd.Parameters["ProfessionId"].Direction = ParameterDirection.Input;

                    //an out parameter

                    cmd.Parameters.AddWithValue("ProfessionTitle", professionTitle);
                    cmd.Parameters["ProfessionTitle"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("Specialty", specialty);
                    cmd.Parameters["Specialty"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("NameOfCompany", nameOfCompany);
                    cmd.Parameters["NameOfCompany"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("City", city);
                    cmd.Parameters["City"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("State", state);
                    cmd.Parameters["State"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("YearsInProfession", yearsInProfession);
                    cmd.Parameters["YearsInProfession"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("AreaOfExpertise", areaOfExpertise);
                    cmd.Parameters["AreaOfExpertise"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("CurrentJob", currentJob);
                    cmd.Parameters["CurrentJob"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    //Assigning the Parameters to the Local Variables
                    professionTitle = cmd.Parameters["ProfessionTitle"].Value.ToString();
                    specialty = cmd.Parameters["Specialty"].Value.ToString();
                    nameOfCompany = cmd.Parameters["NameOfCompany"].Value.ToString();
                    city = cmd.Parameters["City"].Value.ToString();
                    state = cmd.Parameters["State"].Value.ToString();
                    yearsInProfession = cmd.Parameters["YearsInProfession"].Value.ToString();
                    areaOfExpertise = cmd.Parameters["AreaOfExpertise"].Value.ToString();
                    currentJob = Convert.ToInt16(cmd.Parameters["CurrentJob"].Value);

                    //Assigning the Fields Text or Index to the Local Variables
                    PractitionerProfessionNameOrTitle.Text = professionTitle;
                    PractitionerProfessionSpecialty.Text = specialty;
                    PractitionerProfessionLocationText.Text = nameOfCompany;
                    PractitionerProfessionCity.Text = city;

                    //Logic For Which State Will Be Selected

                    if (state.Equals("Alabama") || state.Equals("AL") || state.Equals("Al"))
                    {
                        PractitionerProfessionStateDropDownList.SelectedIndex = 0;
                    }
                    else if (state.Equals("Alaska") || state.Equals("AK") || state.Equals("Ak"))
                    {
                        PractitionerProfessionStateDropDownList.SelectedIndex = 1;
                    }
                    else if (state.Equals("Arizona") || state.Equals("AZ") || state.Equals("Az"))
                    {
                        PractitionerProfessionStateDropDownList.SelectedIndex = 2;
                    }
                    else if (state.Equals("Arkansas") || state.Equals("AR") || state.Equals("Ar"))
                    {
                        PractitionerProfessionStateDropDownList.SelectedIndex = 3;
                    }
                    else if (state.Equals("California") || state.Equals("CA") || state.Equals("Ca"))
                    {
                        PractitionerProfessionStateDropDownList.SelectedIndex = 4;
                    }
                    else if (state.Equals("Colorado") || state.Equals("CO") || state.Equals("Co"))
                    {
                        PractitionerProfessionStateDropDownList.SelectedIndex = 5;
                    }
                    else if (state.Equals("Connecticut") || state.Equals("CT") || state.Equals("Ct"))
                    {
                        PractitionerProfessionStateDropDownList.SelectedIndex = 6;
                    }
                    else if (state.Equals("Delaware") || state.Equals("DE") || state.Equals("De"))
                    {
                        PractitionerProfessionStateDropDownList.SelectedIndex = 7;
                    }
                    else if (state.Equals("District of Columbia") || state.Equals("DC") || state.Equals("Dc"))
                    {
                        PractitionerProfessionStateDropDownList.SelectedIndex = 8;
                    }
                    else if (state.Equals("Florida") || state.Equals("FL") || state.Equals("Fl"))
                    {
                        PractitionerProfessionStateDropDownList.SelectedIndex = 9;
                    }
                    else if (state.Equals("Georgia") || state.Equals("GA") || state.Equals("Ga"))
                    {
                        PractitionerProfessionStateDropDownList.SelectedIndex = 10;
                    }
                    else if (state.Equals("Hawaii") || state.Equals("HI") || state.Equals("Hi"))
                    {
                        PractitionerProfessionStateDropDownList.SelectedIndex = 11;
                    }
                    else if (state.Equals("Idaho") || state.Equals("ID") || state.Equals("Id"))
                    {
                        PractitionerProfessionStateDropDownList.SelectedIndex = 12;
                    }
                    else if (state.Equals("Illinois") || state.Equals("IL") || state.Equals("Il"))
                    {
                        PractitionerProfessionStateDropDownList.SelectedIndex = 13;
                    }
                    else if (state.Equals("Indiana") || state.Equals("IN") || state.Equals("In"))
                    {
                        PractitionerProfessionStateDropDownList.SelectedIndex = 14;
                    }
                    else if (state.Equals("Iowa") || state.Equals("IA") || state.Equals("Ia"))
                    {
                        PractitionerProfessionStateDropDownList.SelectedIndex = 15;
                    }
                    else if (state.Equals("Kansas") || state.Equals("KS") || state.Equals("Ks"))
                    {
                        PractitionerProfessionStateDropDownList.SelectedIndex = 16;
                    }
                    else if (state.Equals("Kentucky") || state.Equals("KY") || state.Equals("Ky"))
                    {
                        PractitionerProfessionStateDropDownList.SelectedIndex = 17;
                    }
                    else if (state.Equals("Louisiana") || state.Equals("LA") || state.Equals("La"))
                    {
                        PractitionerProfessionStateDropDownList.SelectedIndex = 18;
                    }
                    else if (state.Equals("Maine") || state.Equals("ME") || state.Equals("Me"))
                    {
                        PractitionerProfessionStateDropDownList.SelectedIndex = 19;
                    }
                    else if (state.Equals("Maryland") || state.Equals("MD") || state.Equals("Md"))
                    {
                        PractitionerProfessionStateDropDownList.SelectedIndex = 20;
                    }
                    else if (state.Equals("Massachusetts") || state.Equals("MA") || state.Equals("Ma"))
                    {
                        PractitionerProfessionStateDropDownList.SelectedIndex = 21;
                    }
                    else if (state.Equals("Michigan") || state.Equals("MI") || state.Equals("Mi"))
                    {
                        PractitionerProfessionStateDropDownList.SelectedIndex = 22;
                    }
                    else if (state.Equals("Minnesota") || state.Equals("MN") || state.Equals("Mn"))
                    {
                        PractitionerProfessionStateDropDownList.SelectedIndex = 23;
                    }
                    else if (state.Equals("Mississippi") || state.Equals("MS") || state.Equals("Ms"))
                    {
                        PractitionerProfessionStateDropDownList.SelectedIndex = 24;
                    }
                    else if (state.Equals("Missouri") || state.Equals("MO") || state.Equals("Mo"))
                    {
                        PractitionerProfessionStateDropDownList.SelectedIndex = 25;
                    }
                    else if (state.Equals("Montana") || state.Equals("MT") || state.Equals("Mt"))
                    {
                        PractitionerProfessionStateDropDownList.SelectedIndex = 26;
                    }
                    else if (state.Equals("Nebraska") || state.Equals("NE") || state.Equals("Ne"))
                    {
                        PractitionerProfessionStateDropDownList.SelectedIndex = 27;
                    }
                    else if (state.Equals("Nevada") || state.Equals("NV") || state.Equals("Nv"))
                    {
                        PractitionerProfessionStateDropDownList.SelectedIndex = 28;
                    }
                    else if (state.Equals("New Hampshire") || state.Equals("NH") || state.Equals("Nh"))
                    {
                        PractitionerProfessionStateDropDownList.SelectedIndex = 29;
                    }
                    else if (state.Equals("New Jersey") || state.Equals("NJ") || state.Equals("Nj"))
                    {
                        PractitionerProfessionStateDropDownList.SelectedIndex = 30;
                    }
                    else if (state.Equals("New Mexico") || state.Equals("NM") || state.Equals("Nm"))
                    {
                        PractitionerProfessionStateDropDownList.SelectedIndex = 31;
                    }
                    else if (state.Equals("New York") || state.Equals("NY") || state.Equals("Ny"))
                    {
                        PractitionerProfessionStateDropDownList.SelectedIndex = 32;
                    }
                    else if (state.Equals("North Carolina") || state.Equals("NC") || state.Equals("Nc"))
                    {
                        PractitionerProfessionStateDropDownList.SelectedIndex = 33;
                    }
                    else if (state.Equals("North Dakota") || state.Equals("ND") || state.Equals("Nd"))
                    {
                        PractitionerProfessionStateDropDownList.SelectedIndex = 34;
                    }
                    else if (state.Equals("Ohio") || state.Equals("OH") || state.Equals("Oh"))
                    {
                        PractitionerProfessionStateDropDownList.SelectedIndex = 35;
                    }
                    else if (state.Equals("Oklahoma") || state.Equals("OK") || state.Equals("Ok"))
                    {
                        PractitionerProfessionStateDropDownList.SelectedIndex = 36;
                    }
                    else if (state.Equals("Oregon") || state.Equals("OR") || state.Equals("Or"))
                    {
                        PractitionerProfessionStateDropDownList.SelectedIndex = 37;
                    }
                    else if (state.Equals("Pennsylvania") || state.Equals("PA") || state.Equals("Pa"))
                    {
                        PractitionerProfessionStateDropDownList.SelectedIndex = 38;
                    }
                    else if (state.Equals("Puerto Rico") || state.Equals("PR") || state.Equals("Pr"))
                    {
                        PractitionerProfessionStateDropDownList.SelectedIndex = 39;
                    }
                    else if (state.Equals("Rhode Island") || state.Equals("RI") || state.Equals("Ri"))
                    {
                        PractitionerProfessionStateDropDownList.SelectedIndex = 40;
                    }
                    else if (state.Equals("South Carolina") || state.Equals("SC") || state.Equals("Sc"))
                    {
                        PractitionerProfessionStateDropDownList.SelectedIndex = 41;
                    }
                    else if (state.Equals("South Dakota") || state.Equals("SD") || state.Equals("Sd"))
                    {
                        PractitionerProfessionStateDropDownList.SelectedIndex = 42;
                    }
                    else if (state.Equals("Tennessee") || state.Equals("TN") || state.Equals("Tn"))
                    {
                        PractitionerProfessionStateDropDownList.SelectedIndex = 43;
                    }
                    else if (state.Equals("Texas") || state.Equals("TX") || state.Equals("Tx"))
                    {
                        PractitionerProfessionStateDropDownList.SelectedIndex = 44;
                    }
                    else if (state.Equals("Utah") || state.Equals("UT") || state.Equals("Ut"))
                    {
                        PractitionerProfessionStateDropDownList.SelectedIndex = 45;
                    }
                    else if (state.Equals("Vermont") || state.Equals("VT") || state.Equals("Vt"))
                    {
                        PractitionerProfessionStateDropDownList.SelectedIndex = 46;
                    }
                    else if (state.Equals("Virginia") || state.Equals("VA") || state.Equals("Va"))
                    {
                        PractitionerProfessionStateDropDownList.SelectedIndex = 47;
                    }
                    else if (state.Equals("Virgin Islands") || state.Equals("VI") || state.Equals("Vi"))
                    {
                        PractitionerProfessionStateDropDownList.SelectedIndex = 48;
                    }
                    else if (state.Equals("Washington") || state.Equals("WA") || state.Equals("Wa"))
                    {
                        PractitionerProfessionStateDropDownList.SelectedIndex = 49;
                    }
                    else if (state.Equals("West Virginia") || state.Equals("WV") || state.Equals("Wv"))
                    {
                        PractitionerProfessionStateDropDownList.SelectedIndex = 50;
                    }
                    else if (state.Equals("Wisconsin") || state.Equals("WI") || state.Equals("Wi"))
                    {
                        PractitionerProfessionStateDropDownList.SelectedIndex = 51;
                    }
                    else if (state.Equals("Wyoming") || state.Equals("WY") || state.Equals("Wy"))
                    {
                        PractitionerProfessionStateDropDownList.SelectedIndex = 52;
                    }

                    PractitionerYearsInLabelText.Text = yearsInProfession;


                    //Logic For Which Area of Expertise Will Be Selected

                    if (areaOfExpertise.Equals("Dentistry"))
                    {
                        PractitionerProfessionDropDownList.SelectedIndex = 0;
                    }
                    else if (areaOfExpertise.Equals("Surgery"))
                    {
                        PractitionerProfessionDropDownList.SelectedIndex = 1;
                    }
                    else if (areaOfExpertise.Equals("Other"))
                    {
                        PractitionerProfessionDropDownList.SelectedIndex = 2;
                    }

                    if (currentJob == 0)
                    {
                        PractitionerProfessionCurrentRadioButtonList.SelectedIndex = 0;
                    }
                    else if (currentJob == 1)
                    {
                        PractitionerProfessionCurrentRadioButtonList.SelectedIndex = 1;
                    }
                }
            }
        }

        private void get_practitionersBio()
        {
            using (MySqlConnection con = new MySqlConnection(dbConnectionString))
            {
                //These are the Local Variables Stored Proc
                string Bio = "";

                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("get_practitionersBio", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //In parameters

                    cmd.Parameters.AddWithValue("PersonId", personID);
                    cmd.Parameters["PersonId"].Direction = ParameterDirection.Input;

                    //an out parameter

                    cmd.Parameters.AddWithValue("Bio", Bio);
                    cmd.Parameters["Bio"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    //Assigning the Parameters to the Local Variables
                    Bio = cmd.Parameters["Bio"].Value.ToString();

                    //Assigning the Fields Text or Index to the Local Variables
                    BioTextArea.Text = Bio;
                }
            }
        }
    }
}