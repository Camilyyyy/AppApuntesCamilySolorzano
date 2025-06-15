namespace AppApuntesCamilySolorzano.Views;

public partial class NotePage : ContentPage
{
    string _fileName = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");

    public NotePage()
    {
        InitializeComponent();

        string appDataPath=FileSystem.AppDataDirectory;
        string randomFile= $"{Path.GetRandomFileName()}.notes.txt";

        LoadNote(Path.Combine(appDataPath,randomFile));

    }

    private void SaveButton_Clicked(object sender, EventArgs e)
    {
        File.WriteAllText(_fileName, TextEditor.Text);
    }


    private void DeleteButton_Clicked(object sender, EventArgs e)
    {
        if (File.Exists(_fileName))
            File.Delete(_fileName);

        TextEditor.Text = string.Empty;
    }
    
    private void LoadNote (string fileName)
    {
        Models.Note note = new Models.Note();
        note.FileName = fileName;

        if (File.Exists(_fileName))
        {
            note.Date=File.GetCreationTime(fileName);
            note.Text=File.ReadAllText(fileName);
        }

        BindingContext = note;
    }
}