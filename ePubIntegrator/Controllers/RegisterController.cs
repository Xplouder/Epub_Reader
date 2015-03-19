using System;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using ePubIntegrator.Exceptions;

namespace ePubIntegrator.Controllers {
    public class RegisterController {

	    public void validateRegisterValues(String username, string email, string password, string passwordConfirm, string date){
		    if (!isValidUsername(username)){
			    throw new InvalidUsernameException();
		    }

		    if(!isValidEmail(email)){
			    throw new InvalidEmailException();
		    }

		    if (!isValidPassword(password)){
			    throw new InvalidPasswordException();
		    }

		    if (!isValidPassword(password)){
			    throw new InvalidPasswordException();
		    }

		    if (!isSamePassword(password, passwordConfirm)){
			    throw new InvalidPasswordConfirmException();
		    }

		    if (!isValidDateTime(date)){
			    throw new InvalidDateTimeException();
		    }
	    }

	    public bool isValidUsername (string username) {

            if (username == null) {
                return false;
            }

            var length = username.Length;

            if (length < 5 || length > 15) {
                return false;
            }

            if (!isLowerAlpha(username[0])) {
                return false;
            }

            if (!isLowerAlphanumeric(username[length - 1])) {
                return false;
            }

            if (!Regex.IsMatch(username, "^[a-z0-9._-]*$")) {
                return false;
            }

            if (Regex.IsMatch(username, "[0-9]{5,15}")) {
                return false;
            }

            // Each username can contain only one of '.', '_', '-'.
            var punctuation = new[] { '.', '_', '-' };

            if (punctuation.Count(username.Contains) > 1) {
                return false;
            }

            // Each '.', '_', and '-' should be followed by an alpha-numeric.
            for (var i = 0; i < length - 1; i++) {
                if (punctuation.Contains(username[i]) && !isLowerAlphanumeric(username[i + 1])) {
                    return false;
                }
            }

            return true;
        }

        private bool isLowerAlpha (char c) {
            return c >= 'a' && c <= 'z';
        }

        private bool isLowerAlphanumeric (char c) {
            return isLowerAlpha(c) || (c >= '0' && c <= '9');
        }

        public bool isValidEmail (string email) {
            try {
                var m = new MailAddress(email);
                return true;
            } catch (Exception) {
                return false;
            }
        }

        public bool isValidPassword (string password) {

            if (password == null) {
                return false;
            }

            var length = password.Length;

            if (length < 5 || length > 20) {
                return false;
            }

            if (!isLowerAlpha(password[0])) {
                return false;
            }

            if (!isLowerAlphanumeric(password[length - 1])) {
                return false;
            }

            return true;
        }

        public bool isSamePassword (string passwordOriginal, string passwordConfirm) {
            return passwordOriginal.Equals(passwordConfirm);
        }

        public bool isValidDateTime (string date) {
            var zeroTime = new DateTime(1, 1, 1);
            var inputDate = Convert.ToDateTime(date);
            var nowDate = DateTime.Now;

            var span = nowDate - inputDate;

            int years = (zeroTime + span).Year - 1;

            return years >= 6;
        }
    }
}
