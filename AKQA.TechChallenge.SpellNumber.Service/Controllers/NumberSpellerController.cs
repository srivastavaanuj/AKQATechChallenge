using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using AKQA.TechChallenge.SpellNumber.Core.Component;
using AKQA.TechChallenge.SpellNumber.Core.Exception;
using AKQA.TechChallenge.SpellNumber.Core.Interfaces;


namespace AKQA.TechChallenge.SpellNumber.Service.Controllers
{
    public class NumberSpellerController : ApiController
    {
        private INumberSpeller _numberSpeller;          
        public NumberSpellerController()
        {    
            //IOC container can be used  for the loose coupling
            _numberSpeller = new NumberSpeller();
        }
        [Route("api/number/{number}")]
        [HttpGet]
        public string SpellNumber(string number)
        {
            try
            {
                var doubleNumber = double.Parse(number);
                var result = "";
                var wholeNumber = (int) Math.Floor(doubleNumber);
                var wholeNumberWords = $"{_numberSpeller.SpellNumber(wholeNumber).ToUpper()} DOLLARS";
                var decimalDigits = doubleNumber-wholeNumber;
                var decimalDigitsWords =
                    $"{_numberSpeller.SpellNumber((int) (decimalDigits * 100)).ToUpper()} CENTS";   
                if (!(decimalDigits > 0))
                    result = wholeNumberWords;
                else
                    result = $"{wholeNumberWords} AND {decimalDigitsWords}";   

                return result;
            }
            catch (Exception ex)
            {
                throw new APIException($"Invalid input {number}", ex.InnerException, System.Net.HttpStatusCode.InternalServerError);

            }
        }
    }
}
