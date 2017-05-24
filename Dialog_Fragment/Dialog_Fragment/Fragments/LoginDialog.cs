using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Core.Models;

namespace Dialog_Fragment.Fragments
{
    public class LoginDialog : DialogFragment
    {
        public event EventHandler<User> OnLoginComplete;
        User _userInfo;
        Button btn_cancel;
        Button btn_login;
        EditText txt_email;
        EditText txt_pass;
        TextView txt_pass_error;

        public LoginDialog(User userInfo)
        {
            _userInfo = userInfo;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout._LoginDialog, container, false);




            btn_cancel = view.FindViewById<Button>(Resource.Id.btn_cancel);
            btn_login = view.FindViewById<Button>(Resource.Id.btn_login);
            txt_pass_error = view.FindViewById<TextView>(Resource.Id.txt_pass_error);
            txt_email = view.FindViewById<EditText>(Resource.Id.txt_email);
            txt_pass = view.FindViewById<EditText>(Resource.Id.txt_pass);

            btn_login.Click += Btn_login_Click;
            btn_cancel.Click += Btn_cancel_Click;


            return view;
        }


        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnActivityCreated(savedInstanceState);
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation;
        }


        public override void OnDismiss(IDialogInterface dialog)
        {
            base.OnDismiss(dialog);
        }


        /// <summary>
        /// 
        /// </summary>
        private void Btn_cancel_Click(object sender, EventArgs e)
        {
            Dialog.Dismiss();
        }




        /// <summary>
        /// 
        /// </summary>
        private void Btn_login_Click(object sender, EventArgs e)
        {
            //Toast.MakeText(this.Context, "Ê—Êœ  «‰Ã«„ ‘œ", ToastLength.Short).Show();
            var formIsValid = true;
            if (txt_email.Text == "")
            {
                formIsValid = false;
                txt_email.Error = Resources.GetString(Resource.String.txt_email_error);
            }

            if (txt_pass.Text == "")
            {
                formIsValid = false;
                txt_pass.Error = Resources.GetString(Resource.String.txt_pass_error);
            }


            if (formIsValid)
            {
                if (_userInfo != null)
                {
                    if (_userInfo.Email == txt_email.Text && _userInfo.Pass == txt_pass.Text)
                    {
                        _userInfo.IsLogin = true;

                        OnLoginComplete.Invoke(this, _userInfo);
                        Dialog.Dismiss();
                    }
                }

                txt_pass_error.Visibility = ViewStates.Visible;
                txt_pass_error.Text = Resources.GetString(Resource.String.pass_or_email_invalid);


            }
        }


    }
}