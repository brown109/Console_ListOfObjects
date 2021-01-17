using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_ListOfObjects
{
    class Animal
    {

        #region ENUMS

        public enum DietType
        { 
            herbivore,
            carnivore,
            omnivore,
            unknown
        }

        #endregion


        #region FIELDS

        private string _commonName;
        private bool _isReal;
        private int _legs;
        private DietType _diet;

        #endregion

        #region PROPERTIES
        public string Name
        {
            get { return _commonName; }
            set { _commonName = value; }
        }
        public bool IsReal
        {
            get { return _isReal; }
            set { _isReal = value; }
        }
        public int Legs
        {
            get { return _legs; }
            set { _legs = value; }
        }

        public DietType Diet
        {
            get { return _diet; }
            set { _diet = value; }
        }

        #endregion
        #region CONSTRUCTORS

        public Animal()
        {
            

        }
        // next contructor won't be used (at least I think so)
        /* public Animal(string name, int legs)
        {

            _commonName = name;
            _legs = legs;

        } */

        #endregion
    }
}
