using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Meal_Sharers
{

    [Serializable]
    class SingletonDatabaseAccess
    {
        private List<Cook> cooksDB = new List<Cook>();
        public List<Cook> CooksDB
        {
            get
            {
                return cooksDB;
            }

            set
            {
                cooksDB = value;
            }
        }

        private List<Eater> eatersDB = new List<Eater>();
        public List<Eater> EatersDB
        {
            get
            {
                return eatersDB;
            }

            set
            {
                eatersDB = value;
            }
        }

      

        private SingletonDatabaseAccess ()
        {

        }

        //Singleton Pattern instance access to the constuctor
        private static SingletonDatabaseAccess dbInstance;
        public static SingletonDatabaseAccess DBInstance
        {
            get
            {
                if (dbInstance == null)
                /*
                 * If this is being called for the first time, instanciate a Logger object.
                 */
                {
                    dbInstance = new SingletonDatabaseAccess();
                }
                return dbInstance;
            }
        }



        //-----------READING FILES ON STARTUP AND CREATING LISTS----------------------------
        //fields and references for serialization
        [NonSerialized()]
        FileStream stream;
        [NonSerialized()]
        string filename;
        [NonSerialized()]
        BinaryFormatter formatter = new BinaryFormatter();

        //this method is going to read our customer DataBase at the beginning of every program
        public void readDB_OnStartup()
        {
            try
            {
                //we are accessing our file
                filename = "cooks.data";
                stream = File.OpenRead(filename);
                try
                {
                    cooksDB = (List<Cook>)formatter.Deserialize(stream);
                    Console.WriteLine("Cooks were read from!!!");
                }
                catch (Exception)
                {
                    MessageBox.Show("File for Cooks is Empty. Please create new Database.", "Empty File", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
                stream.Close();

            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Database for Cooks not found! Please add new Cook to create new one.", "Missing File!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            try
            {
                //we are accessing our file
                filename = "eaters.data";
                stream = File.OpenRead(filename);
                try
                {
                    eatersDB = (List<Eater>)formatter.Deserialize(stream);
                    Console.WriteLine("Eaters were read from!!!");
                }
                catch (Exception)
                {
                    MessageBox.Show("File for Eaters is Empty. Please create new Database.", "Empty File", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
                stream.Close();

            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Database for Eaters not found! Please add new Cook to create new one.", "Missing File!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        //method for saving our current DB to a file
        public void saveFiles()
        {
            filename = "cooks.data";
            stream = File.Create(filename);
            formatter.Serialize(stream, cooksDB);
            stream.Close();
            Console.WriteLine("Cooks were saved!!!");
            

            filename = "eaters.data";
            stream = File.Create(filename);
            formatter.Serialize(stream, eatersDB);
            stream.Close();
            Console.WriteLine("Eaters were saved!!!");
        }
    }
}
