using Avalonia;
using Avalonia.Controls;
using AvaloniaEdit.TextMate;
using TextMateSharp.Grammars;
using TotkTagEditor.ViewModels;

namespace TotkTagEditor.Views;
public partial class TagDatabaseView : UserControl
{
    private const string SCOPE_NAME = "source.yaml";
    private static readonly RegistryOptions _registryOptions = new(Application.Current?.ActualThemeVariant.Key switch {
        "Light" => ThemeName.LightPlus,
        _ => ThemeName.DarkPlus,
    });

    public TagDatabaseView()
    {
        InitializeComponent();

        TextMate.Installation tagsTextEditorTextMateInstallation = TagsTextEditor.InstallTextMate(_registryOptions);
        tagsTextEditorTextMateInstallation.SetGrammar(SCOPE_NAME);

        TextMate.Installation entriesTextEditorTextMateInstallation = EntriesTextEditor.InstallTextMate(_registryOptions);
        entriesTextEditorTextMateInstallation.SetGrammar(SCOPE_NAME);
    }
}
