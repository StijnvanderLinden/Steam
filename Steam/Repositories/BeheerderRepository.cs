using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Steam.Models;
using Steam.Context;

namespace Steam.Repositories
{
    public class BeheerderRepository
    {
        IBeheerder context;
        public BeheerderRepository(IBeheerder context)
        {
            this.context = context;
        }
        public Beheerder GetBeheerder(Beheerder beheerder)
        {
            return context.GetBeheerder(beheerder);
        }
        public bool CheckGegevens(string inlognaam, string wachtwoord)
        {
            return context.CheckGegevens(inlognaam, wachtwoord);
        }
        public bool CheckOfSpelerBestaat(string inlognaam, string wachtwoord)
        {
            return context.CheckIfSpeler(inlognaam, wachtwoord);
        }
        public Speler GetSpeler(Speler speler)
        {
            return context.GetSpeler(speler);
        }
        public Speler GetSpelerByID(int ID)
        {
            return context.GetSpelerByID(ID);
        }
        public bool CheckNickname(string nickname)
        {
            return context.CheckNickname(nickname);
        }
        public bool CheckInlognaam(string inlognaam)
        {
            return context.CheckInlognaam(inlognaam);
        }
        public void AddSpeler(Speler speler)
        {
            context.AddSpeler(speler);
        }
    }
}
