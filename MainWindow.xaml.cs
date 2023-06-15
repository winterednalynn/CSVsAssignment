using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CsvHelper; 

namespace CSVsAssignment //CSV - Comma Seperated VALUES 
{//EDNA LYNN LAXA 
 //PROGRAMMING III - Persistent Data - CSVs - Writing, Reading, and Preloading
 //JUNE 14, 2023 

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<BehavioralAnalysisUnit> _agents = new List<BehavioralAnalysisUnit>(); // BAU list from class. 
        const string filePath = "BAUagents.csv"; // Good practice to value a repeated value, therefore were not writing it over and over again. Placed filepath into a const variable

        public MainWindow()
        {
            InitializeComponent();
           
        }


        public void CSVsaver<T>(string filePath, List<T> list)
        {
            CultureInfo ci = CultureInfo.InvariantCulture; //The InvariantCulture property can be used to persist data in a culture-independent format.

            //var is used to declare implicitly typed local variable means it tells the compiler to figure out the type. 
            using (var stream = File.Open(filePath, FileMode.OpenOrCreate)) //File.Open corresponds to the System.IO ; Opens a FileStream on the path with read/write access . 
            using (var writer = new StreamWriter(stream)) //StreamWriter.Write is job is to be writing text to a stream.
            using (var csvWriter = new CsvWriter(writer, ci)) //class that writes data in csv format 
            {
                // .WriteRecords(list);
                csvWriter.WriteRecords(list);
                writer.Flush(); //.Flush , corresponds to system.IO 
            }
        }

        public List<T>CSVloader<T>(string filePath)
        {
            List<T> momentList = new List<T>(); // momentList / temp list using T to define generic list. 

            using (StreamReader sr = new StreamReader(filePath))
            using (CsvReader csv = new CsvReader(sr, CultureInfo.InvariantCulture))
            {

                momentList= csv.GetRecords<T>().ToList(); //implementing the moment list (generic) into GetRecords which means it grabs all records adn implement into the CSV 
            }

            return momentList;  //return value of the list 
        }
        public void Preload()
        {

            //CRIMINAL MIND CHARACTERS: 
            _agents.Add(new BehavioralAnalysisUnit("Spencer", "Reid", "PhD Graduate at Caltech", "Statistics and geographic profiling"));
            _agents.Add(new BehavioralAnalysisUnit("Penelope", "Garcia", "Drop Out at California Institute of Technology", "Technical Analyst"));
            _agents.Add(new BehavioralAnalysisUnit("Emily", "Prentiss", "Graduate at Yale", "Terrorism, child advocacy, and linguistics"));


            CSVsaver(filePath, _agents); // this structure saves to the file path of BAUAgents.csv , the information is from the BehavioralAnalysisUnit list. 

            
        }



        private void btnPreload_Click(object sender, RoutedEventArgs e) //PRELOAD EVENT 
        {
            Preload(); 
            lvData.ItemsSource = _agents;
        }

        private void txtAddAgent_Click(object sender, RoutedEventArgs e) //accidently named button Txt :( 
        {
            //ADD AGENT BUTTON: 
            //The action. 

            //Data entered in the following presents the required parameters for constructor. 
            
            string firstName = txtFirstName.Text; 
            string lastName = txtLastName.Text;
            string education = txtEducation.Text; 
            string specialty = txtSpecialty.Text;

            //The entered data is then prompt to the constructor 
            _agents.Add(new BehavioralAnalysisUnit(firstName, lastName, education, specialty));

            //When information is filled & the button of ADD AGENT is selected, the data will be prompt onto the list view, continously 
            lvData.Items.Refresh(); 
        }

        private void btnSave_Click(object sender, RoutedEventArgs e) //SAVE CSV BUTTON
        {
            CSVsaver(filePath, _agents); // SAVES to file path of CSV BAU AGENTS 

            //CSV - Comma Seperated VALUES 
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e) //CSV LOADER 
        {
            //reads back the entire csv and saves it back to a list in your running application.
            _agents = CSVloader<BehavioralAnalysisUnit>(filePath); 
        }
    }
}
