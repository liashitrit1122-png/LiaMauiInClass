using LiaMauiInClass.Helpers;

namespace LiaMauiInClass.Views;

public partial class SignInPage : ContentPage
{
    private string _userName;
    private string _password;
    private bool _entryAsPassword;
    private DBMokup _db;
    private string _messageText;  
    private bool _isMessageVisible;
    private bool _debugMode => true; // Set to true for debug mode, false for production 
    private bool IsSignMessageVisible;
    private Color _messageColor;
    
    public Color MessageColor
    {
        get { return _messageColor; }
        set
        {
            if (value != _messageColor)
            {
                _messageColor = value;
                OnPropertyChanged();
            }
        }   
    }

    public bool IsMessageVisible
    {
        get { return _isMessageVisible; }
        set
        {
            if (value != _isMessageVisible)
            {
                _isMessageVisible = value;
                OnPropertyChanged();
            }
        }
    }
    public string MessageText
    {
        
        get { return _messageText; }
        set
        {
            if (value != _messageText)
            {
                _messageText = value;
                OnPropertyChanged();
            }   
         

        }
    }   
    public bool IsSignInButtonEnabled
    {

        get => !(string.IsNullOrEmpty(UserName) ||
            string.IsNullOrEmpty(UserPassword));

    }
    public bool EntryAsPassword
    {
        get { return _entryAsPassword; }
        set
        {
            if (value != _entryAsPassword)
            {
                _entryAsPassword = value;
                OnPropertyChanged();
            }
        }
    }   
    public string UserName
    {
        get { return _userName; }
        set
        {
            if (value != _userName)
            {
                _userName = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsSignInButtonEnabled));
            }
        }
    }
    public string UserPassword
    {
        get { return _password; }
        set
        {
            if (value != _password)
            {
                _password = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsSignInButtonEnabled));
            }   
            
        }

    }

    public bool IsSignInMessageVisible { get; private set; }

    public  SignInPage()
    {
        InitializeComponent();
        BindingContext = this;
        EntryAsPassword = true;
        _db = new DBMokup();

        if (_debugMode)
        {
            // For debug mode, pre-fill the username and password
            UserName = "admin@mail.com";
            UserPassword = "admin";
        }
    }
    private void TogglePassordButton_Clicked(object sender, EventArgs e)
    {
        var visBtn = sender as Button;

      // PasswordEntry.IsPassword = !PasswordEntry.IsPassword;
       // if (PasswordEntry.IsPassword)
       if (EntryAsPassword) 
            visBtn!.Text = FontHelper.CLOSED_EYE_ICON;
        else
            visBtn!.Text = FontHelper.OPEN_EYE_ICON;

        EntryAsPassword = !EntryAsPassword;

    }
    private void OnSignInButtonClick(object sender, EventArgs e)
  {



        IsSignInMessageVisible = true;
       if (_db.isExist(UserName, UserPassword))
    {


            MessageColor = Colors.LightGreen;
            MessageText = "התחברות הצליחה"; 
          
         
        }
       else
       {
            MessageColor = Colors.Red;  
            MessageText = "שגיאת התחברות";  
            // errorLbl.Text = ";"התחברות שגיאת
            // errorLbl.TextColor = Colors.Red;
        }
   
  }

}





    