using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Program
    {
        /*
         * 預設 case
         *  雖然 Password 欄位為空白
         *  但驗證錯誤訊息的屬性 Errors 卻沒有任何錯誤提示
         * 
         * 修正
         *  將 Errors 與 ToModel 調整位置後
         *  Errors 屬性顯示錯誤訊息 "Password is required !"
         */

        static void Main(string[] args)
        {
            LoginViewModel _viewModel;
            LoginModel _model;
            string _json;

            _viewModel = new LoginViewModel();
            _viewModel.Email = "txstudio@outlook.com";
            //_viewModel.Password = "password";
            

            //顯示 LoginViewModel json 內容
            _json = JsonConvert.SerializeObject(_viewModel, Formatting.Indented);
            Console.WriteLine("LoginViewModel");
            Console.WriteLine(_json);
            Console.WriteLine();


            //取得 LoginViewModel 代表的 LoginModel 物件
            _model = _viewModel.ToModel;


            //顯示 LoginModel json 內容
            _json = JsonConvert.SerializeObject(_model, Formatting.Indented);
            Console.WriteLine("LoginModel");
            Console.WriteLine(_json);


            Console.WriteLine();
            Console.WriteLine("press any key to exit");
            Console.ReadKey();
        }
    }

    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    #region Errors 屬性在 ToModel 屬性前面
    public class LoginViewModel
    {
        private LoginModel _model;
        private List<string> _errors;

        public LoginViewModel()
        {
            this._model = new LoginModel();
            this._errors = new List<string>();
        }

        public string Email { get; set; }
        public string Password { get; set; }

        public IEnumerable<string> Errors
        {
            get
            {
                var _result = _errors.ToArray();

                if (_result.Length == 0)
                    return null;

                return _result;
            }
        }

        public LoginModel ToModel
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.Email) == true)
                    _errors.Add("Email is required !");
                else
                    this._model.Email = this.Email;

                if (string.IsNullOrWhiteSpace(this.Password) == true)
                    _errors.Add("Password is required !");
                else
                    this._model.Password = this.Password;

                return this._model;
            }
        }

        public bool IsValid
        {
            get
            {
                if (this._errors == null)
                    return true;

                return false;
            }
        }
    }
    #endregion


    #region Errors 屬性在 ToModel 屬性後面
    //public class LoginViewModel
    //{
    //    private LoginModel _model;
    //    private List<string> _errors;

    //    public LoginViewModel()
    //    {
    //        this._model = new LoginModel();
    //        this._errors = new List<string>();
    //    }

    //    public string Email { get; set; }
    //    public string Password { get; set; }

    //    public LoginModel ToModel
    //    {
    //        get
    //        {
    //            if (string.IsNullOrWhiteSpace(this.Email) == true)
    //                _errors.Add("Email is required !");
    //            else
    //                this._model.Email = this.Email;

    //            if (string.IsNullOrWhiteSpace(this.Password) == true)
    //                _errors.Add("Password is required !");
    //            else
    //                this._model.Password = this.Password;

    //            return this._model;
    //        }
    //    }

    //    public IEnumerable<string> Errors
    //    {
    //        get
    //        {
    //            var _result = _errors.ToArray();

    //            if (_result.Length == 0)
    //                return null;

    //            return _result;
    //        }
    //    }

    //    public bool IsValid
    //    {
    //        get
    //        {
    //            if (this._errors == null)
    //                return true;

    //            return false;
    //        }
    //    }
    //}
    #endregion


}
