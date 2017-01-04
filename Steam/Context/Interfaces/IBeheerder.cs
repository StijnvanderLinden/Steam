using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Steam.Models;

namespace Steam.Context
{
    public interface IBeheerder
    {
        Beheerder GetBeheerder(Beheerder beheerder);
        void DeleteSpeler(Speler speler);
        bool CheckGegevens(string inlognaam, string wachtwoord);
        bool CheckIfSpeler(string inlognaam, string wachtwoord);
        bool CheckInlognaam(string inlognaam);
        bool CheckNickname(string nickname);
        Speler GetSpeler(Speler speler);
        Speler GetSpelerByID(int ID);
        void AddSpeler(Speler speler);
    }
}
