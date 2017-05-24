using System;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Content;
using Core.Models;

namespace Dialog_Fragment.Fragments
{
    public class SignUpDialog : DialogFragment
    {
        public event EventHandler<User> OnSignUpComplete;
        Button btn_cancel;
        Button btn_register;
        EditText txt_name;
        EditText txt_email;
        EditText txt_pass;
        EditText txt_confirm_pass;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view= inflater.Inflate(Resource.Layout._SignUpDialog, container, false);


            btn_cancel = view.FindViewById<Button>(Resource.Id.btn_cancel);
            btn_register = view.FindViewById<Button>(Resource.Id.btn_register);


            txt_email = view.FindViewById<EditText>(Resource.Id.txt_email);
            txt_name = view.FindViewById<EditText>(Resource.Id.txt_name);
            txt_pass = view.FindViewById<EditText>(Resource.Id.txt_pass);
            txt_confirm_pass = view.FindViewById<EditText>(Resource.Id.txt_confirm_pass);



            btn_register.Click += Btn_register_Click;
            btn_cancel.Click += Btn_cancel_Click;

            return view;
        }




        /// <summary>
        /// 
        /// </summary>
        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnActivityCreated(savedInstanceState);
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation;
        }


        /// <summary>
        /// 
        /// </summary>
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
        private void Btn_register_Click(object sender, EventArgs e)
        {
            //Toast.MakeText(this.Context,"À»  ‰«„ «‰Ã«„ ‘œ",ToastLength.Short).Show();
            var formIsValid = true;


            if (txt_pass.Text != "" && txt_confirm_pass.Text != "" && txt_pass.Text != txt_confirm_pass.Text)
            {
                formIsValid = false;
                txt_confirm_pass.Error = Resources.GetString(Resource.String.txt_pass_not_confirm_error);
            }

            if (txt_name.Text == "")
            {
                formIsValid = false;
                txt_name.Error = Resources.GetString(Resource.String.txt_name_error);
            }
            
            if (txt_email.Text=="")
            {
                formIsValid = false;
                txt_email.Error = Resources.GetString(Resource.String.txt_email_error);
            }

            if (txt_pass.Text == "")
            {
                formIsValid = false;
                txt_pass.Error = Resources.GetString(Resource.String.txt_pass_error);
            }

            if (txt_confirm_pass.Text == "")
            {
                formIsValid = false;
                txt_confirm_pass.Error = Resources.GetString(Resource.String.txt_confirm_pass_error);
            }

            if (formIsValid)
            {
                var user = new User {DisplayName= txt_name.Text, Email =txt_email.Text,Pass=txt_pass.Text};
                OnSignUpComplete.Invoke(this,user);
                Dialog.Dismiss();

            }

        }




    }
}